using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Harvest : MonoBehaviour
{
    public List<Structure> productionStructure = new List<Structure>();
    private PlayerData playerData;
    public bool harvestable = false;

    private void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        ActiveButton();
    }

    public void ActiveButton()
    {
        Color colorA = gameObject.GetComponent<Image>().color;
        if (harvestable)
        {
            colorA.a = 1;
        }
        else if (!harvestable)
        {
            colorA.a = 0.5f;
        }
        gameObject.GetComponent<Image>().color = colorA;
    }

    public void HarvestTheProduce()
    {
        if (harvestable)
        {
            foreach (Structure production in productionStructure)
            {
                playerData.gold += production.output;//생산한 골드 더하기
                production.output = 0; //생산량 초기화
            }
            productionStructure.Clear();
            harvestable = false;
            ActiveButton();
        }
    }
}
