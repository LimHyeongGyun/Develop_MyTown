using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷����� ���������� ǥ�õǾ���ϴ� UI(ex.�ð�, �޴�)�� MainCanvas�� �ڽ� ������Ʈ�� ��� ������
//�����̳� ������ ���� �ý��������� �ʿ��� ���� ǥ�õǴ� UI�� Instantiate�� ���� Destroy�� ����
//
//(����)DynamicUI:�ð��� ���� ���������� ����Ǵ� UI
//(����)StaticUI:�÷��̾��� �������θ� ����Ǵ� UI
public class UI_DefaultSet : MonoBehaviour
{
    public StateManager.UIType uiType;
    public StateManager.UIDirectionType direction;
}