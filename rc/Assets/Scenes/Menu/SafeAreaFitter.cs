using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaFitter : MonoBehaviour
{
    private void Awake()
    {
        var rectTransform = GetComponent<RectTransform>();
        var safeArea = Screen.safeArea;
        var AnchorMin = safeArea.position;
        var AnchorMax = AnchorMin + safeArea.size;

        AnchorMin.x /= Screen.width;
        AnchorMin.y /= Screen.height;
        AnchorMax.x /= Screen.width;
        AnchorMax.y /= Screen.height;

        rectTransform.anchorMin = AnchorMin;
        rectTransform.anchorMax = AnchorMax;
    }
}
