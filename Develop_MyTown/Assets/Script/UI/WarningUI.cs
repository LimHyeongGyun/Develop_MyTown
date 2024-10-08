using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WarningUI : Singleton<WarningUI>
{
    private static WarningUI instance = null;

    private float destroyTime = 3f;
    private float fadeTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        fadeTime = destroyTime;

        StartCoroutine(FadingAway());
    }

    public void WarningText(string text)
    {
        gameObject.GetComponentInChildren<Text>().text = text;
    }

    IEnumerator FadingAway()
    {
        while (destroyTime > 0)
        {
            Color colorA = this.GetComponent<Image>().color;
            colorA.a -= Time.deltaTime / fadeTime;
            destroyTime -= Time.deltaTime;
            this.GetComponent<Image>().color = colorA;
            yield return null;

            if (destroyTime <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
