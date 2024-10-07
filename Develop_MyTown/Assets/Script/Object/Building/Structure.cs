using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Structure : MonoBehaviour
{
    private Harvest harvest;

    public StructureSO structureInfo;
    public StateManager.ConstructState constructState;
    public StateManager.OperateType operateType;

    [SerializeField]
    private GameObject harvestUi;

    public float buildTime;
    public float productionTime;
    public int output;

    private void Awake()
    {
        harvest = FindObjectOfType<Harvest>();
    }

    private void Update()
    {
        if (constructState == StateManager.ConstructState.Construct)
        {
            ConstructTimer();
        }
        else if(constructState == StateManager.ConstructState.Completion && structureInfo.structureType == StateManager.StructureType.Production)
        {
            ProductTimer();
        }
    }

    public void Init(StructureSO structureSO)
    {
        structureInfo = structureSO; //건축물 정보 받기
        gameObject.transform.localScale = 
            new Vector3(structureInfo.structureSizeX, structureInfo.structureSizeY, structureInfo.structureSizeZ); //건축물 크기 초기화

        //플레이어 데이터에서 건축비용 차감하기
        PlayerData playerData = FindObjectOfType<PlayerData>();
        playerData.gold -= structureInfo.needGold; //건축비용 차감

        constructState = StateManager.ConstructState.Construct;
        operateType = StateManager.OperateType.None;

        buildTime = structureInfo.buildTime; //건축시간 초기화
        productionTime = structureInfo.productionTime; //생산시간 초기화
        output = structureInfo.output; //생산량 초기화
    }

    private void ConstructTimer()
    {
        if (constructState == StateManager.ConstructState.Construct)
        {
            buildTime -= Time.deltaTime;
            if (buildTime <= 0)
            {
                constructState = StateManager.ConstructState.Completion;
                if (constructState == StateManager.ConstructState.Completion)
                {
                    if (structureInfo.structureType == StateManager.StructureType.Production)
                    {
                        operateType = StateManager.OperateType.Operate;
                    }
                    else if (structureInfo.structureType == StateManager.StructureType.Curtural || structureInfo.structureType == StateManager.StructureType.Sculpture)
                    {
                        operateType = StateManager.OperateType.None;
                    }
                }
            }
        }
    }

    private void ProductTimer()
    {
        productionTime -= Time.deltaTime;
        if (productionTime <= 0)
        {
            output += structureInfo.outputPerMinute; //생산물 적립
            productionTime = structureInfo.productionTime; //생산시간 초기화

            if (output >= structureInfo.harvestableOutput) //수확가능한 생산량 이상일때
            {
                if (!harvest.productionStructure.Contains(this))
                {
                    harvest.productionStructure.Add(this);
                    harvest.harvestable = true;
                    harvest.ActiveButton();
                }
                if (output >= structureInfo.maxOutput) //최대 수확량을 넘었을 때
                {
                    operateType = StateManager.OperateType.Stop; //생산 중지
                    output = structureInfo.maxOutput; //생산량을 최대 생산량으로 바꿈
                    productionTime = structureInfo.productionTime; //생산시간 초기화
                }
            }
        }
    }
}
