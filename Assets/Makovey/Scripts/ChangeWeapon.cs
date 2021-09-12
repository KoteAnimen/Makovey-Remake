using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject[] weapons;
    public bool[] isGet;

    // Start is called before the first frame update
    void Start()
    {
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
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(false);
            }
            weapons[0].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && isGet[1] == true)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(false);
            }
            weapons[1].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && isGet[2] == true)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(false);
            }
            weapons[2].SetActive(true);
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
