using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : Singleton<PlayerData>
{
    private static PlayerData instance = null;

    [SerializeField]
    private GameDataUI gameDataUI;

    private const int highRating = 1; //최고 신용등급
    private const int lowRating = 10; //최저 신용등급

    public int gold; //소지금
    public int debt = 100000; //빚
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
        gameDataUI.ChangeGold(gold);
    }

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
}
