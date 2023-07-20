using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cubeTypesScript : MonoBehaviour
{
    public Toggle _colorType;
    public static Toggle colorType;
    public Toggle _tiledType;
    public static Toggle tiledType;
    public Toggle _standardType;
    public static Toggle standardType;
    public static int activeToggle;

    private void Awake()
    {
        Tab.Cube.SetActive(false);
        colorType = _colorType;
        tiledType = _tiledType;
        standardType = _standardType;
    }
    private void OnDestroy()
    {
        Tab.Cube.SetActive(true); 
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
        if (standardType.isOn)
        {
            activeToggle = 0;
            PlayerPrefs.SetInt("ActiveToggle", activeToggle);
            CubeCreator.CreateCube();
        }
        if (colorType.isOn)
        {
            activeToggle = 1;
            PlayerPrefs.SetInt("ActiveToggle", activeToggle);
            CubeCreator.CreateCube();
        }
        if (tiledType.isOn)
        {
            activeToggle = 2;
            PlayerPrefs.SetInt("ActiveToggle", activeToggle);
            CubeCreator.CreateCube();
        }
    }
}
