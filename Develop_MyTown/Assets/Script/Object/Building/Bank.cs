using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public PlayerData playerData;
    private int loan; //�����

    //�����ϱ�
    public void BorrowMoney()
    {

    }
    //����� ��ȯ
    public void RepayMoney()
    {

    }

    //�ſ��� üũ
    public int CheckCraditrating()
    {
        return playerData.curCraditRating;
    }

    //�ѵ� üũ�ϱ�
    public int CheckCreditLimit()
    {
        switch (playerData.curCraditRating)
        {
            case 1:
                loan = 0;
                break;
            case 2:
                loan = 0;
                break;
            case 3:
                loan = 0;
                break;
            case 4:
                loan = 0;
                break;
            case 5:
                loan = 0;
                break;
            case 6:
                loan = 0;
                break;
            case 7:
                loan = 0;
                break;
            case 8:
                loan = 1000;
                break;
            case 9:
                loan = 0;
                break;
            case 10:
                loan = 0;
                break;
        }

        return loan;
    }
}