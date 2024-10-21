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

    private const int highRating = 1; //�ְ� �ſ���
    private const int lowRating = 10; //���� �ſ���

    public string villageName;//�����̸�
    public int gold; //������
    public int debt = 1000; //��
    public int curCraditRating = 8;//�÷��̾� ���� �ſ���

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
        //����� �÷��̾� �����Ͱ� �ִٸ� �ҷ�����
        if (File.Exists(pLoadPath))
        {
            json.LoadPlayerDataFromJason(pLoadPath);
            Debug.Log("Load Player Data");
        }
        gameDataUI.ChangeGold(gold);
    }

    //��� ���
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

    //�� ���
    public void IncreaseDebt(int debt)
    {
        this.debt += debt;
    }
    public void DecreaseDebt(int debt)
    {
        this.debt -= debt;
    }
}
