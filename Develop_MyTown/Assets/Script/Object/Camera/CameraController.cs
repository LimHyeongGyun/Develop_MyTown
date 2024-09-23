using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour, IMouseInput
{
    private InputManager inputManager;
    private BuildManager buildManager;

    public StateManager.MouseWheelValue mouseWheelValue;

    public Transform cameraObj; //카메라 오브젝트
    public Transform characterBody; //플레이어 몸

    //카메라 offset
    [SerializeField]
    private float camera_dist = 0f;
    private float camera_width = -5.5f;
    private float camera_height = 8f;

    private const float observeRotateX = 35;
    private const float buildRotateX = 90;

    Vector3 observeOffset;
    Vector3 buildOffset;

    //카메라 Zoom In/Out
    public const float dragSpeed = 200;
    public const float minZoomValue = 5;
    public const float maxZoomValue = 90;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        buildManager = FindObjectOfType<BuildManager>();
    }
    private void Start()
    {
        observeOffset = cameraObj.position - characterBody.position;
        buildOffset = new Vector3(characterBody.transform.position.x, 30f, characterBody.transform.position.z);
        CameraRotation(StateManager.BuildMode.Observe);

        inputManager.mouseAction += InputMouseValue;
        buildManager.modeAction += CameraRotation;
    }
    void Update()
    {
        CameraPosition();
        ZoomInOut();
    }

    private void CameraPosition()
    {
        if (buildManager.buildMode == StateManager.BuildMode.Observe)
        {
            cameraObj.localPosition = characterBody.position + observeOffset; //플레이어와 일정간격 유지
        }
        else if (buildManager.buildMode == StateManager.BuildMode.Build)
        {
            //거리변경 => 맵사이즈 만큼으로 바꿀 것
            cameraObj.localPosition = new Vector3(0, 30f, 0);
        }
    }
    //건설모드에 따라 카메라 각도 변경
    private void CameraRotation(StateManager.BuildMode buildMode)
    {
        if (buildMode == StateManager.BuildMode.Observe)
        {
            transform.rotation = Quaternion.Euler(observeRotateX, 0, 0);
        }
        else if (buildMode == StateManager.BuildMode.Build)
        {
            //건설모드일 때 탑뷰로 변경
            transform.rotation = Quaternion.Euler(buildRotateX, 0, 0);
        }
    }
    
    //마우스 입력값 받기
    public void InputMouseValue(MouseButton mouseBtn, StateManager.InputMouseType inputType)
    {
        //입력이 없을 때
        if (inputType == StateManager.InputMouseType.None)
        {
            if (mouseBtn == MouseButton.Middle)
            {
                mouseWheelValue = StateManager.MouseWheelValue.None;
            }
        }
        //드래그 할 때
        if (inputType == StateManager.InputMouseType.Drag)
        {
            if (mouseBtn == MouseButton.Middle)
            {
                Vector2 wheelvalue = Input.mouseScrollDelta;
                if (wheelvalue.y > 0)
                {
                    mouseWheelValue = StateManager.MouseWheelValue.Up;
                }
                if (wheelvalue.y < 0)
                {
                    mouseWheelValue = StateManager.MouseWheelValue.Down;
                }
            }
        }
    }

    private void ZoomInOut()
    {
        //카메라 줌인/아웃
        if (mouseWheelValue == StateManager.MouseWheelValue.Up)
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
        if (mouseWheelValue == StateManager.MouseWheelValue.Down)
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
