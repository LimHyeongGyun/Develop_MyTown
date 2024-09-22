using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static StateManager;

public class CameraController : MonoBehaviour, IMouseInput
{
    private InputManager inputManager;

    public MouseWheelValue mouseWheelValue;

    public Transform cameraObj; //카메라 오브젝트
    public Transform characterBody; //플레이어 몸

    //카메라 offset
    [SerializeField]
    private float camera_dist = 0f;
    private float camera_width = -5.5f;
    private float camera_height = 8f;

    private const float cameraRotateX = 35;

    Vector3 offset;

    //카메라 Zoom In/Out
    public const float dragSpeed = 200;
    public const float minZoomValue = 5;
    public const float maxZoomValue = 90;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
    }
    private void Start()
    {
        CameraRotation();
        offset = cameraObj.position - characterBody.position;

        inputManager.mouseAction += InputMouseValue;
    }
    void LateUpdate()
    {
        CameraPosition();
        ZoomInOut();
    }

    private void CameraPosition()
    {
        cameraObj.localPosition = characterBody.position + offset; //플레이어와 일정간격 유지
    }
    private void CameraRotation()
    {
        transform.rotation = Quaternion.Euler(cameraRotateX, 0, 0);
    }
    
    //마우스 입력값 받기
    public void InputMouseValue(MouseButton mouseBtn, InputMouseType inputType)
    {
        if (inputType == InputMouseType.None)
        {
            if (mouseBtn == MouseButton.Middle)
            {
                mouseWheelValue = MouseWheelValue.None;
            }
        }
        if (inputType == InputMouseType.Up)
        {

        }
        if (inputType == InputMouseType.Down)
        {

        }
        if (inputType == InputMouseType.Drag)
        {
            if (mouseBtn == MouseButton.Middle)
            {
                Vector2 wheelvalue = Input.mouseScrollDelta;
                if (wheelvalue.y > 0)
                {
                    mouseWheelValue = MouseWheelValue.Up;
                }
                if (wheelvalue.y < 0)
                {
                    mouseWheelValue = MouseWheelValue.Down;
                }
            }
        }
    }

    private void ZoomInOut()
    {
        //카메라 줌인/아웃
        if (mouseWheelValue == MouseWheelValue.Up)
        {
            var zoomValue = cameraObj.GetComponent<Camera>().fieldOfView;
            if (minZoomValue < zoomValue)
            {
                zoomValue -= dragSpeed * Time.deltaTime;
                if (zoomValue < minZoomValue)
                {
                    zoomValue = minZoomValue;
                }
                cameraObj.GetComponent<Camera>().fieldOfView = zoomValue;
            }
        }
        if (mouseWheelValue == MouseWheelValue.Down)
        {
            var zoomValue = cameraObj.GetComponent<Camera>().fieldOfView;
            if (zoomValue < maxZoomValue)
            {
                zoomValue += dragSpeed * Time.deltaTime;
                if (zoomValue > maxZoomValue)
                {
                    zoomValue = maxZoomValue;
                }
                cameraObj.GetComponent<Camera>().fieldOfView = zoomValue;
            }
        }
    }
    //줌 배율 원래상태로 변경
    public void ReturnZoomValue()
    {
        cameraObj.GetComponent<Camera>().fieldOfView = 60f;
    }
}
