using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    public static List<GameObject> CubePrefabs = new List<GameObject>();
    public List<GameObject> cubePrefabs = new List<GameObject>();
    private static Transform CubePlace;
    private void Start()
    {
        CubePrefabs = cubePrefabs;
        CubePlace = transform;
        if (Tab.Cube.transform.childCount==0)
        {
            CreateCube();
            Tab.Cube.SetActive(false);
        }
        else
        {
            Tab.Cube.SetActive(true);
        }
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
        Instantiate(CubePrefabs[cubeTypesScript.activeToggle], CubePlace);
    }

}
