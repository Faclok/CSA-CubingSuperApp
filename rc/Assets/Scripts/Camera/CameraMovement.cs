using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    Vector3 localRotation;
	bool CameraDisabled = false,
		 RotateDisabled = false;
	public CubeManager CubeMan;
	List<GameObject> pieces = new List<GameObject>(),
					 planes = new List<GameObject>();
    public static int cameraSpeed;
    void LateUpdate () {
		if (Input.GetMouseButton (0)) {


			if (!RotateDisabled) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit, 100)) {
					
					CameraDisabled = true;

					if (pieces.Count < 2 && !pieces.Exists(x => x == hit.collider.transform.parent.gameObject) && hit.transform.parent.gameObject != CubeMan.gameObject) 
					{
						pieces.Add (hit.collider.transform.parent.gameObject);
						planes.Add (hit.collider.gameObject);
					} else if (pieces.Count == 2) {
						CubeMan.DetectRotate (pieces, planes);
						RotateDisabled = true;
					}
						
				}
		
			}
			if (!CameraDisabled )
			{
				RotateDisabled = true;
                if (Input.touchCount == 1)
                {
                    Input.GetTouch(0);

                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        if (Mathf.Round(localRotation.y/180)%2 != 0)
                        {
                            localRotation.x += Input.GetTouch(0).deltaPosition.x * -9 * cameraSpeed * Time.deltaTime; ;
                        }
                        else if (Mathf.Round(localRotation.y / 180) % 2 == 0)
                        {
                            localRotation.x += Input.GetTouch(0).deltaPosition.x * 9 * cameraSpeed * Time.deltaTime; ;
                        }
                        localRotation.y += Input.GetTouch(0).deltaPosition.y * -9 * cameraSpeed * Time.deltaTime;
                       // localRotation.y = Mathf.Clamp(localRotation.y, -36000, 36000);


                    }
                }

            }

        } 
		else if (Input.GetMouseButtonUp (0)) 
		{
			pieces.Clear();
			planes.Clear();
			CameraDisabled = RotateDisabled = false;
		
		}
		Quaternion qt = Quaternion.Euler (localRotation.y, localRotation.x, 0);
		transform.parent.rotation = Quaternion.Lerp (transform.parent.rotation, qt, Time.deltaTime * 15);
	}

}
