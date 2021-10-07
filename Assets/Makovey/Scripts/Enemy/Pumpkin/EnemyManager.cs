using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float hpEnemy = 20;
    public float damageRock;
    public float damageArrow;
    public float damageSlash;
    public bool isDead;
    public float timeToDestroy;
    public AudioClip deadSound;
    private GameObject deadBody;
    private GameObject model;    
    private AudioSource source;
    private Light explLight;
    private PumpkinAi ai;
    
    void Awake()
    {
        deadBody = transform.Find("deadBody").gameObject;
        explLight = transform.Find("deadBody").gameObject.GetComponent<Light>();
        model = transform.Find("model").gameObject;        
        source = GetComponent<AudioSource>();
        ai = GetComponent<PumpkinAi>();
        deadBody.SetActive(false);        
        StartCoroutine(DeleteAfterDead());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Rock")
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

    public void Damage(float damage)
    {
        hpEnemy -= damage;
        DeadFunction();
    }

    void DeadFunction()
    {
        if(hpEnemy <= 0)
        {
            model.SetActive(false);
            deadBody.SetActive(true);
            gameObject.GetComponent<SphereCollider>().enabled = false;
            ai.enabled = false;
            isDead = true;
            source.PlayOneShot(deadSound);
        }        
    }

    IEnumerator DeleteAfterDead()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if(deadBody.activeSelf == true)
            {                
                explLight.intensity -= 2f;
            }
            if (isDead)
            {
                yield return new WaitForSeconds(timeToDestroy);
                deadBody.SetActive(false);
            }            
        }
    }


}
