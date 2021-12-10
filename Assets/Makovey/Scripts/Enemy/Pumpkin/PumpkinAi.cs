using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PumpkinAi : MonoBehaviour
{
    public float agrDistance;
    public float fireDistance;
    public GameObject body;
    private float currentTargetDistance = 100;
    private NavMeshAgent agent;
    private GameObject target;       
    private EnemyManager em;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        em = GetComponent<EnemyManager>();
        target = GameObject.Find("Player");              
        body.SetActive(false);
        StartCoroutine(CalculateTargetDistance());
    }
    
    void Update()
    {
        if(currentTargetDistance <= agrDistance)
        {
            agent.SetDestination(target.transform.position);
        }
        if(currentTargetDistance < 2f)
        {
            em.Damage(20);            
        }
        if(currentTargetDistance <= fireDistance)
        {
            body.SetActive(true);
        }           
    }

    IEnumerator CalculateTargetDistance()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            currentTargetDistance = Vector3.Distance(target.transform.position, transform.position);
        }
    }
}
