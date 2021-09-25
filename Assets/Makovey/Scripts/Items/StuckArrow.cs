using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckArrow : MonoBehaviour
{
    public float timeToDestroy;
    private Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = transform.GetComponent<Rigidbody>();
        StartCoroutine(DestroyBullet());
    }    

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "Player")
        {
            rig.isKinematic = true;
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
