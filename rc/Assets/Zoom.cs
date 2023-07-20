using UnityEngine;

public class Zoom : MonoBehaviour
{
    public void ZoomIn()
    {
        CameraMovement.CameraObj.transform.localPosition = new Vector3(0,0, CameraMovement.CameraObj.transform.position.z + 1);
    }
    public void ZoomOut()
    {
        CameraMovement.CameraObj.transform.localPosition = new Vector3(0, 0, CameraMovement.CameraObj.transform.position.z -1);

    }
}
