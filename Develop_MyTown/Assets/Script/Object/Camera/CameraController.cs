using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour, IMouseInput
{
    private InputManager inputManager;
    private BuildManager buildManager;

    public StateManager.MouseWheelValue mouseWheelValue;

    public Transform cameraObj; //ī�޶� ������Ʈ
    public Transform characterBody; //�÷��̾� ��

    //ī�޶� offset
    [SerializeField]
    private float camera_dist = 0f;
    private float camera_width = -5.5f;
    private float camera_height = 8f;

    public float observeRotateX = 15;
    private const float buildRotateX = 90;

    Vector3 observeOffset;
    Vector3 buildOffset;

    //ī�޶� Zoom In/Out
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
            cameraObj.localPosition = characterBody.position + observeOffset; //�÷��̾�� �������� ����
        }
        else if (buildManager.buildMode == StateManager.BuildMode.Build)
        {
            //�Ÿ����� => �ʻ����� ��ŭ���� �ٲ� ��
            cameraObj.localPosition = new Vector3(0, 30f, 0);
        }
    }
    //�Ǽ���忡 ���� ī�޶� ���� ����
    private void CameraRotation(StateManager.BuildMode buildMode)
    {
        if (buildMode == StateManager.BuildMode.Observe)
        {
            transform.rotation = Quaternion.Euler(observeRotateX, 0, 0);
        }
        else if (buildMode == StateManager.BuildMode.Build)
        {
            //�Ǽ������ �� ž��� ����
            transform.rotation = Quaternion.Euler(buildRotateX, 0, 0);
        }
    }
    
    //���콺 �Է°� �ޱ�
    public void InputMouseValue(MouseButton mouseBtn, StateManager.InputMouseType inputType)
    {
        //�Է��� ���� ��
        if (inputType == StateManager.InputMouseType.None)
        {
            if (mouseBtn == MouseButton.Middle)
            {
                mouseWheelValue = StateManager.MouseWheelValue.None;
            }
        }
        //�巡�� �� ��
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
        //ī�޶� ����/�ƿ�
        if (mouseWheelValue == StateManager.MouseWheelValue.Up)
        {
            if (buildManager.buildMode == StateManager.BuildMode.Observe)
            {
                observeRotateX = 35f;
                CameraRotation(StateManager.BuildMode.Observe);
            }
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
            if (buildManager.buildMode == StateManager.BuildMode.Observe)
            {
                observeRotateX = 35f;
                CameraRotation(StateManager.BuildMode.Observe);
            }
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
    //�� ���� �������·� ����
    public void ReturnZoomValue()
    {
        if (buildManager.buildMode == StateManager.BuildMode.Observe)
        {
            observeRotateX = 15f;
            CameraRotation(StateManager.BuildMode.Observe);
        }
        cameraObj.GetComponent<Camera>().fieldOfView = 60f;
    }
}
