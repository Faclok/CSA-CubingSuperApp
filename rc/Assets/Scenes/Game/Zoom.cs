using UnityEngine;

public class Zoom : MonoBehaviour
{
    public void ZoomIn()
    {
        if (CameraMovement.CameraObj.transform.localPosition.z<-8) {
            CameraMovement.CameraObj.transform.localPosition = new Vector3(0, 0, CameraMovement.CameraObj.transform.localPosition.z + 1);
        }

    }
    public void ZoomOut()
    {
        if (CameraMovement.CameraObj.transform.localPosition.z > -14)
        {
            CameraMovement.CameraObj.transform.localPosition = new Vector3(0, 0, CameraMovement.CameraObj.transform.localPosition.z - 1);
        }
    }
}
