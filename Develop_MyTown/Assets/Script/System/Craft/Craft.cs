using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    private BuildManager buildManager;
    private StructureSO structureSO;

    [SerializeField]
    private GameObject craftUI; //생성할 UI오브젝트
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

            if (Input.GetMouseButtonDown(0) && previewObj.GetComponent<PreviewStructure>().IsBuildable())
            {
                FixPreviewPosition();
            }
        }
    }

    public void CreatePreviewObject(StructureSO structureInfo)
    {
        structureSO = structureInfo;
        previewObj = Instantiate(previewStructure, pos, Quaternion.identity);

        //프리뷰 상세 정보 변경
        Vector3 structureSize = new Vector3(structureSO.structureSizeX, structureSO.structureSizeY, structureSO.structureSizeZ); //프리뷰 오브젝트 사이즈

        previewObj.GetComponent<MeshFilter>().sharedMesh = structureSO.structureObj.GetComponent<MeshFilter>().sharedMesh; //프리뷰오브젝트 메쉬 변경
        previewObj.transform.localScale = structureSize; //프리뷰 크기
        previewObj.GetComponent<BoxCollider>().size = structureSize; //프리뷰 설치크기변경
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

    public void FixPreviewPosition()
    {
        Vector3 uiPos = new Vector3(previewObj.transform.position.x, 5, previewObj.transform.position.z);
        GameObject _craftUI = Instantiate(craftUI, uiPos, Quaternion.Euler(90f, 0f, 0f)); //설치와 회전을 결정할 UI오브젝트 생성

        //UI에 생성할 건물 정보 넘기기
        _craftUI.GetComponent<CraftUI>().structurePos = previewObj.transform.position; //preview 오브젝트 위치
        _craftUI.GetComponent<CraftUI>().previewObj = previewObj;
        _craftUI.GetComponent<CraftUI>().structureObj = structureSO.structureObj;
        _craftUI.GetComponent<CraftUI>().structureSO = structureSO;
        
        previewObj = null;
    }
}
