using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
    //InputType
    #region Keyboard
    public enum InputKeyType
    {
        Up,
        Down,
        Press
    }
    public enum KeyValue
    {
        None,
        Left,
        Right,
        Up,
        Down
    }
    #endregion

    #region Mouse
    public enum InputMouseType
    {
        None,
        Up,
        Down,
        Drag,
        Press
    }
    public enum MouseWheelValue
    {
        None,
        Up,
        Down,
    }
    #endregion
    //PlayerStateType
    #region Player
    public enum MoveState
    {
        Idle,
        Front,
        Back,
        Left,
        Right
    }
    public enum PlayerState
    {
        None,
        Move,
        interaction,
        Action
    }
    #endregion

    #region Ground
    public enum GroundType
    {
        Site,
        Ban
    }
    #endregion
    //StructureType
    #region ���๰
    public enum BuildMode
    {
        Observe,
        Build
    }
    public enum StructureManagement
    {
        None,
        Move,
        Store
    }
    //�ǹ� Ÿ��
    public enum StructureType
    {
        House,
        Production,
        Curtural,
        Sculpture
    }
    //��������
    public enum OperateType
    {
        None,
        Operate,
        Stop
    }
    public enum ConstructState
    {
        None,
        Construct,
        Completion
    }
    #endregion

    #region UI
    //UI Ÿ��
    public enum UIType
    {
        dynamicUI,
        staticUI,
    }
    //��� UI����
    public enum UIDirectionType
    {
        None,
        Appear,
        Left,
        Right,
        Up,
        Down
    }
    #endregion
}
