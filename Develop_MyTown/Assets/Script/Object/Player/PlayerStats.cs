using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private const int setHp = 3; //시작HP
    private const int maxHp = 5; //최대HP
    private const int highRating = 1; //최고 신용등급
    private const int lowRating = 10; //최저 신용등급

    public int curHp; //현재HP
    public float speed = 10; //이동속도
    public int curCraditRating; //현재 신용등급

    public void InitStats()
    {
        curHp = setHp;
        curCraditRating = lowRating;
    }
}