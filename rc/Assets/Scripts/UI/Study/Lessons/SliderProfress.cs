
using UnityEngine;
using UnityEngine.UI;

public class SliderProfress : MonoBehaviour
{
    public static Slider lessonProgress;
    public Slider _lessonProgress;
    public RectTransform contentTrans;

    private void Awake()
    {
        lessonProgress = _lessonProgress;
        lessonProgress.maxValue = 0;
        lessonProgress.minValue = contentTrans.rect.yMax;
    }
    public void OnValueChanged()
    {
        lessonProgress.value = contentTrans.rect.y;
    }
}
