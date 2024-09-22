using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StateManager;

public interface IKeyInput
{
    void InputKeyValue(KeyCode keyCode, InputKeyType inputType);
    
}
