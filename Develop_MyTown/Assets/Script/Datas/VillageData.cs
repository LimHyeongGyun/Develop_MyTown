using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class VillageData : Singleton<VillageData>
{
    private static VillageData instance = null;

    [SerializeField]
    private SaveJsonData json;
    [SerializeField]
    private GameDataUI gameDataUI;

    public int infrastructureFigure;
    public Dictionary<Structure, Vector3> structureDB = new Dictionary<Structure, Vector3>();

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
        string pLoadPath = Path.Combine(Application.dataPath, "VillageData.json");
        //����� �÷��̾� �����Ͱ� �ִٸ� �ҷ�����
        if (File.Exists(pLoadPath))
        {
            json.LoadVillageDataFromJason(pLoadPath);
            Debug.Log("Load Village Data");
        }
        gameDataUI.ChangeInfraFigure(infrastructureFigure);
    }

    //�������ġ
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