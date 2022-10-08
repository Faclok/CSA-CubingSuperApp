using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderSpeed : MonoBehaviour
{
    public Slider _cubeSpeedSlider;
    public static Slider cubeSpeedSlider;

    public Slider _cameraSpeedSlider;
    public static Slider cameraSpeedSlider;

    private void Awake()
    {
        cubeSpeedSlider = _cubeSpeedSlider;
        cameraSpeedSlider = _cameraSpeedSlider;
    }
    
    public void OnValueChangedCubeSpeed()
    {
        if(cubeSpeedSlider.value == 1)
        {
            CubeManager.cubeSpeed = 1;
        }
        else if (cubeSpeedSlider.value == 2)
        {
            CubeManager.cubeSpeed = 10;
        }
        else if (cubeSpeedSlider.value == 3)
        {
            CubeManager.cubeSpeed = 15;
        }
        else if (cubeSpeedSlider.value == 4)
        {
            CubeManager.cubeSpeed = 30;
        }
        else if (cubeSpeedSlider.value == 5)
        {
            CubeManager.cubeSpeed = 45;
        }
        PlayerPrefs.SetInt("CubeSpeed", CubeManager.cubeSpeed);
    }

    public void OnValueChangedCameraSpeed()
    {
        CameraMovement.cameraSpeed = Convert.ToInt32(cameraSpeedSlider.value);
        PlayerPrefs.SetInt("CameraSpeed", CameraMovement.cameraSpeed);
    }
}
