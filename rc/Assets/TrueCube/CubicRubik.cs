using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class CubicRubik : MonoBehaviour
{
    private const int COUNT_CORNERS = 8;
    private const int COUNT_FACES = 6;
    private readonly Dictionary<Vector3, List<CornerFace>> _cubes = new();

    private readonly HashSet<BaseFace> _faces = new();

    [HideInInspector]
    public new Transform transform;

    public int SizeCube = 3;
    public BaseFace Border;

    public CornerFace FaceCorner;
    public CornerFace FaceEdge;
    public CornerFace FaceCenter;

    public GameObject Corner;
    public GameObject Edge;
    public GameObject Center;

    public bool IsBlockRotation => _faces.Any(o => o.IsMovingScroll);

    public event Action OnCompleted;

    private void Awake()
    {
        transform = base.transform;
        CreateCube();
    }

    private void CreateCube()
    {
        var startPosition = (SizeCube - 1) / 2f * (-1f);

        for (int i = 0; i < SizeCube; i++)
        {
            var data = Instantiate(Border, transform, false);
            data.transform.localPosition = new Vector3(0, 0, startPosition + i);
            UpdateCube(data.SplashCreate(CardiantSplash.XToY, new Vector3(SizeCube, SizeCube, 1), this, FaceCorner, FaceCenter, FaceEdge));
            _faces.Add(data);

            data = Instantiate(Border, transform, false);
            data.transform.localPosition = new Vector3(0, startPosition + i, 0);
            UpdateCube(data.SplashCreate(CardiantSplash.XToZ, new Vector3(SizeCube, 1, SizeCube), this, FaceCorner, FaceCenter, FaceEdge));
            _faces.Add(data);

            data = Instantiate(Border, transform, false);
            data.transform.localPosition = new Vector3(startPosition + i, 0, 0);
            UpdateCube(data.SplashCreate(CardiantSplash.YToZ, new Vector3(1, SizeCube, SizeCube), this, FaceCorner, FaceCenter, FaceEdge));
            _faces.Add(data);
        }

        CreateCubeOnCardiant();
    }


    public void CreateCubeOnCardiant()
    {
        foreach (var item in _cubes)
        {
            var list = item.Value.Select(o => o.TypeCube);

            if (list.Contains(TypeCube.Corner) && list.Contains(TypeCube.Edge))
            {
                var data = Instantiate(Edge.gameObject, transform, false).GetComponent<EdgeFace>();
                data.transform.position = item.Key;
                data.CubicRubik = this;
                data.TypeCube = TypeCube.Edge;
            }
            else if (list.Select(o => o == TypeCube.Corner ? 1 : 0).Sum() == 3)
            {
                var data = Instantiate(Corner.gameObject, transform, false).GetComponent<EdgeFace>();
                data.TypeCube = TypeCube.Center;
                data.CubicRubik = this;
                data.transform.position = item.Key;
            }
            else
            {
                var data = Instantiate(Center.gameObject, transform, false).GetComponent<EdgeFace>();
                data.TypeCube = TypeCube.Center;
                data.CubicRubik = this;
                data.transform.position = item.Key;
            }
        }
    }

    private void UpdateCube(CornerFace[] cubes)
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (_cubes.ContainsKey(cubes[i].transform.position))
                _cubes[cubes[i].transform.position].Add(cubes[i]);
            else _cubes.Add(cubes[i].transform.position, new() { cubes[i] });
        }
    }

    public void Scroll(EdgeFace face, List<CornerFace> corners)
    {
        var data = corners.FirstOrDefault();

        if (data == null)
            return;

        data.BaseFace.Scroll(face);
    }
}
