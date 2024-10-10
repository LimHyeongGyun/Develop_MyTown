using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageData : MonoBehaviour
{
    public int infrastructureFigure;

    public void IncreaseInfraFigure(int figure)
    {
        infrastructureFigure += figure;
    }
    public void DecreaseInfraFigure(int figure)
    {
        infrastructureFigure -= figure;
    }
}