using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bankUI;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Bank에 플레이어 데이터 전달
                Bank bank = FindObjectOfType<Bank>();
                bank.playerData = FindObjectOfType<PlayerData>();

                //BankUI 생성
                GameObject bankUI = Instantiate(this.bankUI);
                bankUI.transform.parent = GameObject.Find("SystemCanvas").transform;
                bankUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 300f, 0f);
            }
        }
    }
}
