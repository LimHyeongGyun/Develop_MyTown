using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private static DataManager instance = null;

    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private VillageData villageData;

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //�÷��̾� ������ ����
    private void SavePlayerData(int gold, int debt, int curCraditRating)
    {

    }

    private void SaveVillageData(int infrastructureFigure)
    {

    }

    //������ �ε�
    private void LoadPlayerData()
    {

    }
    private void LoadVillageData()
    {

    }

    private void OnApplicationQuit()
    {
        Debug.Log("��������");
    }
}
