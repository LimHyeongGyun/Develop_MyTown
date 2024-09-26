using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    public StateManager.BuildMode buildMode;

    public Action<StateManager.BuildMode> modeAction;

    //건설기능 버튼으로 사용
    public void ChangeBuildMode()
    {
        if (modeAction != null)
        {
            //빌드모드로 변경
            if (buildMode == StateManager.BuildMode.Observe)
            {
                buildMode = StateManager.BuildMode.Build;
            }
            //옵저버모드로 변경
            else if (buildMode == StateManager.BuildMode.Build)
            {
                buildMode = StateManager.BuildMode.Observe;
            }
            //카메라 컨트롤러의 모드 변경
            modeAction.Invoke(buildMode);
        }

        BuildMode();
    }

    private void BuildMode()
    {
        //Build 상태로 변경
        if (buildMode == StateManager.BuildMode.Build)
        {
            uiManager.menuBtn.GetComponent<Toggle>().isOn = false;
            uiManager.horizontalAction.Invoke(uiManager.menuBtn);
            uiManager.menuBtn.SetActive(false);
        }
        //Obseve상태로 변경
        else if (buildMode == StateManager.BuildMode.Observe)
        {
            uiManager.menuBtn.SetActive(true);
        }
    }
}