using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StructureData", menuName = "ScriptableObject/Structure", order = 0)]
public class StructureSO : ScriptableObject
{
    //건축물 공통 요소
    public StateManager.StructureType structureType; //건물 타입
    public GameObject structureObj; //건물 오브젝트
    public Sprite structureImg; //건물 이미지
    public string structureName; //건물 이름
    public float structureSizeX; //건물 X축 크기
    public float structureSizeY; //건물 Y축 크기
    public float structureSizeZ; //건물 Z축 크기
    public float buildTime; //건설시간
    public int structureId; //건물 아이디
    public int needGold; //건설에 필요한 골드
    public int infrastructureFigure; //인프라수치

    //건축물 종류에 따른 부가 요소
    //생산 건물일때
    public float productionTime; //생산시간
    public int output; //생산량
    public int harvestableOutput;//수확가능 생산량
    public int outputPerMinute; //분당 생산량
    public int maxOutput; //최대 생산량

    //문화시설일때

    //조형물일때
    public int npcId; //찾아올 npc아이디
    public float visitProbability; //찾아올 확률
}