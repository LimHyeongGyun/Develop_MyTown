using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData : Singleton<PlayerData>
{
    private static PlayerData instance = null;

    [SerializeField]
    private SaveJsonData json;
    [SerializeField]
    private GameDataUI gameDataUI;

    private const int highRating = 1; //최고 신용등급
    private const int lowRating = 10; //최저 신용등급

    public string villageName;//마을이름
    public int gold; //소지금
    public int debt = 1000; //빚
    public int curCraditRating = 8;//플레이어 현재 신용등급

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

    private void Start()
    {
        gold = debt;
        string pLoadPath = Path.Combine(Application.dataPath, "PlayerData.json");
        //저장된 플레이어 데이터가 있다면 불러오기
        if (File.Exists(pLoadPath))
        {
            json.LoadPlayerDataFromJason(pLoadPath);
            Debug.Log("Load Player Data");
        }
        gameDataUI.ChangeGold(gold);
    }

    //골드 계산
    public void IncreaseGold(int gold)
    {
        this.gold += gold;
        gameDataUI.ChangeGold(gold);
    }
    public void DecreaseGold(int gold)
    {
        this.gold -= gold;
        gameDataUI.ChangeGold(gold);
    }

    //빚 계산
    public void IncreaseDebt(int debt)
    {
        this.debt += debt;
    }
    public void DecreaseDebt(int debt)
    {
        this.debt -= debt;
    }
}
