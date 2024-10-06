using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewStructure : MonoBehaviour
{
    [SerializeField]
    private List<Collider> colliderList = new List<Collider>(); //충돌한 오브젝트들 저장할 리스트

    [SerializeField]
    private int groundLayer;
    [SerializeField]
    private int playerLayer;

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
        this.GetComponent<Renderer>().material = mat;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != groundLayer && other.gameObject.layer != playerLayer)
        {
            colliderList.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != groundLayer && other.gameObject.layer != playerLayer)
        {
            colliderList.Remove(other);
        }
    }
    public bool IsBuildable()
    {
        return colliderList.Count == 0;
    }

    public void DestroyPreview()
    {
        Destroy(this.gameObject);
    }
}
