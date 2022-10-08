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
        colorType = _colorType;
        tiledType = _tiledType;
        standardType = _standardType;
    }
    public void GetActiveToggle()
    {
        if (standardType.isOn)
        {
            activeToggle = 0;
            PlayerPrefs.SetInt("ActiveToggle", activeToggle);
            //CubeManager.Type();
        }
        if (colorType.isOn)
        {
            activeToggle = 1;
            PlayerPrefs.SetInt("ActiveToggle", activeToggle);
            //CubeManager.Type();
        }
        if (tiledType.isOn)
        {
            activeToggle = 2;
            PlayerPrefs.SetInt("ActiveToggle", activeToggle);
            //CubeManager.Type();
        }
    }
}
