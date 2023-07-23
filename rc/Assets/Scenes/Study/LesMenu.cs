using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LesMenu : MonoBehaviour
{
    public Transform buttonsPlace;

    public GameObject buttonPrefab;
    private List<string> titles = new List<string>() { "���� 1: ��� ��� �����?", "���� 2: ���� ��������", "���� 3: ����� �����", "���� 4: ����� �������",
        "���� 5: ������ ����", "���� 6: OLL �����", "���� 7: OLL �������", "���� 8: PLL", "���� 9: �����" };

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
