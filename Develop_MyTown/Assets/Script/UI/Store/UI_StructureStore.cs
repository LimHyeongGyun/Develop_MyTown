using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StructureStore : MonoBehaviour, IUI_Boolean
{
    void Update()
    {
        
    }
    public void ToggleValue(bool isOn)
    {
        gameObject.GetComponent<Toggle>().isOn = isOn;
    }
}
