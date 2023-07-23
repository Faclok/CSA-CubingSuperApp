
using UnityEngine;

public class CubeAlgButtons : MonoBehaviour
{
    public GameObject cubeAlgManager;
    public void NextMove()
    {
        cubeAlgManager.GetComponent<CubeAlgManager>().DoNextMove();
    }
    public void PrevMove()
    {
        cubeAlgManager.GetComponent<CubeAlgManager>().DoPrevMove();
    }
}
