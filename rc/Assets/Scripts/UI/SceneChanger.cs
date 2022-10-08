using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneChanger : MonoBehaviour
{
    public static GameObject gameScene;
	[SerializeField] private GameObject _gameScene;
    public static GameObject infoScene;
	[SerializeField] private GameObject _infoScene;
    public static GameObject menuScene;
    [SerializeField] private GameObject _settingsScene;
    public static GameObject settingsScene;
	[SerializeField] private GameObject _menuScene;
	public static GameObject lessonsMenuScene;
	public static GameObject activeScene;
	[SerializeField] private GameObject _lessonsMenuScene;
    public static Transform scenePlace;
	[SerializeField] private Transform _scenePlace;
    public GameObject cube;
    public static GameObject Cube;

    private void Awake()
    {
        infoScene = _infoScene;
        menuScene = _menuScene;
        gameScene = _gameScene;
        settingsScene = _settingsScene;
        lessonsMenuScene = _lessonsMenuScene;
        scenePlace = _scenePlace;
        Cube = cube;

        Cube.gameObject.SetActive(false);
        Instantiate(menuScene, scenePlace, false);
    }
    public static void MoveToAnotherScene(GameObject scene)
    {
        activeScene = Instantiate(scene, scenePlace, false);
    }

}
