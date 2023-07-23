using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeAlgManager : MonoBehaviour
{
    public List<GameObject> allCubePieces = new List<GameObject>();
    private static List<GameObject> AllCubePieces = new List<GameObject>();

    public static Transform CubePlace;
    public Transform _CubePlace;

    private GameObject CubeCenterPiece;

    //static public CubeAlgManager cubeAlgManager;

    public GameObject cubeAlg;

    public static bool canRotate;
    public static int cubeSpeed = 10;

    private string[] movesArray;

    private int currId;

    private string currentAlg; 

    private List<GameObject> UpPieces
    {
        get
        {
            return allCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.y) == 0);
        }
    }
    private List<GameObject> DownPieces
    {
        get
        {
            return allCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.y) == -2);
        }
    }
    private List<GameObject> FrontPieces
    {
        get
        {
            return allCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.x) == 0);
        }
    }
    private List<GameObject> BackPieces
    {
        get
        {
            return allCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.x) == -2);
        }
    }
    private List<GameObject> LeftPieces
    {
        get
        {
            return allCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.z) == 0);
        }
    }
    private List<GameObject> RightPieces
    {
        get
        {
            return allCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.z) == 2);
        }
    }
    static List<GameObject> UpHorizontalPieces
    {
        get
        {
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.x) == -1);
        }
    }
    static List<GameObject> UpVerticalPieces
    {
        get
        {
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.z) == 1);
        }
    }
    static List<GameObject> FrontHorizontalPieces
    {
        get
        {
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.y) == -1);
        }
    }

    private void Update()
    {
        _CubePlace.position = new Vector3(cubeAlg.GetComponent<CubeAlg>()._cubePos.position.x, cubeAlg.GetComponent<CubeAlg>()._cubePos.position.y, cubeAlg.GetComponent<CubeAlg>()._cubePos.position.z-3);
        
    }
    private void Awake()
    {
        currentAlg = gameObject.GetComponentInParent<CubeAlg>().alg;
        CubePlace = _CubePlace;
        canRotate = true;
        AllCubePieces = allCubePieces;
        CubeCenterPiece = AllCubePieces[13];
        currId = 0;
        
        try
        {
            movesArray = currentAlg.Split(' ');
        }
        catch
        {
            movesArray.Append(currentAlg);
        }
    }

    private IEnumerator Rotate(List<GameObject> pieces, Vector3 rotationVec, int speed, int nAngle = 90)
    {
        canRotate = false;
        int angle = 0; 
        while (angle < nAngle)
        {
            foreach (GameObject go in pieces)
            {
                Debug.Log(CubeCenterPiece.transform.position);
                go.transform.RotateAround(CubeCenterPiece.transform.position, rotationVec, speed);
            }
            angle += speed;
            yield return null;
        }
        canRotate = true;
    }
    public IEnumerator Scramble(int cubeSpeed,int id, bool change)
    {
        canRotate = false;
        string move = movesArray[id];
        if (change && movesArray[id].Contains("'"))
        {
            move = movesArray[id].Replace("'", "");
        }
        else if (change && !movesArray[id].Contains("'") && !movesArray[id].Contains("2"))
        {
            move = movesArray[id] + "'";
        }
        if (move == "R")
        {
            yield return Rotate(RightPieces, new Vector3(0, 0, 1), cubeSpeed);
        }
        else if (move == "R'")
        {
            yield return Rotate(RightPieces, new Vector3(0, 0, -1), cubeSpeed);
        }
        else if (move == "R2")
        {
            yield return Rotate(RightPieces, new Vector3(0, 0, 1), cubeSpeed, 180);
        }
        else if (move == "U")
        {
            yield return Rotate(UpPieces, new Vector3(0, 1, 0), cubeSpeed);
        }   
        else if (move == "U'")
        {
            yield return Rotate(UpPieces, new Vector3(0, -1, 0), cubeSpeed);
        }
        else if (move == "U2")
        {
            yield return Rotate(UpPieces, new Vector3(0, 1, 0), cubeSpeed, 180);
        }
        else if (move == "L")
        {
            yield return Rotate(LeftPieces, new Vector3(0, 0, -1), cubeSpeed);
        }
        else if (move == "L'")
        {
            yield return Rotate(LeftPieces, new Vector3(0, 0, 1), cubeSpeed);
        }
        else if (move == "L2")
        {
            yield return Rotate(LeftPieces, new Vector3(0, 0, 1), cubeSpeed,180);
        }
        else if (move == "D")
        {
            yield return Rotate(DownPieces, new Vector3(0, -1, 0), cubeSpeed);
        }
        else if (move == "D'")
        {
            yield return Rotate(DownPieces, new Vector3(0, 1, 0), cubeSpeed);
        }
        else if (move == "D2")
        {
            yield return Rotate(DownPieces, new Vector3(0, 1, 0), cubeSpeed,180);
        }
        else if (move == "F")
        {
            yield return Rotate(FrontPieces, new Vector3(1, 0, 0), cubeSpeed);
        }
        else if (move == "F'")
        {
            yield return Rotate(FrontPieces, new Vector3(-1, 0, 0), cubeSpeed);
        }
        else if (move == "F2")
        {
            yield return Rotate(FrontPieces, new Vector3(1, 0, 0), cubeSpeed,180);
        }
        else if (move == "B")
        {
            yield return Rotate(BackPieces, new Vector3(-1, 0, 0), cubeSpeed);
        }
        else if (move == "B'")
        {
            yield return Rotate(BackPieces, new Vector3(1, 0, 0), cubeSpeed);
        }
        else if (move == "B2")
        {
            yield return Rotate(BackPieces, new Vector3(1, 0, 0), cubeSpeed,180);
        }
        canRotate = true;
    }
    public void DoNextMove()
    {
        if (currId <= currentAlg.Count(' ') && canRotate) 
        {
            StartCoroutine(Scramble(1, currId, false));
            currId += 1;
        }
    }
    public void DoPrevMove()
    {
        if (currId > 0 && canRotate)
        {
            StartCoroutine(Scramble(1, currId - 1, true));
            currId -= 1;
        }
    }
}
