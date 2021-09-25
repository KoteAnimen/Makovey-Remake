using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeapon : MonoBehaviour
{
    public int idWeapon;
    private ChangeWeapon weapons;
    public AudioClip getWeaponSound;
    private AudioSource playerSource;

    void Start()
    {
        weapons = GameObject.Find("Weapons").GetComponent<ChangeWeapon>();
        playerSource = GameObject.Find("Player").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player")
        {
            weapons.GetWeapon(idWeapon);
            gameObject.SetActive(false);
            playerSource.PlayOneShot(getWeaponSound);
        }
    }
}
