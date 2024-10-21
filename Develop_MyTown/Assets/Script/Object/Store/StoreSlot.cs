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

        //������ �� �ִ� ����� ���� ��
        if (playerData.gold >= structureInfo.needGold)
        {
            Craft craft = FindObjectOfType<Craft>();
            craft.CreatePreviewObject(structureInfo);

            //�����޴� �����
            gameObject.GetComponentInParent<StoreUI>().ToggleValue(false);
            UIManager uiManager = FindObjectOfType<UIManager>();
            uiManager.ToggleVerticalMenu(gameObject.GetComponentInParent<StoreUI>().gameObject);
        }
        //����� �����ؼ� ������ �� ���� ��
        else if (playerData.gold < structureInfo.needGold)
        {
            StoreUI storeUI = FindObjectOfType<StoreUI>();
            GameObject warningObj = Instantiate(storeUI.warningUI);
            warningObj.transform.parent = GameObject.Find("SystemCanvas").gameObject.transform; //����ĵ���� ������ ����
            warningObj.GetComponent<RectTransform>().anchoredPosition = Vector3.zero; //ĵ������ �߾ӿ� ��ġ�ϵ��� �ʱ�ȭ
            warningObj.GetComponent<WarningUI>().WarningText("�ܾ��� �����մϴ�."); //���� �Է��ϱ�
        }
    }
}