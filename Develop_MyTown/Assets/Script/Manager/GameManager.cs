using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManagerInstance = null;
    private static GameManager GameManagerInstance { get { return gameManagerInstance; } }

    private void Awake()
    {
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
