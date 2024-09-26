using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public Action<GameObject> horizontalAction;
    public Action<GameObject> verticalAction;

    public GameObject menuBtn;

    private void Start()
    {
        horizontalAction += ToggleHorizontalMenu;
        verticalAction += ToggleVerticalMenu;
    }
    //가로 Toggle UI
    public void ToggleHorizontalMenu(GameObject toggleBtn)
    {
        StateManager.UIDirectionType type = toggleBtn.GetComponent<UI_DefaultSet>().direction;
        //펼치기
        if (toggleBtn.GetComponent<Toggle>().isOn)
        {
            //오른쪽으로 펼치기
            if (type == StateManager.UIDirectionType.Right)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveX(toggleBtn.transform.position.x + Mathf.Abs(toggleBtn.transform.GetChild(0).position.x) * 2, 0.3f);
            }
            //왼쪽으로 펼치기
            else if (type == StateManager.UIDirectionType.Left)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveX(toggleBtn.transform.position.x - Mathf.Abs(toggleBtn.transform.GetChild(0).position.x) * 2, 0.3f);
            }            
        }
        //접기
        else if (!toggleBtn.GetComponent<Toggle>().isOn)
        {
            //오른방향으로 접기
            if (type == StateManager.UIDirectionType.Left)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveX(toggleBtn.transform.position.x + Mathf.Abs(toggleBtn.transform.GetChild(0).position.x) * 2, 0.3f);
            }
            //왼방향으로 접기
            else if (type == StateManager.UIDirectionType.Right)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveX(toggleBtn.transform.position.x - Mathf.Abs(toggleBtn.transform.GetChild(0).position.x) * 2, 0.3f);
            }
        }
    }

    //세로 Toggle UI
    public void ToggleVerticalMenu(GameObject toggleBtn)
    {
        StateManager.UIDirectionType type = toggleBtn.GetComponent<UI_DefaultSet>().direction;
        //펼치기
        if (toggleBtn.GetComponent<Toggle>().isOn)
        {
            //윗방향으로 펼치기
            if (type == StateManager.UIDirectionType.Up)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveY(toggleBtn.transform.position.y + Mathf.Abs(toggleBtn.transform.position.y) * 2, 0.3f);
            }
            //아랫방향으로 펼치기
            else if (type == StateManager.UIDirectionType.Down)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveY(toggleBtn.transform.position.y - Mathf.Abs(toggleBtn.transform.position.y) * 2, 0.3f);
            }
        }
        //접기
        else if (!toggleBtn.GetComponent<Toggle>().isOn)
        {
            //윗방향으로 접기
            if (type == StateManager.UIDirectionType.Down)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveY(toggleBtn.transform.position.y + Mathf.Abs(toggleBtn.transform.position.y) * 2, 0.3f);
            }
            //아랫방향으로 접기
            else if (type == StateManager.UIDirectionType.Up)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveY(toggleBtn.transform.position.y - Mathf.Abs(toggleBtn.transform.position.y) * 2, 0.3f);
            }
        }
    }
}