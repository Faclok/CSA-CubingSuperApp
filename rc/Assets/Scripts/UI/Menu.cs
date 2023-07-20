using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

	[SerializeField] private TextMeshProUGUI greetingText;

	private List<string> greetingsTexts = new List<string>() { "Удачных сборок!", "Добро пожаловать!", "Хороших сборок!", "Новых рекордов!", "Интересных скрамблов!",
	"Стабильного кручения!"};

    private void Awake()
    {
		greetingText.text = greetingsTexts[Random.Range(0,greetingsTexts.Count-1)];
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

	public void VideoZenMoe(string key)
    {
		if (links.ContainsKey(key.ToLower()))
			Application.OpenURL(links[key]);
	}
	
	public void SettingsSceneMove()
    {
		if (CubeManager.canShuffle && CubeManager.canRotate)
		{
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

			if (CubeManager.cubeSpeed == 5) { SliderSpeed.cubeSpeedSlider.value = 1; }
			else if (CubeManager.cubeSpeed == 10) { SliderSpeed.cubeSpeedSlider.value = 2; }
			else if (CubeManager.cubeSpeed == 15) { SliderSpeed.cubeSpeedSlider.value = 3; }
			else if (CubeManager.cubeSpeed == 30) { SliderSpeed.cubeSpeedSlider.value = 4; }
			else if (CubeManager.cubeSpeed == 45) { SliderSpeed.cubeSpeedSlider.value = 5; }

			SliderSpeed.cameraSpeedSlider.value = CameraMovement.cameraSpeed;
		}
	}
}

	

