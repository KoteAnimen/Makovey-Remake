using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeapon : MonoBehaviour
{
    public int idWeapon;
    private ChangeWeapon weapons;

    void Start()
    {
        weapons = GameObject.Find("Weapons").GetComponent<ChangeWeapon>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player")
        {
            weapons.GetWeapon(idWeapon);
            gameObject.SetActive(false);
        }
    }
}
