using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    [SerializeField]
    private StoreCategoryUI[] TypeBtns;

    public GameObject warningImg;

    private void Start()
    {
        SetupList();
    }
    public void SetupList()
    {
        TypeBtns = gameObject.GetComponentsInChildren<StoreCategoryUI>();
        for (int i = 1; i < TypeBtns.Length; i++)
        {
            TypeBtns[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    //다른 버튼으로 isOn값 조절에 사용
    public void ToggleValue(bool isOn)
    {
        //UI 토글이 닫힐 때 메뉴순서가 리셋 되는 것을 보이지 않게 하기 위해
        //열릴 때 리셋돼서 보이도록 if문 추가
        if (isOn)
        {
            ActiveTypeMenu(TypeBtns[0].gameObject);
        }
        gameObject.GetComponent<Toggle>().isOn = isOn;
    }

    //상점 메뉴 클릭시
    public void ActiveTypeMenu(GameObject Type)
    {
        foreach (StoreCategoryUI type in TypeBtns)
        {
            //전체 메뉴  끄기
            type.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        //클릭한 UI메뉴만 켜지도록
        Type.transform.GetChild(0).gameObject.SetActive(true);
    }
}
