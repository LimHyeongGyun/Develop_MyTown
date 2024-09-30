using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    private BuildManager buildManager;

    [SerializeField]
    private GameObject previewStructure; //생성할 프리뷰 오브젝트
    private GameObject previewObj; //생성된 프리뷰 오브젝트

    private Vector3 viewPos;
    private Vector3 pos;

    private RaycastHit hit;

    void Awake()
    {
        buildManager = FindObjectOfType<BuildManager>();
    }

    void Update()
    {
        if (buildManager.buildMode == StateManager.BuildMode.Build && previewObj != null)
        {
            PreviewPositionUpdate();
        }
    }

    public void CreatePreviewObject(StructureSO structureInfo)
    {
        previewObj = Instantiate(previewStructure, pos, Quaternion.identity);
        previewObj.GetComponent<MeshFilter>().sharedMesh = structureInfo.structureObj.GetComponent<MeshFilter>().sharedMesh;
    }

    public void PreviewPositionUpdate()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            viewPos = Camera.main.WorldToViewportPoint(hit.point);
            pos = Camera.main.ViewportToWorldPoint(viewPos);

            previewObj.transform.position = new Vector3(pos.x, 0, pos.z);
        }
    }

    //버튼으로 건축 확정하기
    public void DecideConstruction()
    {

    }
    //버튼으로 건축 취소하기
    public void CancelConstruction()
    {

    }
}
