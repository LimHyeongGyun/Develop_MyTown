using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimeFunction : MonoBehaviour
{
    [SerializeField]
    private GameDataUI gameDataUI;

    private const int timeRatio = 48;//�ð� ����: ���ǿ��� 30���� ���� �ȿ��� �Ϸ簡 �ǵ���
    private int month; //��
    private int date; //��
    private int hour; //��
    private int minute; //��
    private float second; //��

    private string timeZone; //�ð���
    private string season;//����

    //�ð���
    private int[] dawn = new int[] { 3, 4, 5 }; //�����ð�
    private int[] morning = new int[] { 6, 7, 8, 9, 10, 11 }; //��ħ�ð�
    private int[] dayTime = new int[] { 12, 13, 14, 15, 16 }; //���ð�
    private int[] evening = new int[] { 17, 18, 19, 20 }; //����ð�
    private int[] night = new int[] { 21, 22, 23, 0, 1, 2 }; //��ð�

    //4������ �ش��ϴ� �� �迭�� ����
    private int[] spring = new int[] { 3, 4, 5 }; //��
    private int[] summer = new int[] { 6, 7, 8 }; //����
    private int[] fall = new int[] { 9, 10, 11 }; //����
    private int[] winter = new int[] { 12, 1, 2 }; //�ܿ�

    private void Start()
    {
        month = 3;
        date = 1;
        hour = 7;
        minute = 00;

        gameDataUI.ChangeTime(month, date, hour, minute);
        ChangTimeZone();
        ChangeSeason();
    }

    private void Update()
    {
        GameTime();
    }

    private void RealTime()
    {

    }
    private void GameTime()
    {
        second += Time.deltaTime; //���� �ð����� ����ؼ�

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
                        if (month == 2) //2���� 28�ϱ���
                        {
                            month += 1;
                            date = 1;
                        }
                    }
                    else if (date == 31) //4 6 9 11���� 30�ϱ���
                    {
                        if (month == 4 || month == 6 || month == 9 || month == 11)
                        {
                            month += 1;
                            date = 1;
                        }
                    }
                    else if (date == 32) //1 3 5 7 8 10 12���� 31�ϱ���
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
            gameDataUI.ChangeTime(month, date, hour, minute);
        }
    }


    private void ChangTimeZone()
    {
        if (dawn.Contains<int>(hour)) //3�ú��� 5�� 59��
        {
            timeZone = "����";
        }
        else if (morning.Contains<int>(hour)) //6�ú��� 11�� 59��
        {
            timeZone = "��ħ";
        }
        else if (dayTime.Contains<int>(hour)) //12�ú��� 16�� 59��
        {
            timeZone = "��";
        }
        else if (evening.Contains<int>(hour)) //17�ú��� 20�� 59��
        {
            timeZone = "����";
        }
        else if (night.Contains<int>(hour)) //21�ú��� ���� 02�� 59��
        {
            timeZone = "��";
        }
        gameDataUI.ChangeTimeZoneData(timeZone);
    }
    private void ChangeSeason()
    {
        if (spring.Contains<int>(month))
        {
            season = "��";
        }
        else if (summer.Contains<int>(month))
        {
            season = "����";
        }
        else if (fall.Contains<int>(month))
        {
            season = "����";
        }
        else if (winter.Contains<int>(month))
        {
            season = "�ܿ�";
        }
        gameDataUI.ChangeSeasonData(season);
    }
}
