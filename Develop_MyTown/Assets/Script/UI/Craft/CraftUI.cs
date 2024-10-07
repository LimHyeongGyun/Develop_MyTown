using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftUI : MonoBehaviour
{
    [HideInInspector]
    public GameObject structureObj;
    [HideInInspector]
    public Vector3 structurePos;
    [HideInInspector]
    public StructureSO structureSO;
    public GameObject previewObj;

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
        if (previewObj.transform.rotation == Quaternion.Euler(0f, 90f, 0f))
        {
            previewObj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //정방향 일때 시계방향 회전시키기
        else if (previewObj.transform.rotation == Quaternion.Euler(0f, 0f, 0f))
        {
            previewObj.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    //버튼으로 건축 확정하기
    public void DecideConstruction()
    {
        //건축물 생성하기
        GameObject structure = Instantiate(structureObj, structurePos, Quaternion.identity);
        structure.transform.rotation = previewObj.transform.rotation;
        structure.GetComponent<Structure>().Init(structureSO);

        //프리뷰 오브젝트 제거하기
        previewObj.GetComponent<PreviewStructure>().DestroyPreview();

        //StoreUI Active시키기
        ui_Store.ToggleValue(true);
        uiManager.ToggleVerticalMenu(ui_Store.gameObject);        

        //Craft UI 제거
        Destroy(this.gameObject);
    }
    //버튼으로 건축 취소하기
    public void CancelConstruction()
    {
        //프리뷰 오브젝트 제거하기
        previewObj.GetComponent<PreviewStructure>().DestroyPreview();

        //StoreUI Active시키기
        ui_Store.ToggleValue(true);
        uiManager.ToggleVerticalMenu(ui_Store.gameObject);

        //Craft UI 제거
        Destroy(this.gameObject);
    }
}
