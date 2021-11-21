using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public string doorName;
    public AudioClip doorOpenSound;    
    private Keys keys;
    private AudioSource audioPlayer;
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
            if(keys.keys[doorName] == true)
            {
                audioPlayer.PlayOneShot(doorOpenSound);                
                Destroy(gameObject);
            }
        }
    }
}
