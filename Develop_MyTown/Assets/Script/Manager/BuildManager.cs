using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public StateManager.BuildMode buildMode;

    public Action<StateManager.BuildMode> modeAction;

    private void Update()
    {
        
    }

    //건설기능 버튼으로 사용
    public void ChangeBuildMode()
    {
        if (buildMode == StateManager.BuildMode.Observe)
        {
            buildMode = StateManager.BuildMode.Build;
        }
        else if (buildMode == StateManager.BuildMode.Build)
        {
            buildMode = StateManager.BuildMode.Observe;
        }

        if (modeAction != null)
        {
            modeAction.Invoke(buildMode);
        }
    }

    private void BuildMode()
    {
        //Build 상태로 변경
        if (buildMode == StateManager.BuildMode.Build)
        {

        }
        //Obseve상태로 변경
        else if (buildMode == StateManager.BuildMode.Observe)
        {

        }
    }
}