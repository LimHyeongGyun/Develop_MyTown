using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerDataBase
{
    public int playerGold;
    public int playerDebt;
    public int playerCradintRating;
}
public class VillageDataBase
{
    public int infraFigure;

    Dictionary<Structure, Vector3> structureDB = new Dictionary<Structure, Vector3>();
}
public class SaveJsonData : MonoBehaviour
{
    public PlayerDataBase playerDB;
    public VillageDataBase villageDB;
    public void SavePlayerDataAsJason()
    {
        string playerJsonData = JsonUtility.ToJson(playerDB, true);
        //������ ���� ���
        string pSavePath = Path.Combine(Application.dataPath, "PlayerData.json");
        //������ ����� ������ �ִٸ� ����
        if (File.Exists(pSavePath))
        {
            File.Delete(pSavePath);
        }

        File.WriteAllText(pSavePath, playerJsonData);
    }
    public void SaveVillageDataAsJason()
    {
        string villageJsonData = JsonUtility.ToJson(villageDB, true);
        //������ ���� ���
        string vSavePath = Path.Combine(Application.dataPath, "VillageData.json");
        //������ ����� ������ �ִٸ� ����
        if (File.Exists(vSavePath))
        {
            File.Delete(vSavePath);
        }

        File.WriteAllText(vSavePath, villageJsonData);
    }

    public void LoadPlayerDataFromJason()
    {
        //������ �ҷ��� ���
        string pLoadPath = Path.Combine(Application.dataPath, "PlayerData.jason");
        //������ �ؽ�Ʈ�� string���� ����
        string jsonData = File.ReadAllText(pLoadPath);

        playerDB = JsonUtility.FromJson<PlayerDataBase>(jsonData);
    }
    public void LoadVillageDataFromJason()
    {
        string vLoadPath = Path.Combine(Application.dataPath, "VillageData.jason");
        //������ �ؽ�Ʈ�� string���� ����
        string jsonData = File.ReadAllText(vLoadPath);

        villageDB = JsonUtility.FromJson<VillageDataBase>(jsonData);
    }
}
