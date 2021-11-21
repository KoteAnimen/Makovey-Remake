using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SendMessage : MonoBehaviour
{
    private TMP_Text text;
    public string textMessage;
    void Awake()
    {
        text = GameObject.Find("Text").GetComponent<TMP_Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player")
        {
            text.text = textMessage;
        }
    }

}
