using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private const int highRating = 1; //최고 신용등급
    private const int lowRating = 10; //최저 신용등급

    public int gold; //소지금
    public int debt = 100000; //빚
    public int curCraditRating = 8;//플레이어 현재 신용등급

    public void IncreaseGold(int gold)
    {
        this.gold += gold;
    }
    public void DecreaseGold(int gold)
    {
        this.gold -= gold;
    }
}
