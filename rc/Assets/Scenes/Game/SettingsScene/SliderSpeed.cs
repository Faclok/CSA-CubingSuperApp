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
        cubeSpeedSlider.value = CubeManager.cubeSpeed;

        cameraSpeedSlider.value = CameraMovement.cameraSpeed;
    }
    
    public void OnValueChangedCubeSpeed()
    {
        int x = Convert.ToInt32(Math.Round(Convert.ToDouble(cubeSpeedSlider.value / 15)) * 15);
        if (x <= 0)
        {
            CubeManager.cubeSpeed = 1;
        }
        else
        {
            CubeManager.cubeSpeed = x;
        }
        PlayerPrefs.SetFloat("CubeSpeed", CubeManager.cubeSpeed);
        
    }

    public void OnValueChangedCameraSpeed()
    {
        CameraMovement.cameraSpeed = Convert.ToInt32(cameraSpeedSlider.value);
        PlayerPrefs.SetInt("CameraSpeed", CameraMovement.cameraSpeed);
    }
}
