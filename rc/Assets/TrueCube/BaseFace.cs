using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseFace : MonoBehaviour
{

    [HideInInspector]
    public new Transform transform;

    public CubicRubik CubicRubik { get; private set; }

    private readonly HashSet<CornerFace> _faces = new();

    public CardiantSplash CardiantSplash { get; private set; }

    public bool IsMovingScroll { get; private set; }

    private void Awake()
    {
        transform = base.transform;
    }

    public CornerFace[] SplashCreate(CardiantSplash splash, Vector3 vector, CubicRubik cubicRubik, CornerFace corner, CornerFace center, CornerFace edge)
        => OneToTwo(splash switch
        {
            CardiantSplash.XToY => vector.x,
            CardiantSplash.XToZ => vector.x,
            CardiantSplash.YToZ => vector.y,
            _ => 0f
        },
            splash switch
            {
                CardiantSplash.XToY => vector.y,
                CardiantSplash.XToZ => vector.z,
                CardiantSplash.YToZ => vector.z,
                _ => 0f
            }, splash, cubicRubik, corner, center, edge);

    private CornerFace[] OneToTwo(float oneCardiant, float twoCardiant, CardiantSplash cardiant, CubicRubik cubicRubik, CornerFace corner, CornerFace center, CornerFace edge)
    {
        CubicRubik = cubicRubik;
        CardiantSplash = cardiant;
        var endPositionOne = (oneCardiant - 1f) / 2f;
        var endPositionTwo = (twoCardiant - 1f) / 2f;
        var startPositionOne = (int)endPositionOne * -1;
        var startPositionTwo = (int)endPositionTwo * -1;

        var result = new List<CornerFace>();

        for (int one = startPositionOne; one <= endPositionOne; one++)
        {
            for (int two = startPositionTwo; two <= endPositionTwo; two++)
            {
                var position = GetPosition(cardiant, one, two);
                CornerFace gameObject;

                if (one > startPositionOne && two > startPositionTwo && one < endPositionOne && two < endPositionTwo)
                    gameObject = Instantiate(center, transform, false);
                else if ((one == startPositionOne && two == startPositionTwo) || (one == endPositionOne && two == endPositionTwo)
                      || (one == startPositionOne && two == endPositionTwo) || (one == endPositionOne && two == startPositionTwo))
                    gameObject = Instantiate(corner, transform, false);
                else gameObject = Instantiate(edge, transform, false);

                gameObject.transform.localPosition = position;
                gameObject.BaseFace = this;

                _faces.Add(gameObject);
                result.Add(gameObject);
            }
        }
        return result.ToArray();
    }

    private Coroutine Coroutine;
    public void Scroll(EdgeFace edge)
    {
        var data = _faces.FirstOrDefault(o => o.EdgeFace == edge);

        if (data == null)
            return;

        if (CubicRubik.IsBlockRotation || _faces.Any(o => o.IsMoving))
            return;

        if (Coroutine != null)
            return;

        IsMovingScroll = true;

        foreach (var item in _faces)
            item.StartMove();

        Coroutine = StartCoroutine(StartRotation(data));
    }

    private IEnumerator StartRotation(CornerFace corner)
    {
        var startAngles = transform.localRotation;
        var endAngles = Quaternion.Euler(CardiantSplash switch
        {
            CardiantSplash.XToY => new Vector3(0f, 0f, transform.localEulerAngles.z + 90f),
            CardiantSplash.XToZ => new Vector3(0f, transform.localEulerAngles.y + 90f, 0f),
            CardiantSplash.YToZ => new Vector3(transform.localEulerAngles.x + 90f, 0f, 0f),
            _ => Vector3.zero
        });

        var vector = 0f;

        while (vector < 1f) {
            transform.localRotation = Quaternion.Slerp(startAngles, endAngles,vector += Time.deltaTime);
            yield return null;
        }

        while (!corner.IsTrueCardiant)
            yield return null;

        foreach (var item in _faces)
            item.StopMove();
        Coroutine = null;
        IsMovingScroll = false;
    }

    private static Vector3 GetPosition(CardiantSplash splash, float one, float two)
        => splash switch
        {
            CardiantSplash.XToY => new Vector3(one, two, 0f),
            CardiantSplash.XToZ => new Vector3(one, 0f, two),
            CardiantSplash.YToZ => new Vector3(0f, one, two),
            _ => Vector3.zero
        };
}

public enum CardiantSplash
{ XToY, XToZ, YToZ }
