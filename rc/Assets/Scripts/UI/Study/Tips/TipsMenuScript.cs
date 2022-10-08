using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipsMenuScript : MonoBehaviour
{
    public Transform buttonsPlace;
    public static Transform _buttonsPlace;
    public GameObject buttonPrefab;
    public static Transform _algPlace;
    public Transform algPlace;
    public static GameObject _buttonPrefab;
    public static List<GameObject> buttons = new List<GameObject>();
    private static List<string> titles = new List<string>() { "Углы", "Второй слой", "Жёлтый крест", "OLL",
        "PLL", "Узоры"};

    private void Awake()
    {
        _buttonsPlace = buttonsPlace;
        _buttonPrefab = buttonPrefab;
        _algPlace = algPlace;
    }
    public static void SetButts()
    {
        if (_buttonsPlace.childCount == 0)
        { 
            Destroy(ShowAlg.activeAlg);
            for (int i = 0; i < 6; i++)
            {
                var installed = Instantiate(_buttonPrefab, _buttonsPlace, false);
                installed.GetComponentInChildren<TextMeshProUGUI>().text = titles[i];
                if (i == 5) 
                {
                    installed.GetComponent<ShowAlg>().algIndex = -1;
                }
                else
                {
                    installed.GetComponent<ShowAlg>().algIndex += i;
                }
                buttons.Add(installed);
            }
        }
        else
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                Destroy(buttons[i]);
            }
        }
    }

}
