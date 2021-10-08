using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAi : MonoBehaviour
{
    public float agrDistance;
    public float attackDistance;
    private NavMeshAgent agent;
    private GameObject target;
    private PlayerManager pm;
    private Animator m_animator;    
    private float speed;
    private float currentTargetDistance = 100;
    // Start is called before the first frame update

    private void Awake()
    {
        m_animator = GetComponent<Animator>();        
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        pm = GameObject.Find("Player").GetComponent<PlayerManager>();
        StartCoroutine(CalculateSpeed());
        StartCoroutine(CalculateTargetDistance());
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTargetDistance <= agrDistance)
        {
            agent.SetDestination(target.transform.position);
        }

        StartAttackAnimation();
            
        m_animator.SetFloat("MoveSpeed", speed);        
    }

    public void AttackFunction()
    {
        if (currentTargetDistance <= attackDistance)
        {
            pm.GetDamage(20f);
        }        
    }

    void StartAttackAnimation()
    {
        if(currentTargetDistance <= attackDistance)
        {
            m_animator.SetTrigger("Attack");
        }
    }

    //изучить конкретно
    IEnumerator CalculateSpeed()
    {
        YieldInstruction timeWait = new WaitForSeconds(0.01f);
        Vector3 lastPosition = transform.position;
        float lastTimeStamp = Time.time;

        while (true)
        {
            yield return timeWait;
            var deltaPosition = (transform.position - lastPosition).magnitude;
            var deltaTime = Time.time - lastTimeStamp;

            speed = deltaPosition / deltaTime;

            lastPosition = transform.position;
            lastTimeStamp = Time.time;
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
