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
            gameObject.GetComponentInParent<UI_Store>().ToggleValue(false);
            UIManager uiManager = FindObjectOfType<UIManager>();
            uiManager.ToggleVerticalMenu(gameObject.GetComponentInParent<UI_Store>().gameObject);
        }
        //재산이 부족해서 구매할 수 없을 때
        else if (playerData.gold < structureInfo.needGold)
        {
            UI_Store storeUI = FindObjectOfType<UI_Store>();
            GameObject warningObj = Instantiate(storeUI.warningImg);
            warningObj.transform.position = Vector3.zero;
        }
    }
}
