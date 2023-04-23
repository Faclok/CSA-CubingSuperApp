using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneStart : MonoBehaviour
{
    private void Awake()
    {
        SceneChanger.Cube.gameObject.SetActive(true);
    }
}
