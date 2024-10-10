using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataUI : MonoBehaviour
{
    private PlayerData playerData;
    private VillageData villageData;

    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text timeZoneText;
    [SerializeField]
    private Text seasonText;

    public float gold; //골드
    public float infrastructureFigure; //인프라수치

    protected virtual void Awake()
    {
        playerData = GetComponent<PlayerData>();
        villageData = GetComponent<VillageData>();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }

    public void ChangeTime(int month, int date, int hour, int minute)
    {
        timeText.text = $"{month, 0:D2}/{date,0:D2}\n{hour,0:D2}:{minute,0:D2}";
    }

    public void ChangeTimeZoneData(string timeZone)
    {
        timeZoneText.text = timeZone;
    }
    public void ChangeSeasonData(string season)
    {
        seasonText.text = season;
    }
}