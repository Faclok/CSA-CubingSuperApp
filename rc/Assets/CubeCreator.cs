using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    public static GameObject CubePrefab;
    public GameObject cubePrefab;
    private static Transform CubePlace;
    private void Awake()
    {
        CubePrefab = cubePrefab;
        CubePlace = transform;
    }
    public static void CreateCube()
    {
        if (CubePlace.childCount>0)
        {
            for (int i = 0; i < CubePlace.childCount; i++)
            {
                Destroy(CubePlace.GetChild(i).gameObject);
            }
        }
        Instantiate(CubePrefab, CubePlace);
    }

}
