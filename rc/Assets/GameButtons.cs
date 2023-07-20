using UnityEngine;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject settingsPrefab;
    [SerializeField] private GameObject tipsPrefab;
    public static GameObject settings;
    public Transform prefabPlace;
    public void OpenSettings()
    {
        settings = Instantiate(settingsPrefab, prefabPlace);
    }
    public void OpenTips()
    {
        settings = Instantiate(settingsPrefab, prefabPlace);
    }
    public void ShuffleCube()
    {
        CubeManager.Shuffle1();
    }
    public void ReCreateCube()
    {
        CubeCreator.CreateCube();
    }
}
