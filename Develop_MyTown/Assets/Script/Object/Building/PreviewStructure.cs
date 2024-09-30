using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewStructure : MonoBehaviour
{
    private List<Collider> colliderList = new List<Collider>(); //충돌한 오브젝트들 저장할 리스트

    [SerializeField]
    private int groundLayer;

    [SerializeField]
    private Material green;
    [SerializeField]
    private Material red;

    private void Update()
    {
        JudgementField();
    }

    private void JudgementField()
    {
        if (colliderList.Count > 0)
        {
            ChangeMaterial(red);
        }
        else
        {
            ChangeMaterial(green);
        }
    }
    private void ChangeMaterial(Material mat)
    {
        foreach (Transform child in transform)
        {
            Material[] changeMats = new Material[child.GetComponent<Renderer>().materials.Length];

            for (int i = 0; i < changeMats.Length; i++)
            {
                changeMats[i] = mat;
            }
            child.GetComponent<Renderer>().materials = changeMats;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != groundLayer)
        {
            colliderList.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != groundLayer)
        {
            colliderList.Remove(other);
        }
    }
    public bool isBuildable()
    {
        return colliderList.Count == 0;
    }
}
