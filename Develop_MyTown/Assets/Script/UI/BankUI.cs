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
    private GameObject inputMoneyObj; //대출할 금액 입력 버튼 그룹

    private int moneyAmount; //대출 금액
    private int borrowLimit; //대출가능한도

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

        string dialogue = $"안녕하세요 사채은행 {bank.playerData.villageName}점입니다.\n" +
            $"무엇을 도와드릴까요?";
        dialogueText.DOText(dialogue, 1.5f);

        borrowBtn.SetActive(true);
        repayBtn.SetActive(true);
        cancelBtn.SetActive(true);

        borrowBtn.GetComponentInChildren<Text>().text = "대출하기";
        repayBtn.GetComponentInChildren<Text>().text = "대출금 상환";
        cancelBtn.GetComponentInChildren<Text>().text = "나가기";
    }

    //대출하기
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
            dialogueText.text = $"player님의 현재 신용 등급은 {bank.CheckCraditrating().ToString()}등급이에요!\n" +
            $"player님의 한도는 {bank.CheckCreditLimit()}골드이고, {borrowLimit} 골드 더 빌릴 수 있어요\n" +
            $"대출 해드릴까요?";

            borrowBtn.SetActive(true);
            repayBtn.SetActive(false);
            cancelBtn.SetActive(true);

            borrowBtn.GetComponentInChildren<Text>().text = "대출하기";
        }
        else if (borrow == "Ing")
        {
            borrow = "End";

            inputMoneyObj.SetActive(true);
            moneyText.text = "0";

            dialogueText.text = "얼마나 대출해 드릴까요?\n" +
                "(금액을 입력해주세요)";
        }
        else if (borrow == "End")
        {
            borrowBtn.SetActive(false);
            inputMoneyObj.SetActive(false);

            bank.playerData.debt += moneyAmount;
            bank.playerData.gold += moneyAmount;

            gameDataUI.ChangeGold(bank.playerData.gold); //UI정보 변경

            dialogueText.text = $"{moneyAmount}골드 대출 되었습니다. 자주 이용해주세요!";
        }
    }

    //현재 대출 상황
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

                dialogueText.text = $"player님의 현재 대출금은 {bank.playerData.debt}골드에요.";

                repayBtn.GetComponentInChildren<Text>().text = "대출금 상환하기";
            }
            else
            {
                borrowBtn.SetActive(true);
                repayBtn.SetActive(false);

                dialogueText.text = $"Player님은 현재 대출이 없어요!\n" +
                    $"대출 해드릴까요?";
                borrowBtn.GetComponentInChildren<Text>().text = "대출 하기";
            }
        }
        else if (repay == "Ing")
        {
            repay = "End";
            inputMoneyObj.SetActive(true);
            moneyText.text = "0";

            dialogueText.text = $"얼마를 상환하시겠어요?" +
                $"(금액을 입력해 주세요)";
        }
        else if (repay == "End")
        {
            inputMoneyObj.SetActive(false);

            repayBtn.SetActive(false);

            bank.playerData.gold -= moneyAmount; //갚은 빚만큼 차감
            bank.playerData.debt -= moneyAmount; //남은 빚 차감

            gameDataUI.ChangeGold(bank.playerData.gold); //UI정보 변경

            dialogueText.text = $"{moneyAmount}골드만큼 대출금이 상환 되었습니다. 앞으로 {bank.playerData.debt}골드 남았습니다." +
                $"자주 이용해주세요!";
        }
    }

    public void Cancel()
    {
        if (cancel == "Start")
        {
            cancel = "End";
            dialogueText.text = $"다음에 또 이용해주세요!\n";

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

    //대출 금액 버튼
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
                //소지골드가 빚보다 많을 때
                if (bank.playerData.gold >= bank.playerData.debt)
                {
                    //금액이 빚보다 많다면
                    if (moneyAmount > bank.playerData.debt)
                    {
                        moneyAmount = bank.playerData.debt;
                    }
                }
                //소지 골드가 빚보다 적을때
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
                //빌릴 수 있는 한계
                moneyAmount = borrowLimit;
            }
            else if (work =="Repay")
            {
                //빚보다 가진 돈이 많을 때
                if (bank.playerData.gold >= bank.playerData.debt)
                {
                    moneyAmount = bank.playerData.debt;
                }
                //빚보다 가진 돈이 없을 때
                else if (bank.playerData.gold < bank.playerData.debt)
                {
                    moneyAmount = bank.playerData.gold;
                }
            }
        }
        moneyText.text = moneyAmount.ToString();
    }
}
