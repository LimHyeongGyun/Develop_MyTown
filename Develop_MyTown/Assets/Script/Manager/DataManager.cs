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
    public SaveJsonData json;

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

    //플레이어 데이터 저장
    public void SavePlayerData()
    {
        json.playerDB.playerGold = playerData.gold;
        json.playerDB.playerDebt = playerData.debt;
        json.playerDB.playerCradintRating = playerData.curCraditRating;

        json.SavePlayerDataAsJason();
    }

    public void SaveVillageData()
    {
        json.villageDB.infraFigure = villageData.infrastructureFigure;
        json.villageDB.structureDB = villageData.structureDB;
        json.SaveVillageDataAsJason();
    }

    //데이터 로드
    public void LoadPlayerData()
    {
        playerData.gold = json.playerDB.playerGold;
        playerData.debt = json.playerDB.playerDebt;
        playerData.curCraditRating = json.playerDB.playerCradintRating;
    }
    public void LoadVillageData()
    {
        villageData.infrastructureFigure = json.villageDB.infraFigure;
    }

    private void OnApplicationQuit()
    {
        SavePlayerData();
        SaveVillageData();
    }
}
