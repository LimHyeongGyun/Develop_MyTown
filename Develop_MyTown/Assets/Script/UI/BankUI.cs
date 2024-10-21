using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class BankUI : Singleton<BankUI>
{
    private static BankUI instance = null;

    private GameDataUI gameDataUI;
    private Bank bank;

    [SerializeField]
    private Text dialogueText;
    [SerializeField]
    private Text moneyText;

    [SerializeField]
    private GameObject borrowBtn;
    [SerializeField]
    private GameObject repayBtn;
    [SerializeField]
    private GameObject cancelBtn;

    [SerializeField]
    private GameObject inputMoneyObj; //������ �ݾ� �Է� ��ư �׷�

    private int moneyAmount; //���� �ݾ�
    private int borrowLimit; //���Ⱑ���ѵ�

    private string borrow;
    private string repay;
    private string cancel;
    [SerializeField]
    private string work;

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

        bank = FindObjectOfType<Bank>();
        gameDataUI = FindObjectOfType<GameDataUI>();
    }
    private void Start()
    {
        Init();
    }
    
    private void Init()
    {
        inputMoneyObj.SetActive(false);

        borrow = "Start";
        repay = "Start";
        cancel = "Start";
        work = null;

        string dialogue = $"�ȳ��ϼ��� ��ä���� {bank.playerData.villageName}���Դϴ�.\n" +
            $"������ ���͵帱���?";
        dialogueText.DOText(dialogue, 1.5f);

        borrowBtn.SetActive(true);
        repayBtn.SetActive(true);
        cancelBtn.SetActive(true);

        borrowBtn.GetComponentInChildren<Text>().text = "�����ϱ�";
        repayBtn.GetComponentInChildren<Text>().text = "����� ��ȯ";
        cancelBtn.GetComponentInChildren<Text>().text = "������";
    }

    //�����ϱ�
    public void BorrowMoney()
    {
        work = "Borrow";
        borrowLimit = bank.CheckCreditLimit() - bank.playerData.debt;
        if (borrowLimit >= 0)
            borrowLimit = bank.CheckCreditLimit() - bank.playerData.debt;
        else if (borrowLimit <= 0)
            borrowLimit = 0;

        if (borrow == "Start")
        {
            borrow = "Ing";
            dialogueText.text = $"player���� ���� �ſ� ����� {bank.CheckCraditrating().ToString()}����̿���!\n" +
            $"player���� �ѵ��� {bank.CheckCreditLimit()}����̰�, {borrowLimit} ��� �� ���� �� �־��\n" +
            $"���� �ص帱���?";

            borrowBtn.SetActive(true);
            repayBtn.SetActive(false);
            cancelBtn.SetActive(true);

            borrowBtn.GetComponentInChildren<Text>().text = "�����ϱ�";
        }
        else if (borrow == "Ing")
        {
            borrow = "End";

            inputMoneyObj.SetActive(true);
            moneyText.text = "0";

            dialogueText.text = "�󸶳� ������ �帱���?\n" +
                "(�ݾ��� �Է����ּ���)";
        }
        else if (borrow == "End")
        {
            borrowBtn.SetActive(false);
            inputMoneyObj.SetActive(false);

            bank.playerData.debt += moneyAmount;
            bank.playerData.gold += moneyAmount;

            gameDataUI.ChangeGold(bank.playerData.gold); //UI���� ����

            dialogueText.text = $"{moneyAmount}��� ���� �Ǿ����ϴ�. ���� �̿����ּ���!";
        }
    }

    //���� ���� ��Ȳ
    public void RepayMoney()
    {
        work = "Repay";
        cancelBtn.SetActive(true);

        if (repay == "Start")
        {
            repay = "Ing";
            if (bank.playerData.debt > 0)
            {
                borrowBtn.SetActive(false);
                repayBtn.SetActive(true);

                dialogueText.text = $"player���� ���� ������� {bank.playerData.debt}��忡��.";

                repayBtn.GetComponentInChildren<Text>().text = "����� ��ȯ�ϱ�";
            }
            else
            {
                borrowBtn.SetActive(true);
                repayBtn.SetActive(false);

                dialogueText.text = $"Player���� ���� ������ �����!\n" +
                    $"���� �ص帱���?";
                borrowBtn.GetComponentInChildren<Text>().text = "���� �ϱ�";
            }
        }
        else if (repay == "Ing")
        {
            repay = "End";
            inputMoneyObj.SetActive(true);
            moneyText.text = "0";

            dialogueText.text = $"�󸶸� ��ȯ�Ͻðھ��?" +
                $"(�ݾ��� �Է��� �ּ���)";
        }
        else if (repay == "End")
        {
            inputMoneyObj.SetActive(false);

            repayBtn.SetActive(false);

            bank.playerData.gold -= moneyAmount; //���� ����ŭ ����
            bank.playerData.debt -= moneyAmount; //���� �� ����

            gameDataUI.ChangeGold(bank.playerData.gold); //UI���� ����

            dialogueText.text = $"{moneyAmount}��常ŭ ������� ��ȯ �Ǿ����ϴ�. ������ {bank.playerData.debt}��� ���ҽ��ϴ�." +
                $"���� �̿����ּ���!";
        }
    }

    public void Cancel()
    {
        if (cancel == "Start")
        {
            cancel = "End";
            dialogueText.text = $"������ �� �̿����ּ���!\n";

            borrowBtn.SetActive(false);
            repayBtn.SetActive(false);
            cancelBtn.SetActive(true);
            inputMoneyObj.SetActive(false);
        }
        else if (cancel == "End")
        {
            Destroy(gameObject);
        }
    }

    //���� �ݾ� ��ư
    public void AmountOfMoney(int amount)
    {
        if (amount == 0)
        {
            moneyAmount = 0;
        }
        else if (amount == -100)
        {
            moneyAmount -= 100;
            if (moneyAmount <= 0)
            {
                moneyAmount = 0;
            }
        }
        else if (amount == 100)
        {
            moneyAmount += amount;
            if (work == "Borrow")
            {
                if (moneyAmount >= borrowLimit)
                {
                    moneyAmount = borrowLimit;
                }
            }
            else if (work == "Repay")
            {
                //������尡 ������ ���� ��
                if (bank.playerData.gold >= bank.playerData.debt)
                {
                    //�ݾ��� ������ ���ٸ�
                    if (moneyAmount > bank.playerData.debt)
                    {
                        moneyAmount = bank.playerData.debt;
                    }
                }
                //���� ��尡 ������ ������
                else if (bank.playerData.gold < bank.playerData.debt)
                {
                    if (moneyAmount > bank.playerData.gold)
                    {
                        moneyAmount = bank.playerData.gold;
                    }
                }
            }
        }
        else if (amount == 1)
        {
            if (work == "Borrow")
            {
                //���� �� �ִ� �Ѱ�
                moneyAmount = borrowLimit;
            }
            else if (work =="Repay")
            {
                //������ ���� ���� ���� ��
                if (bank.playerData.gold >= bank.playerData.debt)
                {
                    moneyAmount = bank.playerData.debt;
                }
                //������ ���� ���� ���� ��
                else if (bank.playerData.gold < bank.playerData.debt)
                {
                    moneyAmount = bank.playerData.gold;
                }
            }
        }
        moneyText.text = moneyAmount.ToString();
    }
}
