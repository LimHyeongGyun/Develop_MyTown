using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StateManager;

public class PlayerController : MonoBehaviour, IKeyInput
{
    private InputManager inputManager;
    public MoveState moveState;
    public InputKeyType inputKeyType;

    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        inputManager = FindObjectOfType<InputManager>();
    }
    void Start()
    {
        inputManager.keyAction += InputKeyValue;
    }

    void Update()
    {
        
    }

    public void InputKeyValue(KeyCode keyCode, InputKeyType inputType, PlayerState playerState)
    {
        //KeyDown
        #region KeyDown
        if (inputType == InputKeyType.Down)
        {
            //플레이어 상호작용 키
            if (keyCode == KeyCode.F)
            {
                
            }

            //플레이어 액션 키
            if (keyCode == KeyCode.Space)
            {
                
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
                moveState = MoveState.Idle;
            }
        }
        #endregion
        //Key
        #region Stay
        if (inputType == InputKeyType.Press)
        {
            //플레이어 이동 키
            if (keyCode == KeyCode.LeftArrow)
            {
                moveState = MoveState.Left;
            }
            else if (keyCode == KeyCode.RightArrow)
            {
                moveState = MoveState.Right;
            }
            else if (keyCode == KeyCode.UpArrow)
            {
                moveState = MoveState.Front;
            }
            else if (keyCode == KeyCode.DownArrow)
            {
                moveState = MoveState.Back;
            }
        }
        #endregion
    }

    private void Move()
    {
        if (moveState == MoveState.Idle)
        {
            transform.position = Vector3.zero;
        }
        if (moveState == MoveState.Front)
        {

        }
        if (moveState == MoveState.Back)
        {

        }
        if (moveState == MoveState.Left)
        {

        }
        if (moveState == MoveState.Right)
        {

        }
    }
}
