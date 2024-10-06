using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftUI : MonoBehaviour
{
    [HideInInspector]
    public GameObject structureObj;
    private UIManager uiManager;
    private UI_Store ui_Store;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        ui_Store = FindObjectOfType<UI_Store>();
    }

    //설치 확정 이전 건물 방향 정하기
    public void RotateStructure()
    {
        //시계방향 일때 반시계 회전시키기
        if (structureObj.transform.rotation == Quaternion.Euler(0f, 90f, 0f))
        {
            structureObj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //정방향 일때 시계방향 회전시키기
        else if (structureObj.transform.rotation == Quaternion.Euler(0f, 0f, 0f))
        {
            structureObj.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    //버튼으로 건축 확정하기
    public void DecideConstruction()
    {
        ui_Store.ToggleValue(true);
        uiManager.ToggleVerticalMenu(ui_Store.gameObject);
        PlayerData playerData = FindObjectOfType<PlayerData>();
        playerData.gold -= structureObj.GetComponent<Structure>().structureInfo.needGold; //건축비용 차감

        Destroy(this.gameObject);
    }
    //버튼으로 건축 취소하기
    public void CancelConstruction()
    {
        ui_Store.ToggleValue(true);
        uiManager.ToggleVerticalMenu(ui_Store.gameObject);
        Destroy(structureObj); //건축하려던 건물 제거
        Destroy(this.gameObject); //UI 제거
    }
}
