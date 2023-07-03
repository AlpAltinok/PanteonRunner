using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Odak : MonoBehaviour
{
    public NavMeshAgent odak;
    public GameObject target;
    Vector3 baslangýcpozisyon;
    public GameObject spedb;
    private void Awake()
    {
        baslangýcpozisyon = transform.position;
    }
    void Start()
    {
        odak = GetComponent<NavMeshAgent>();
    }
    void RestartKlon()
    {
        transform.position = baslangýcpozisyon;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Resle"))
        {
            RestartKlon();
        }
        else if (other.gameObject.CompareTag("SpeedBoost"))
        {
            spedb.SetActive(true);
            odak.speed = odak.speed + 3;
            StartCoroutine(Slow());
        }
    }
    void Update()
    {
        odak.SetDestination(target.transform.position);
    }
    private  IEnumerator Slow()
    {
        yield return new WaitForSeconds(2f);
        odak.speed = odak.speed - 3f;
        spedb.SetActive(false);
    }
}
