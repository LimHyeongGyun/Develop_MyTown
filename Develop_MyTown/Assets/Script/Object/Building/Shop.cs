using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>().playerState == StateManager.PlayerState.interaction)
            {
                //�� ��ȯ
            }
        }
    }
}
