using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int healthAdd;
    public AudioClip getPotion;
    private PlayerManager pm;
    private AudioSource playerSource;
    

    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerManager>();
        playerSource = GameObject.Find("Player").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player")
        {
            if(pm.hpPlayer < pm.maxHp)
            {
                pm.hpPlayer += healthAdd;
                playerSource.PlayOneShot(getPotion);
                Destroy(gameObject);
            }
        }
    }
}
