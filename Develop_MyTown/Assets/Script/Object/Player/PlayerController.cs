using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static StateManager;

public class PlayerController : MonoBehaviour, IKeyInput
{
    private CameraController camera;
    [SerializeField]
    private PlayerStats stats;

    private InputManager inputManager;
    public MoveState moveState;
    public PlayerState playerState;

    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        inputManager = FindObjectOfType<InputManager>();

        camera = FindObjectOfType<CameraController>();
    }
    void Start()
    {
        stats.InitStats();
        inputManager.keyAction += InputKeyValue;
    }

    void Update()
    {
        Move();
        Rotate();
    }

    public void InputKeyValue(KeyCode keyCode, InputKeyType inputType)
    {
        //KeyDown
        #region KeyDown
        if (inputType == InputKeyType.Down)
        {
            //플레이어 상호작용 키
            if (keyCode == KeyCode.F)
            {
                playerState = PlayerState.interaction;
            }

            //플레이어 액션 키
            if (keyCode == KeyCode.Space)
            {
                playerState = PlayerState.Action;
            }
        }
        #endregion
        //KeyUp
        #region KeyUp
        if (inputType == InputKeyType.Up)
        {
            if (keyCode == KeyCode.LeftArrow || keyCode == KeyCode.RightArrow
                || keyCode == KeyCode.UpArrow || keyCode == KeyCode.DownArrow)
            {
                playerState = PlayerState.None;
                moveState = MoveState.Idle;
            }
        }
        #endregion
        //Key
        #region Press
        if (inputType == InputKeyType.Press)
        {
            camera.ReturnToggleValue();
            //플레이어 이동 키
            if (keyCode == KeyCode.LeftArrow)
            {
                playerState = PlayerState.Move;
                moveState = MoveState.Left;
            }
            else if (keyCode == KeyCode.RightArrow)
            {
                playerState = PlayerState.Move;
                moveState = MoveState.Right;
            }
            else if (keyCode == KeyCode.UpArrow)
            {
                playerState = PlayerState.Move;
                moveState = MoveState.Front;
            }
            else if (keyCode == KeyCode.DownArrow)
            {
                playerState = PlayerState.Move;
                moveState = MoveState.Back;
            }
        }
        #endregion
    }

    private void Move()
    {
        if (moveState == MoveState.Idle)
        {
            transform.position = transform.position;
        }
        if (moveState == MoveState.Front)
        {
            transform.position += new Vector3(0, 0, 1) * stats.speed * Time.deltaTime;
        }
        if (moveState == MoveState.Back)
        {
            transform.position -= new Vector3(0, 0, 1) * stats.speed * Time.deltaTime;
        }
        if (moveState == MoveState.Left)
        {
            transform.position -= new Vector3(1, 0, 0) * stats.speed * Time.deltaTime;
        }
        if (moveState == MoveState.Right)
        {
            transform.position += new Vector3(1, 0, 0) * stats.speed * Time.deltaTime;
        }
    }
    private void Rotate()
    {
        if (moveState == MoveState.Idle)
        {
            transform.rotation = transform.rotation;
        }
        if (moveState == MoveState.Front)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (moveState == MoveState.Back)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        if (moveState == MoveState.Left)
        {
            transform.rotation = Quaternion.Euler(0, -90f, 0);
        }
        if (moveState == MoveState.Right)
        {
            transform.rotation = Quaternion.Euler(0, 90f, 0);
        }
    }
}
