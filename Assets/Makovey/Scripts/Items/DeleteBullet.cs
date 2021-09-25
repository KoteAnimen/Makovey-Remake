using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    public float timeToDestroy;    

    // Start is called before the first frame update
    void Start()
    {        
        StartCoroutine(DestroyBullet());
    } 

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
