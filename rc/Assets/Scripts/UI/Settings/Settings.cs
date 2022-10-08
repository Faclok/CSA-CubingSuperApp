using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Settings : MonoBehaviour {
	public Toggle is1;
	public Toggle is2;
	public Toggle is3;
	public GameObject UpCube;
	public GameObject DownCube;
	public GameObject LeftCube;
	public GameObject RightCube;
	public GameObject FrontCube;
	public GameObject BackCube;


	public void Type()
    {
        if (is1.isOn) 
		{ 
			UpCube.gameObject.SetActive(false); 
			DownCube.gameObject.SetActive(false); 
			LeftCube.gameObject.SetActive(false); 
			RightCube.gameObject.SetActive(false); 
			FrontCube.gameObject.SetActive(false); 
			BackCube.gameObject.SetActive(false); 
		}
		if (is3.isOn)
		{
			UpCube.gameObject.SetActive(true);
			DownCube.gameObject.SetActive(true);
			LeftCube.gameObject.SetActive(true);
			RightCube.gameObject.SetActive(true);
			FrontCube.gameObject.SetActive(true);
			BackCube.gameObject.SetActive(true);
		}
	}
}
