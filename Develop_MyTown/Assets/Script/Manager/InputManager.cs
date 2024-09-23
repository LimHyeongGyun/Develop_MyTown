using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action<KeyCode, StateManager.InputKeyType> keyAction;
    public Action<MouseButton, StateManager.InputMouseType> mouseAction;

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
                keyAction.Invoke(KeyCode.Space, StateManager.InputKeyType.Down);
            if (Input.GetKeyDown(KeyCode.F))
                keyAction.Invoke(KeyCode.F, StateManager.InputKeyType.Down);
            #endregion

            #region KeyUp
            if (Input.GetKeyUp(KeyCode.LeftArrow))
                keyAction.Invoke(KeyCode.LeftArrow, StateManager.InputKeyType.Up);
            if (Input.GetKeyUp(KeyCode.RightArrow))
                keyAction.Invoke(KeyCode.RightArrow, StateManager.InputKeyType.Up);
            if (Input.GetKeyUp(KeyCode.UpArrow))
                keyAction.Invoke(KeyCode.UpArrow, StateManager.InputKeyType.Up);
            if (Input.GetKeyUp(KeyCode.DownArrow))
                keyAction.Invoke(KeyCode.DownArrow, StateManager.InputKeyType.Up);

            if (Input.GetKeyUp(KeyCode.Space))
                keyAction.Invoke(KeyCode.Space, StateManager.InputKeyType.Up);
            #endregion

            #region Press
            if (Input.GetKey(KeyCode.LeftArrow))
                keyAction.Invoke(KeyCode.LeftArrow, StateManager.InputKeyType.Press);
            if (Input.GetKey(KeyCode.RightArrow))
                keyAction.Invoke(KeyCode.RightArrow, StateManager.InputKeyType.Press);
            if (Input.GetKey(KeyCode.UpArrow))
                keyAction.Invoke(KeyCode.UpArrow, StateManager.InputKeyType.Press);
            if (Input.GetKey(KeyCode.DownArrow))
                keyAction.Invoke(KeyCode.DownArrow, StateManager.InputKeyType.Press);
            #endregion
        }

        if (mouseAction != null)
        {
            Vector2 wheelInput = Input.mouseScrollDelta;
            //마우스 휠을 드래그 했을 때
            if (wheelInput.y != 0)
                mouseAction.Invoke(MouseButton.Middle, StateManager.InputMouseType.Drag);
            if(wheelInput.y == 0)
                mouseAction.Invoke(MouseButton.Middle, StateManager.InputMouseType.None);
        }
    }
}
