using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameTime : GameDataUI
{
    private const int timeRatio = 48;//시간 비율: 현실에서 30분이 게임 안에서 하루가 되도록
    private int month; //월
    private int date; //일
    private int hour; //시
    private int minute; //분
    private float second; //초

    private string timeZone; //시간대
    private string season;//계절

    //시간대
    private int[] dawn = new int[] { 3, 4, 5 }; //새벽시간
    private int[] morning = new int[] { 6, 7, 8, 9, 10, 11 }; //아침시간
    private int[] dayTime = new int[] { 12, 13, 14, 15, 16}; //낮시간
    private int[] evening = new int[] { 17, 18, 19, 20}; //저녁시간
    private int[] night = new int[] { 21, 22, 23, 0, 1, 2}; //밤시간

    //4계절에 해당하는 월 배열로 저장
    private int[] spring = new int[] { 3, 4, 5 }; //봄
    private int[] summer = new int[] { 6, 7, 8 }; //여름
    private int[] fall = new int[] { 9, 10, 11 }; //가을
    private int[] winter = new int[] { 12, 1, 2 }; //겨울

    protected override void Start()
    {
        month = 3;
        date = 1;
        hour = 7;
        minute = 00;
        ChangeTime(month, date, hour, minute);
        ChangTimeZone();
        ChangeSeason();
    }

    protected override void Update()
    {
        Timer();
    }

    private void Timer()
    {
        second += Time.deltaTime; //실제 시간으로 비례해서

        if (second >= 60 / timeRatio)
        {
            second = 0;
            minute += 1;
            if (minute >= 60)
            {
                minute = 0;
                hour += 1;
                if (hour == 24)
                {
                    date += 1;
                    hour = 0;
                    if (date == 29)
                    {
                        if (month == 2) //2월은 28일까지
                        {
                            month += 1;
                            date = 1;
                        }
                    }
                    else if (date == 31) //4 6 9 11월달 30일까지
                    {
                        if (month == 4 || month == 6 || month == 9 || month == 11)
                        {
                            month += 1;
                            date = 1;
                        }
                    }
                    else if (date == 32) //1 3 5 7 8 10 12월달 31일까지
                    {
                        if (month == 1 || month == 3 || month == 5 || month == 7
                        || month == 8 || month == 10 || month == 12)
                        {
                            if (month < 12)
                            {
                                month += 1;
                            }
                            else if (month == 12)
                            {
                                month = 1;
                            }
                            date = 1;
                        }
                    }
                    ChangeSeason();
                }
                ChangTimeZone();
            }
            ChangeTime(month, date, hour, minute);
        }
    }


    private void ChangTimeZone()
    {
        if (dawn.Contains<int>(hour)) //3시부터 5시 59분
        {
            timeZone = "새벽";
        }
        else if (morning.Contains<int>(hour)) //6시부터 11시 59분
        {
            timeZone = "아침";
        }
        else if (dayTime.Contains<int>(hour)) //12시부터 16시 59분
        {
            timeZone = "낮";
        }
        else if (evening.Contains<int>(hour)) //17시부터 20시 59분
        {
            timeZone = "저녁";
        }
        else if (night.Contains<int>(hour)) //21시부터 익일 02시 59분
        {
            timeZone = "밤";
        }
        ChangeTimeZoneData(timeZone);
    }
    private void ChangeSeason()
    {
        if (winter.Contains<int>(month))
        {
            season = "겨울";
        }
        else if (spring.Contains<int>(month))
        {
            season = "봄";
        }
        else if (summer.Contains<int>(month))
        {
            season = "여름";
        }
        else if (fall.Contains<int>(month))
        {
            season = "가을";
        }
        ChangeSeasonData(season);
    }
}
