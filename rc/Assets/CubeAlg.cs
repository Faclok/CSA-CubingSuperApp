using UnityEngine;

public class CubeAlg : MonoBehaviour
{
    public static Transform cubePos;
    public Transform _cubePos;

    public string alg;
    private void Awake()
    {
        cubePos = _cubePos;
    }
}
