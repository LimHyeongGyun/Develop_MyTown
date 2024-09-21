using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action<KeyCode, StateManager.InputKeyType, StateManager.PlayerState> keyAction;
    private void Start()
    {
        keyAction = null;
    }
    void Update()
    {
        InputValue();
    }

    public void InputValue()
    {
        //입력이 있는 경우
        if (keyAction != null)
        {
            #region KeyDown
            if (Input.GetKeyDown(KeyCode.Space))
                keyAction.Invoke(KeyCode.Space, StateManager.InputKeyType.Down, StateManager.PlayerState.Action);
            if (Input.GetKeyDown(KeyCode.F))
                keyAction.Invoke(KeyCode.F, StateManager.InputKeyType.Down, StateManager.PlayerState.interaction);
            #endregion

            #region KeyUp
            if (Input.GetKeyUp(KeyCode.LeftArrow))
                keyAction.Invoke(KeyCode.LeftArrow, StateManager.InputKeyType.Up, StateManager.PlayerState.None);
            if (Input.GetKeyUp(KeyCode.RightArrow))
                keyAction.Invoke(KeyCode.RightArrow, StateManager.InputKeyType.Up, StateManager.PlayerState.None);
            if (Input.GetKeyUp(KeyCode.UpArrow))
                keyAction.Invoke(KeyCode.UpArrow, StateManager.InputKeyType.Up, StateManager.PlayerState.None);
            if (Input.GetKeyUp(KeyCode.DownArrow))
                keyAction.Invoke(KeyCode.DownArrow, StateManager.InputKeyType.Up, StateManager.PlayerState.None);

            if (Input.GetKeyUp(KeyCode.Space))
                keyAction.Invoke(KeyCode.Space, StateManager.InputKeyType.Up, StateManager.PlayerState.None);
            #endregion

            #region Press
            if (Input.GetKey(KeyCode.LeftArrow))
                keyAction.Invoke(KeyCode.LeftArrow, StateManager.InputKeyType.Press, StateManager.PlayerState.Move);
            if (Input.GetKey(KeyCode.RightArrow))
                keyAction.Invoke(KeyCode.RightArrow, StateManager.InputKeyType.Press, StateManager.PlayerState.Move);
            if (Input.GetKey(KeyCode.UpArrow))
                keyAction.Invoke(KeyCode.UpArrow, StateManager.InputKeyType.Press, StateManager.PlayerState.Move);
            if (Input.GetKey(KeyCode.DownArrow))
                keyAction.Invoke(KeyCode.DownArrow, StateManager.InputKeyType.Press, StateManager.PlayerState.Move);
            #endregion
        }
    }
}
