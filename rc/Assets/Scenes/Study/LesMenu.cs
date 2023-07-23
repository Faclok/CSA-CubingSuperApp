using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LesMenu : MonoBehaviour
{
    public Transform buttonsPlace;

    public GameObject buttonPrefab;
    private List<string> titles = new List<string>() { "Урок 1: что это такое?", "Урок 2: язык вращений", "Урок 3: белый крест", "Урок 4: белая сторона",
        "Урок 5: второй слой", "Урок 6: OLL крест", "Урок 7: OLL сторона", "Урок 8: PLL", "Урок 9: узоры" };

    private void Awake()
    {
        Tab.Cube.SetActive(false);
        for (int i = 0; i < 9; i++)
        {
            var installed = Instantiate(buttonPrefab, buttonsPlace, false);
            installed.GetComponentInChildren<TextMeshProUGUI>().text = titles[i];
            installed.GetComponent<ChooseLesson>().lessonIndex += i;
        }
    }
}
