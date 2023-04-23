using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabButton : MonoBehaviour
{
    public int buttonIndex;
    void Awake()
    {
        
    }
    public void OnClick()
    {
        if (CubeManager.canShuffle && CubeManager.canRotate)
        {
            for (int i = 0; i < Tab.TabPlace.transform.childCount; i++)
            {
                Destroy(Tab.TabPlace.transform.GetChild(i).gameObject);
            }
            Instantiate(Tab.Panels[buttonIndex], Tab.TabPlace);
            if (buttonIndex == 1)
            {
                SceneChanger.Cube.gameObject.SetActive(true);
            }
            else
            {
                SceneChanger.Cube.gameObject.SetActive(false);
            }
        }
    }
   
}
