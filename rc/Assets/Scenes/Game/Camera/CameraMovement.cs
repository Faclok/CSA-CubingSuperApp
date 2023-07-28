using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static Vector3 localRotation;
    bool CameraDisabled = false,
         RotateDisabled = false;
    public static Camera CameraObj;
    public Camera cameraObj;
    private CubeManager CubeMan;
    public static List<GameObject> pieces = new List<GameObject>(),
                     planes = new List<GameObject>();
    public static int cameraSpeed = 90;
    public static float cameraSpeedS = 45f;

    public CubicRubik CubicRubik;

    public float rotationSpeed = 5f;

    private Vector2 previousTouchPosition;
    private Vector2 currentTouchPosition;

    void Update()
    {
        // Проверяем, было ли касание экрана (или щелчок мыши)
        if (Input.touchCount > 0)
        {
            // Создаем луч, который исходит из позиции камеры и направлен в точку, на которую произошло нажатие
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            // Проверяем, пересек ли луч какой-либо коллайдер объектов в сцене
            if (Physics.Raycast(ray, out RaycastHit hit))
            {

                // Проверяем, если коллайдер принадлежит какому-либо GameObject, выполняем нужные действия
                if (hit.collider.gameObject != null && hit.collider.gameObject.TryGetComponent(out ClickObject click))
                {
                    click.Face.Rotation();
                }
            }
        }
        // Проверяем наличие касаний
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Обрабатываем касание
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    previousTouchPosition = touch.position;
                    break;

                case TouchPhase.Moved:
                    currentTouchPosition = touch.position;

                    // Вычисляем разницу между текущим и предыдущим положением касания
                    Vector2 touchDelta = currentTouchPosition - previousTouchPosition;

                    // Вычисляем угол поворота по оси X и Y
                    float rotationX = touchDelta.y * rotationSpeed * Time.deltaTime;
                    float rotationY = -touchDelta.x * rotationSpeed * Time.deltaTime;

                    // Применяем поворот к кубику относительно мировых координат
                    CubicRubik.transform.Rotate(rotationX, rotationY, 0f, Space.World);

                    // Сохраняем текущее положение касания в качестве предыдущего на следующем шаге
                    previousTouchPosition = currentTouchPosition;
                    break;

                case TouchPhase.Ended:
                    break;
            }
        }
    }

}
