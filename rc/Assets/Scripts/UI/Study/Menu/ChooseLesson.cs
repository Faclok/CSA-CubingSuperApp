using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLesson : MonoBehaviour
{
    public int lessonIndex;
    public List<GameObject> lessons = new List<GameObject>();

    public void MoveToLessonScene()
    {
        Instantiate(lessons[lessonIndex], SceneChanger.scenePlace, false);
        Destroy(SceneChanger.activeScene);
    }
}
