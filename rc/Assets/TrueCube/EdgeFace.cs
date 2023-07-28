using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EdgeFace : MonoBehaviour
{
    [HideInInspector]
    public TypeCube TypeCube;

    [HideInInspector]
    public new Transform transform;

    private List<CornerFace> _corners = new();

    public CubicRubik CubicRubik;
    public CornerFace CornerFace;

    private bool _isCheck;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        transform = base.transform;
    }

    private Coroutine _coroutine;
    public void Rotation()
    {
        if (CubicRubik.IsBlockRotation)
            return;

        _corners = new();
        IsMoving = true;
        _isCheck = true;

        _coroutine = StartCoroutine(CheckStay());
    }

    private IEnumerator CheckStay()
    {
        while(_isCheck)
            yield return null;

        CubicRubik.Scroll(this, _corners);
        IsMoving = false;
        _coroutine = null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (_isCheck && other.gameObject.TryGetComponent(out CornerFace face))
        {
            if (!_corners.Contains(face))
                _corners.Add(face);
            else _isCheck = false;
        }
        
    }

    private void FixedUpdate()
    {
        if (CornerFace != null)
        {
            transform.position = CornerFace.transform.position;
            transform.eulerAngles = CornerFace.transform.eulerAngles;
        }
    }
}
