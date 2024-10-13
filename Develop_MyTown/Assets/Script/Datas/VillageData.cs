using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageData : Singleton<VillageData>
{
    private static VillageData instance = null;

    [SerializeField]
    private GameDataUI gameDataUI;

    public int infrastructureFigure;

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
    }
    private void Start()
    {
        gameDataUI.ChangeInfraFigure(infrastructureFigure);
    }

    public void IncreaseInfraFigure(int figure)
    {
        infrastructureFigure += figure;
        gameDataUI.ChangeInfraFigure(infrastructureFigure);
    }
    public void DecreaseInfraFigure(int figure)
    {
        infrastructureFigure -= figure;
        gameDataUI.ChangeInfraFigure(infrastructureFigure);
    }
}