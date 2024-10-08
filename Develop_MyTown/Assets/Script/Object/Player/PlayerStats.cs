using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private const int setHp = 3; //시작HP
    private const int maxHp = 5; //최대HP

    public int curHp; //현재HP
    public float speed = 10; //이동속도

    public void InitStats()
    {
        curHp = setHp;
    }
}