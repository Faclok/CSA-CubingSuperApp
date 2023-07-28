using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerFace : MonoBehaviour
{
    [SerializeField]
    private TypeCube _typeCube;
    public TypeCube TypeCube => _typeCube;

    public BaseFace BaseFace;
    public EdgeFace EdgeFace { get; private set; }
    public bool IsMoving => !(EdgeFace?.CornerFace == null);
    public bool IsTrueCardiant => EdgeFace.transform.position == transform.position && EdgeFace.transform.eulerAngles == transform.eulerAngles;

    public void StartMove()
    {
         EdgeFace.CornerFace = this;
    }

    public void StopMove()
    {
        EdgeFace.CornerFace = null;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (EdgeFace == null && other.gameObject.TryGetComponent(out EdgeFace face))
            EdgeFace = face;
    }

    private void OnTriggerExit(Collider other)
    {
        if (EdgeFace != null && other.gameObject.TryGetComponent(out EdgeFace _))
            EdgeFace = null;
    }
}

public enum TypeCube
{ Corner, Center, Edge }
