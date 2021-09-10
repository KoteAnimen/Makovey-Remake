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
            weapons[i].SetActive(false);
            isGet[i] = false;
            StartCoroutine(UpdateState());
        }
        
    }    

    IEnumerator UpdateState()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.001f);

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
    }
}
