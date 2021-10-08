using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieManager : MonoBehaviour
{
    public float hp;
    public float damageRock;
    public float damageArrow;
    public float damageSlash;
    public bool isDead = false;
    private Animator animation;
    private ZombieAi ai;
    private CapsuleCollider collider;
    private GameObject body;
    private NavMeshAgent agent;
    void Start()
    {
        animation = GetComponent<Animator>();
        ai = GetComponent<ZombieAi>();
        collider = GetComponent<CapsuleCollider>();
        agent = GetComponent<NavMeshAgent>();
        body = transform.Find("basic_rig").gameObject;
        body.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            Damage(damageRock);
        }
        if (collision.gameObject.tag == "Arrow")
        {
            Damage(damageArrow);
        }
        if (collision.gameObject.tag == "Slash")
        {
            Damage(damageSlash);
        }
    }
    void Damage(float damage)
    {
        hp -= damage;
        DeadFunction();
    }
    void DeadFunction()
    {
        if (hp <= 0)
        {
            animation.enabled = false;
            collider.enabled = false;
            ai.enabled = false;
            isDead = true;
            body.SetActive(true);
            agent.enabled = false;
        }
    }
}
