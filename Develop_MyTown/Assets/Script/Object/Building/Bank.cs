using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public PlayerData playerData;
    private int loan; //대출금

    //대출하기
    public void BorrowMoney()
    {

    }
    //대출금 상환
    public void RepayMoney()
    {

    }

    //신용등급 체크
    public int CheckCraditrating()
    {
        return playerData.curCraditRating;
    }

    //한도 체크하기
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