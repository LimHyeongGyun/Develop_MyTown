using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이중 지속적으로 표시되어야하는 UI(ex.시간, 메뉴)는 MainCanvas의 자식 오브젝트로 계속 존재함
//은행이나 상점과 같이 시스템적으로 필요할 때만 표시되는 UI는 Instantiate로 생성 Destroy로 삭제
//
//(동적)DynamicUI:시간과 같이 지속적으로 변경되는 UI
//(정적)StaticUI:플레이어의 조작으로만 변경되는 UI
public class UI_DefaultSet : MonoBehaviour
{
    public StateManager.UIType uiType;
    public StateManager.UIDirectionType direction;
}