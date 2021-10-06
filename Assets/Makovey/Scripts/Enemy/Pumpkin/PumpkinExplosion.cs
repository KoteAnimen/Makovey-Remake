using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinExplosion : MonoBehaviour
{
    public float damage;
    private PlayerManager pm;
    
    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerManager>();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
        foreach(var col in hitColliders)
        {
            if (col.GetComponent<Collider>().tag == "Player")
            {
                pm.GetDamage(damage);                
            }            
            if (col.GetComponent<Rigidbody>())
            {
                col.GetComponent<Rigidbody>().AddForce((transform.position + col.transform.position) * 10);                
            }            
        }        
    }
    
}
