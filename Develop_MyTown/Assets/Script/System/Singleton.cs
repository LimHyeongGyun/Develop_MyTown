using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;

                if (instance == null)
                {
                    GameObject _instance = new GameObject(typeof(T).Name, typeof(T));
                    instance = _instance.GetComponent<T>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (transform.parent !=  null && transform.root != null)
        {
            DontDestroyOnLoad(this.transform.root.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        
    }
}
