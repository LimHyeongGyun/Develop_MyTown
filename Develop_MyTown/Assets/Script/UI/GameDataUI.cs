using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//VillageData�� PlayerData�� �����͸� �޾� UI�� ǥ�����ִ� ���
public class GameDataUI : Singleton<GameDataUI>
{
    private static GameDataUI instance = null;

    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text timeZoneText;
    [SerializeField]
    private Text seasonText;

    [SerializeField]
    private Text infraDataText;
    [SerializeField]
    private Text goldDataaText;

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
        
    }

    private void Update()
    {
        
    }

    public void ChangeGold(int gold)
    {
        goldDataaText.text = gold.ToString();
    }

    public void ChangeInfraFigure(int infraFigure)
    {
        infraDataText.text = infraFigure.ToString();
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