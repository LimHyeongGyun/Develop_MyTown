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
    }
}
