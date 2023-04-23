using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	private Dictionary<string, string> links = new Dictionary<string, string>() { ["что это такое?"] = "https://zen.yandex.ru/video/watch/62472f942a9b511181cb7357",
		["язык вращений"] = "https://zen.yandex.ru/video/watch/624731504d78e042ca4f11f2",
		["белый крест"] = "https://zen.yandex.ru/video/watch/62485d737c6c122beecac553",
		["белая сторона"] = "https://zen.yandex.ru/video/watch/624912031c8df127de6766ee",
		["второй слой"] = "https://zen.yandex.ru/video/watch/624915231307c26b95f590f6",
		["желтый крест"] = "https://zen.yandex.ru/video/watch/624981f6338e1723095ac80b",
		["желтая сторона"] = "https://zen.yandex.ru/video/watch/624999f32664b56b3174b9e3",
		["pll"] = "https://zen.yandex.ru/video/watch/624a9886e391da4c00eb8e96",
		["узоры"] = "https://zen.yandex.ru/video/watch/624a9bc20fb19733e9141c62",
		["канал дзен"] = "https://zen.yandex.ru/id/624094a4f4d7ff38d09d7027"
	};
	public static bool canParticle = false;
	public static int prevActiveToggle;

    private void Awake()
    {
		
		if (PlayerPrefs.HasKey("ActiveToggle"))
        {
            cubeTypesScript.activeToggle = PlayerPrefs.GetInt("ActiveToggle");
        }
        else
        {
            cubeTypesScript.activeToggle = 1;
        }

        if (PlayerPrefs.HasKey("CubeSpeed"))
        {
            CubeManager.cubeSpeed = PlayerPrefs.GetInt("CubeSpeed");
        }
        else
        {
            CubeManager.cubeSpeed = 15;
        }

        if (PlayerPrefs.HasKey("CameraSpeed"))
        {
            CameraMovement.cameraSpeed = PlayerPrefs.GetInt("CameraSpeed");
        }
        else
        {
            CameraMovement.cameraSpeed = 1;
        }



    }
    public void Play(){
		//Destroy(gameObject);
		SceneChanger.Cube.gameObject.SetActive(true);
		SceneChanger.MoveToAnotherScene(SceneChanger.gameScene);
	}

	public void VideoZenMoe(string key)
    {
		if (links.ContainsKey(key.ToLower()))
			Application.OpenURL(links[key]);
	}

	public void StudyOnClick()
    {
		Destroy(gameObject);
		SceneChanger.MoveToAnotherScene(SceneChanger.lessonsMenuScene);
    }

	public void InfoSceneMove()
    {
		SceneChanger.MoveToAnotherScene(SceneChanger.infoScene);
	}
	
	public void SettingsSceneMove()
    {
		if (CubeManager.canShuffle && CubeManager.canRotate)
		{
			SceneChanger.Cube.gameObject.SetActive(false);
			SceneChanger.MoveToAnotherScene(SceneChanger.settingsScene);
			if (cubeTypesScript.activeToggle == 0)
			{
				cubeTypesScript.standardType.isOn = true;
			}
			else if (cubeTypesScript.activeToggle == 1)
			{
				cubeTypesScript.colorType.isOn = true;
			}
			else if (cubeTypesScript.activeToggle == 2)
			{
				cubeTypesScript.tiledType.isOn = true;
			}
			prevActiveToggle = cubeTypesScript.activeToggle;

			if (CubeManager.cubeSpeed == 5) { SliderSpeed.cubeSpeedSlider.value = 1; }
			else if (CubeManager.cubeSpeed == 10) { SliderSpeed.cubeSpeedSlider.value = 2; }
			else if (CubeManager.cubeSpeed == 15) { SliderSpeed.cubeSpeedSlider.value = 3; }
			else if (CubeManager.cubeSpeed == 30) { SliderSpeed.cubeSpeedSlider.value = 4; }
			else if (CubeManager.cubeSpeed == 45) { SliderSpeed.cubeSpeedSlider.value = 5; }

			SliderSpeed.cameraSpeedSlider.value = CameraMovement.cameraSpeed;
		}
	}

	public void BackFromLesson()
	{
		for (int i = 0; i < Tab.TabPlace.transform.childCount; i++)
		{
			Destroy(Tab.TabPlace.transform.GetChild(i).gameObject);
		}
		Instantiate(Tab.Panels[0], Tab.TabPlace);
	}

	public void BackFromGame()
	{
		if (CubeManager.canShuffle && CubeManager.canRotate)
		{
			SceneChanger.MoveToAnotherScene(SceneChanger.menuScene);
			SceneChanger.Cube.gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}

	public void Back()
	{
		Destroy(gameObject);
	}
	
	public void BackFromSettings()
	{
		if(prevActiveToggle != cubeTypesScript.activeToggle)
        {
			CubeManager.Type();
			canParticle = false;
        }
		SceneChanger.Cube.gameObject.SetActive(true);
		Destroy(gameObject);
	}
	
	public void Shuffle()
    {
		CubeManager.Shuffle1();
		canParticle = true;
    }

	public void ReCreate()
    {
		CubeManager.Type();
		canParticle = false;
    }

	public void OnClickTips()
    {
		TipsMenuScript.SetButts();
    }
}

	

