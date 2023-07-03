using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingSistem : MonoBehaviour
{
    public float distance;
    public GameObject target;
    public int rank;

    void CalculateDistance()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
    }
}
