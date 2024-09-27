using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StructureData", menuName = "ScriptableObject/Structure", order = 0)]
public class StructureSO : ScriptableObject
{
    //건축물 공통 요소
    public StateManager.StructureType structureType; //건물 타입
    public GameObject structureObj; //건물 오브젝트
    public int structureId; //건물 아이디
    public string structureName; //건물 이름
    public Sprite structureImg; //건물 이미지
    public int needGold; //건설에 필요한 골드
    public float buildTime; //건설시간
    public float infrastructureFigure; //인프라수치

    //건축물 종류에 따른 부가 요소
    //생산 건물일때
    public float productTime;

    //문화시설일때

    //조형물일때
    public int npcId; //찾아올 npc아이디
    public float visitProbability; //찾아올 확률
}