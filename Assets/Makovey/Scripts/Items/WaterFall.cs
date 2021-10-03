using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFall : MonoBehaviour
{

    public AudioClip[] audios;
    private AudioSource source;
    
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Water")
        {
            int rnd = Random.Range(0, audios.Length);
            source.PlayOneShot(audios[rnd]);
        }
    }

}
