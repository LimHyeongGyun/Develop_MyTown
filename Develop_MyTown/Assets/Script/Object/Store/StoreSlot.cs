using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSlot : MonoBehaviour
{
    public StructureSO structureInfo;

    public int id;
    [SerializeField]
    private Text needGold;
    [SerializeField]
    private Text structureName;

    public void SelectSlot()
    {
        PlayerData playerData = FindAnyObjectByType<PlayerData>();

        //구매할 수 있는 재산이 있을 때
        if (playerData.gold >= structureInfo.needGold)
        {
            Craft craft = FindObjectOfType<Craft>();
            craft.CreatePreviewObject(structureInfo);

            //상점메뉴 숨기기
            gameObject.GetComponentInParent<StoreUI>().ToggleValue(false);
            UIManager uiManager = FindObjectOfType<UIManager>();
            uiManager.ToggleVerticalMenu(gameObject.GetComponentInParent<StoreUI>().gameObject);
        }
        //재산이 부족해서 구매할 수 없을 때
        else if (playerData.gold < structureInfo.needGold)
        {
            StoreUI storeUI = FindObjectOfType<StoreUI>();
            GameObject warningObj = Instantiate(storeUI.warningUI);
            warningObj.transform.parent = GameObject.Find("MainCanvas").gameObject.transform; //메인캔버스 하위에 생성
            warningObj.GetComponent<RectTransform>().anchoredPosition = Vector3.zero; //캔버스의 중앙에 위치하도록 초기화
            warningObj.GetComponent<WarningUI>().WarningText("잔액이 부족합니다."); //정보 입력하기
        }
    }
}