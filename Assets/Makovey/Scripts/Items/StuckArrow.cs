using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckArrow : MonoBehaviour
{
    public float timeToDestroy;    
    private Rigidbody rig;
    private GameObject tail;

    // Start is called before the first frame update
    void Start()
    {
        rig = transform.GetComponent<Rigidbody>();
        tail = transform.Find("Trail").gameObject;
        StartCoroutine(DestroyBullet());
    }    

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "Player")
        {
            rig.isKinematic = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            tail.SetActive(false);
            gameObject.transform.parent = other.gameObject.transform;            
        }
        
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
