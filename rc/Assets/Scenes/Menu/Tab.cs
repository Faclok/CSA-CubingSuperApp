using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tab : MonoBehaviour
{
    public GameObject cube;
    public static GameObject Cube;

    public List<GameObject> panels = new List<GameObject>();
    public static List<GameObject> Panels = new List<GameObject>();

    public List<TabButton> buttons = new List<TabButton>();
    public static List<TabButton> Buttons = new List<TabButton>();

    public Transform tabPlace;
    public static Transform TabPlace;

    public static TMP_FontAsset unpressedFont;
    public  TMP_FontAsset _unpressedFont;

    public static TMP_FontAsset pressedFont;
    public TMP_FontAsset _pressedFont;

    private void Awake()
    {
        Cube = cube;
        pressedFont = _pressedFont;
        unpressedFont = _unpressedFont;
        Buttons = buttons;
        TabPlace = tabPlace;
        Panels = panels;
    }
}
