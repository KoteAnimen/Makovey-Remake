using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject[] weapons;
    public AudioClip[] changeWeaponSounds;
    public bool[] isGet;
    private AudioSource playerAudio;

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
        if (Input.GetKeyDown(KeyCode.Alpha1) && isGet[0] == true)
        {
            if (weapons[0].activeSelf == false)
            {
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false);
                }
                weapons[0].SetActive(true);
                playerAudio.PlayOneShot(changeWeaponSounds[0]);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && isGet[1] == true)
        {
            if(weapons[1].activeSelf == false)
            {
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false);
                }
                weapons[1].SetActive(true);
                playerAudio.PlayOneShot(changeWeaponSounds[1]);
            }            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && isGet[2] == true)
        {
            if (weapons[2].activeSelf == false)
            {
                for (int i = 0; i < weapons.Length; i++)
                {
                    weapons[i].SetActive(false);
                }
                weapons[2].SetActive(true);
                playerAudio.PlayOneShot(changeWeaponSounds[2]);
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
    }
    
}
