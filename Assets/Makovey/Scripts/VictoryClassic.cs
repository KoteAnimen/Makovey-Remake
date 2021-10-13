using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryClassic : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player")
        {
            Application.LoadLevel(sceneName);
        }
    }
}
