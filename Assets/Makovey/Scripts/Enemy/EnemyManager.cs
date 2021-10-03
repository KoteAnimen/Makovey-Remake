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
    public AudioClip deadSound;
    private GameObject deadBody;
    private GameObject model;
    private AudioSource source;
    
    void Start()
    {
        deadBody = transform.Find("deadBody").gameObject;
        model = transform.Find("model").gameObject;
        source = GetComponent<AudioSource>();
        deadBody.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Rock")
        {
            hpEnemy -= damageRock;
            DeadFunction();            
        }
        if (collision.gameObject.tag == "Arrow")
        {
            hpEnemy -= damageArrow;
            DeadFunction();
        }
        if (collision.gameObject.tag == "Slash")
        {
            hpEnemy -= damageSlash;
            DeadFunction();
        }
    }

    void DeadFunction()
    {
        if(hpEnemy <= 0)
        {
            model.SetActive(false);
            deadBody.SetActive(true);
            gameObject.GetComponent<SphereCollider>().enabled = false;
            isDead = true;
            source.PlayOneShot(deadSound);
        }        
    }


}
