using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    public float hpPlayer;
    public float forcePlayer;    
    public bool isDead = false;
    public GameObject deadScreen;
    public AudioClip deadClip;
    private TMP_Text hpBar;    
    private AudioSource playerAudio;

    void Start()
    {
        deadScreen.SetActive(false);
        hpBar = GameObject.Find("HPPlayerBar").GetComponent<TMP_Text>();        
        playerAudio = GetComponent<AudioSource>();
        StartCoroutine(BarsUpdate());
    }
    
    void Update()
    {
        DeadFunction();
    }

    void DeadFunction()
    {
        if(hpPlayer <= 0 && !isDead)
        {
            deadScreen.SetActive(true);
            isDead = true;            
            playerAudio.PlayOneShot(deadClip);            
        }
    }

    public void Respawn()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void MainMenuLoad()
    {
        Application.LoadLevel("Menu");
    }

    IEnumerator BarsUpdate()
    {        
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            hpBar.text = hpPlayer.ToString();                    
        }
    }
}
