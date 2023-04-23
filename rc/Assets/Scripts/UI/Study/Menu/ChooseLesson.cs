using System.Collections.Generic;
using UnityEngine;

public class ChooseLesson : MonoBehaviour
{
    public int lessonIndex;
    public List<GameObject> lessons = new List<GameObject>();

    public void MoveToLessonScene()
    {
        for (int i = 0; i < Tab.TabPlace.transform.childCount; i++)
        {
            Destroy(Tab.TabPlace.transform.GetChild(i).gameObject);
        }
        Instantiate(lessons[lessonIndex], Tab.TabPlace, false);
        //Destroy(SceneChanger.activeScene);
    }
}
