using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static StateManager;

public interface IKeyInput
{
    void InputKeyValue(KeyCode keyCode, InputKeyType inputType);
    
}
public interface IMouseInput
{
    void InputMouseValue(MouseButton mouseBtn, InputMouseType inputType);
}
