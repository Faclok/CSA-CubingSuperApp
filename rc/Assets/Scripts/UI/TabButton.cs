using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabButton : MonoBehaviour
{
    public int buttonIndex;

    public static GameObject activeTab;

    [SerializeField] private Sprite pressedSprite;
    [SerializeField] private Sprite unpressedSprite;

    [SerializeField] private TextMeshProUGUI iconTitle;
    [SerializeField] private Image icon;

    private TabButton button;
    private void Awake()
    {
        button = gameObject.GetComponent<TabButton>();
    }
    public void OnClick()
    {
        if (activeTab != null && activeTab.name == Tab.Panels[buttonIndex].name + "(Clone)" && GameButtons.settings == null)
        {
            return;
        }
        if (CubeManager.canShuffle && CubeManager.canRotate)
        {
            for (int i = 0; i < Tab.TabPlace.transform.childCount; i++)
            {
                Destroy(activeTab);
            }
            activeTab = Instantiate(Tab.Panels[buttonIndex], Tab.TabPlace);
            foreach (var but in Tab.Buttons) 
            {
                but.icon.sprite = but.unpressedSprite;
                but.iconTitle.font = Tab.unpressedFont;
            }
            
            button.icon.sprite = pressedSprite;
            button.iconTitle.font = Tab.pressedFont;
        }
    }
   
}
