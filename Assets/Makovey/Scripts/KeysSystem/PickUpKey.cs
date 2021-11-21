using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public string keyName;
    public AudioClip keySound;
    private AudioSource audioPlayer;
    private Keys keys;
    // Start is called before the first frame update
    void Start()
    {
        keys = GameObject.Find("Player").GetComponent<Keys>();
        audioPlayer = GameObject.Find("Player").GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player")
        {
            keys.keys[keyName] = true;
            audioPlayer.PlayOneShot(keySound);
            Destroy(gameObject);
        }
    }


}
