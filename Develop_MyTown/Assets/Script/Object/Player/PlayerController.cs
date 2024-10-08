using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IKeyInput
{
    private InputManager inputManager;
    private CameraController cameraCon;
    [SerializeField]
    private PlayerStats stats;

    public StateManager.MoveState moveState;
    public StateManager.PlayerState playerState;

    private Rigidbody rigid;
    private Animator animator;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        inputManager = FindObjectOfType<InputManager>();
        cameraCon = FindObjectOfType<CameraController>();
    }
    void Start()
    {
        stats.InitStats();
        inputManager.keyAction += InputKeyValue;
    }

    void Update()
    {
        Move();
        Rotation();
    }

    public void InputKeyValue(KeyCode keyCode, StateManager.InputKeyType inputType)
    {
        //KeyDown
        #region KeyDown
        if (inputType == StateManager.InputKeyType.Down)
        {
            //플레이어 상호작용 키
            if (keyCode == KeyCode.F)
            {
                playerState = StateManager.PlayerState.interaction;
            }

            //플레이어 액션 키
            if (keyCode == KeyCode.Space)
            {
                playerState = StateManager.PlayerState.Action;
            }
        }
        #endregion
        //KeyUp
        #region KeyUp
        if (inputType == StateManager.InputKeyType.Up)
        {
            if (keyCode == KeyCode.LeftArrow || keyCode == KeyCode.RightArrow
                || keyCode == KeyCode.UpArrow || keyCode == KeyCode.DownArrow)
            {
                playerState = StateManager.PlayerState.None;
                moveState = StateManager.MoveState.Idle;
            }
            if (keyCode == KeyCode.F)
            {
                playerState = StateManager.PlayerState.None;
            }
        }
        #endregion
        //Key
        #region Press
        if (inputType == StateManager.InputKeyType.Press)
        {
            cameraCon.ReturnZoomValue();
            //플레이어 이동 키
            if (keyCode == KeyCode.LeftArrow)
            {
                playerState = StateManager.PlayerState.Move;
                moveState = StateManager.MoveState.Left;
            }
            else if (keyCode == KeyCode.RightArrow)
            {
                playerState = StateManager.PlayerState.Move;
                moveState = StateManager.MoveState.Right;
            }
            else if (keyCode == KeyCode.UpArrow)
            {
                playerState = StateManager.PlayerState.Move;
                moveState = StateManager.MoveState.Front;
            }
            else if (keyCode == KeyCode.DownArrow)
            {
                playerState = StateManager.PlayerState.Move;
                moveState = StateManager.MoveState.Back;
            }
        }
        #endregion
    }

    private void Move()
    {
        if (moveState == StateManager.MoveState.Idle)
        {
            transform.position = transform.position;
        }
        if (moveState == StateManager.MoveState.Front)
        {
            transform.position += new Vector3(0, 0, 1) * stats.speed * Time.deltaTime;
        }
        if (moveState == StateManager.MoveState.Back)
        {
            transform.position -= new Vector3(0, 0, 1) * stats.speed * Time.deltaTime;
        }
        if (moveState == StateManager.MoveState.Left)
        {
            transform.position -= new Vector3(1, 0, 0) * stats.speed * Time.deltaTime;
        }
        if (moveState == StateManager.MoveState.Right)
        {
            transform.position += new Vector3(1, 0, 0) * stats.speed * Time.deltaTime;
        }
    }
    private void Rotation()
    {
        if (moveState == StateManager.MoveState.Idle)
        {
            transform.rotation = transform.rotation;
        }
        if (moveState == StateManager.MoveState.Front)
        {
            transform.rotation = Quaternion.Euler(0, 0f, 0);
        }
        if (moveState == StateManager.MoveState.Back)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        if (moveState == StateManager.MoveState.Left)
        {
            transform.rotation = Quaternion.Euler(0, -90f, 0);
        }
        if (moveState == StateManager.MoveState.Right)
        {
            transform.rotation = Quaternion.Euler(0, 90f, 0);
        }
    }
}
