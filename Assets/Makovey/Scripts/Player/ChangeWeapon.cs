using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject[] weapons;
    public AudioClip[] changeWeaponSounds;
    public bool[] isGet;
    private AudioSource playerAudio;
    private int idNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GameObject.Find("Player").GetComponent<AudioSource>();
        for(int i = 0; i < weapons.Length; i++)
        {
            if (isGet[i] != true)
            {
                weapons[i].SetActive(false);
            }                  
        }       
    }
    
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            idNumber = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            idNumber = 1;                 
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            idNumber = 2;
        }
        ChangeWeaponFunc(idNumber);
    }

    void ChangeWeaponFunc(int id)
    {
        if (isGet[id] == true)
        {
            if (weapons[id].activeSelf == false)
            {
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false);
                }
                weapons[id].SetActive(true);
                playerAudio.PlayOneShot(changeWeaponSounds[id]);
            }
        }
    }

    public void GetWeapon(int id)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[id].SetActive(true);
        isGet[id] = true;
        idNumber = id;
    }    
}
