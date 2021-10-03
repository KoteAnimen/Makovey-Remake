using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    public float hpPlayer;
    public float maxHp;
    public float forcePlayer;
    public float oxygen = 100;
    public bool isDead = false;
    public GameObject deadScreen;
    public AudioClip deadClip;
    public AudioClip[] underwaterDamage;
    private TMP_Text hpBar;    
    private AudioSource playerAudio;
    private GameObject music;
    private GameObject cursor;
    private controller player;
    private MouseL camera;    

    private void Awake()
    {
        cursor = GameObject.Find("cursor");
    }

    void Start()
    {
        deadScreen.SetActive(false);
        hpBar = GameObject.Find("HPPlayerBar").GetComponent<TMP_Text>();        
        playerAudio = GetComponent<AudioSource>();
        music = GameObject.Find("Weapons");
        player = GetComponent<controller>();
        camera = transform.Find("Camera").GetComponent<MouseL>();
        StartCoroutine(BarsUpdate());
        StartCoroutine(Oxygen());
    }
    
    void Update()
    {
        DeadFunction();
    }

    void DeadFunction()
    {
        cursor.transform.position = Input.mousePosition;
        if (hpPlayer <= 0 && !isDead)
        {
            deadScreen.SetActive(true);
            isDead = true;            
            playerAudio.PlayOneShot(deadClip);
            camera.enabled = false;
            player.enabled = false;
            cursor.SetActive(true);
            music.SetActive(false);            
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

    IEnumerator Oxygen()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if(player.inWater == true)
            {
                oxygen -= 5;
                if (oxygen <= 0 && !isDead)
                {
                    hpPlayer -= 10;
                    int rnd = Random.Range(0, underwaterDamage.Length);
                    playerAudio.PlayOneShot(underwaterDamage[rnd]);
                }
            }
            else
            {
                oxygen = 100;
            }
            
        }
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
