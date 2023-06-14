using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMesh))]
public class ClikMove : MonoBehaviour
{
    NavMeshAgent m_Agent;
    RaycastHit m_hitinfo = new RaycastHit();
    private void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin,ray.direction,out m_hitinfo))
            {
                m_Agent.destination = m_hitinfo.point;
            }
        }
    }
}
