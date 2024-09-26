using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StructureData", menuName = "ScriptableObject/Structure", order = 0)]
public class StructureSO : ScriptableObject
{
    //건축물 공통 요소
    [SerializeField]
    private StateManager.StructureType structureType;
    [SerializeField]
    private int structureId; //건물 아이디
    [SerializeField]
    private string structureName; //건물 이름
    [SerializeField]
    private Sprite structureImg; //건물 이미지
    [SerializeField]
    private int needGold; //건설에 필요한 골드
    [SerializeField]
    private float buildTime; //건설시간
    [SerializeField]
    private float infrastructureFigure; //인프라수치

    //건축물 종류에 따른 부가 요소
    //생산 건물일때
    [SerializeField]
    private float productTime;

    //문화시설일때


    //조형물일때
    [SerializeField]
    private int npcId; //찾아올 npc아이디
    [SerializeField]
    private float visitProbability; //찾아올 확률
}