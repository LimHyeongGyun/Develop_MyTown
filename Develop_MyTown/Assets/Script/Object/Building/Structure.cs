using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public StructureSO structureInfo;

    public void Init(StructureSO structureSO)
    {
        structureInfo = structureSO;
        gameObject.transform.localScale = 
            new Vector3(structureInfo.structureSizeX, structureInfo.structureSizeY, structureInfo.structureSizeZ);

        //플레이어 데이터에서 건축비용 차감하기
        PlayerData playerData = FindObjectOfType<PlayerData>();
        playerData.gold -= structureInfo.needGold; //건축비용 차감
    }
}
