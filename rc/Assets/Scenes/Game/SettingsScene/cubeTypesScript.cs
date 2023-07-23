using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cubeTypesScript : MonoBehaviour
{
    public static List<Toggle> cubeTypes = new List<Toggle>();
    public List<Toggle> _cubeTypes = new List<Toggle>();
    public static int activeToggle;

    private void Awake()
    {
        cubeTypes = _cubeTypes;
        Tab.Cube.SetActive(false);
        cubeTypes[activeToggle].isOn = true;
    }
    public void Close()
    {
        Destroy(GameButtons.settings);
        GameButtons.settings = null;
        Tab.Cube.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Destroy(GameButtons.settings);
                GameButtons.settings = null;
                Tab.Cube.gameObject.SetActive(true);
            }
        }
    }
    public void GetActiveToggle()
    {
        for (int i = 0; i < cubeTypes.Count; i++)
        {
            if (cubeTypes[i].isOn)
            {
                activeToggle = i;
                PlayerPrefs.SetInt("ActiveToggle", activeToggle);
                CubeCreator.CreateCube();
            }
        }
        
    }
}
