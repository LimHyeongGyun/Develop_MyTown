using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCategoryUI : MonoBehaviour
{
    public Dictionary<int, StructureSO> structureDB = new Dictionary<int, StructureSO>();

    [SerializeField]
    private StateManager.StructureType type;
    [SerializeField]
    private int numberOfCategorie;
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private StoreSlot slot;
    private StoreSlot[] slots;

    private string dataPath;
    void Start()
    {
        Init();
    }

    private void Init()
    {
        LoadStructureData();
        CreateSlot();
    }
    //데이터 불러오기
    private void LoadStructureData()
    {
        if (type == StateManager.StructureType.Production)
        {
            dataPath = "ScriptableObject/Store/Production";
        }
        else if (type == StateManager.StructureType.Curtural)
        {
            dataPath = "ScriptableObject/Store/Curtural";
        }
        else if (type == StateManager.StructureType.Sculpture)
        {
            dataPath = "ScriptableObject/Store/Sculpture";
        }

        foreach (StructureSO structureSO in Resources.LoadAll<StructureSO>(dataPath))
        {
            structureDB.Add(structureSO.structureId, structureSO);
        }
    }
    private void CreateSlot()
    {
        //설정한 갯수만큼 슬롯생성
        for (int i = 0; i < numberOfCategorie; i++)
        {
            StoreSlot slot = Instantiate(this.slot); //설정한 갯수만큼 슬롯 생성
            slot.transform.SetParent(content.transform); //content의 자식으로 생성
        }
        SetSlot();
    }

    private void SetSlot()
    {
        //슬롯을 관리하기위해 배열에 저장
        slots = content.GetComponentsInChildren<StoreSlot>();

        //슬롯에 Id 순서대로 StructureDB의 데이터 가져다주기
        for (int i = 0; i < slots.Length; i++)
        {
            structureDB.TryGetValue(i, out slots[i].structureInfo);
        }
    }
}
