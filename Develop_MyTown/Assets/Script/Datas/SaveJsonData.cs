using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayerDataBase
{
    public int playerGold;
    public int playerDebt;
    public int playerCradintRating;
}
[System.Serializable]
public class VillageDataBase
{
    public int infraFigure;

    public Dictionary<Structure, Vector3> structureDB = new Dictionary<Structure, Vector3>();
}
public class SaveJsonData : MonoBehaviour
{
    public PlayerDataBase playerDB;
    public VillageDataBase villageDB;

    public void SavePlayerDataAsJason()
    {
        string playerJsonData = JsonUtility.ToJson(playerDB, true);
        //데이터 저장 경로
        string pSavePath = Path.Combine(Application.dataPath, "PlayerData.json");
        //기존에 저장된 파일이 있다면 삭제
        if (File.Exists(pSavePath))
        {
            File.Delete(pSavePath);
        }

        File.WriteAllText(pSavePath, playerJsonData);
    }
    public void SaveVillageDataAsJason()
    {
        string villageJsonData = JsonUtility.ToJson(villageDB, true);
        //데이터 저장 경로
        string vSavePath = Path.Combine(Application.dataPath, "VillageData.json");
        //기존에 저장된 파일이 있다면 삭제
        if (File.Exists(vSavePath))
        {
            File.Delete(vSavePath);
        }

        File.WriteAllText(vSavePath, villageJsonData);
    }

    public void LoadPlayerDataFromJason(string pLoadPath)
    {
        //파일의 텍스트를 string으로 저장
        string jsonData = File.ReadAllText(pLoadPath);

        playerDB = JsonUtility.FromJson<PlayerDataBase>(jsonData);

        DataManager dataManager = FindObjectOfType<DataManager>();
        dataManager.LoadPlayerData();
    }
    public void LoadVillageDataFromJason(string vLoadPath)
    {
        //파일의 텍스트를 string으로 저장
        string jsonData = File.ReadAllText(vLoadPath);

        villageDB = JsonUtility.FromJson<VillageDataBase>(jsonData);

        DataManager dataManager = FindObjectOfType<DataManager>();
        dataManager.LoadVillageData();
    }
}
