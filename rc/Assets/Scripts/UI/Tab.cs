using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
    public List<GameObject> panels = new List<GameObject>();
    public static List<GameObject> Panels = new List<GameObject>();
    public Transform tabPlace;
    public static Transform TabPlace;

    private void Awake()
    {
        TabPlace = tabPlace;
        Panels = panels;
    }
}
