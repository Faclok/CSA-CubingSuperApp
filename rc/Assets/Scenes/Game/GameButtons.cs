using UnityEngine;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject settingsPrefab;
    [SerializeField] private GameObject tipsPrefab;
    public static GameObject settings;
    public Transform prefabPlace;
    public void OpenSettings()
    {

        if (CubeManager.canShuffle && CubeManager.canRotate)
        {
            settings = Instantiate(settingsPrefab, prefabPlace);
        }
    }
    public void OpenTips()
    {
        CubeManager.DoScramble("U' L2 F2 D' L' D U2 R U' R' U2 R2 U F' L' U R'", 1);
    }
    public void ShuffleCube()
    {
        if (CubeManager.canRotate)
        {
            CubeManager.Shuffle1();
        }
    }
    public void ReCreateCube()
    {
        if (CubeManager.canShuffle && CubeManager.canRotate)
        {
            CubeCreator.CreateCube();
        }
    }
}
