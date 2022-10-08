using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowAlg : MonoBehaviour
{
    public static GameObject activeAlg;
    public int algIndex;
    public List<GameObject> algs = new List<GameObject>();
    private static List<string> titles = new List<string>() { "Вишенка", "Шахматы", "Кубы", "Зиг-Заг",
        "Змейка", "Уголок"};

    public void ShowAlgoritm()
    {
        for (int i = 0; i < TipsMenuScript.buttons.Count; i++)
        {
            Destroy(TipsMenuScript.buttons[i]);
        }
        Destroy(activeAlg);
        if (algIndex != -1) 
        {
            activeAlg = Instantiate(algs[algIndex], TipsMenuScript._algPlace, false);
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                var installed = Instantiate(TipsMenuScript._buttonPrefab, TipsMenuScript._buttonsPlace, false);
                installed.GetComponentInChildren<TextMeshProUGUI>().text = titles[i];
                installed.GetComponent<ShowAlg>().algIndex += i+5;
                TipsMenuScript.buttons.Add(installed);
            }
        }
        
    }
}
