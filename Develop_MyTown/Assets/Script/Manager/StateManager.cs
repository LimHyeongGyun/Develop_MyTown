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
    #region 건축물
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
    //건물 타입
    public enum StructureType
    {
        House,
        Production,
        Curtural,
        Sculpture
    }
    //가동상태
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
    //UI 타입
    public enum UIType
    {
        dynamicUI,
        staticUI,
    }
    //토글 UI방향
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
