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
    private GameObject deadScreen;
    public AudioClip deadClip;
    public AudioClip[] underwaterDamageSounds;
    public AudioClip[] damageSounds;
    private TMP_Text hpBar;    
    private AudioSource playerAudio;
    private GameObject music;
    private GameObject cursor;
    private controller player;
    private MouseL camera;
    private GameObject messageObject;

    private void Awake()
    {
        cursor = GameObject.Find("cursor");
    }

    void Start()
    {
        deadScreen = GameObject.Find("DeadScreen");
        deadScreen.SetActive(false);
        hpBar = GameObject.Find("HPPlayerBar").GetComponent<TMP_Text>();        
        playerAudio = GetComponent<AudioSource>();
        music = GameObject.Find("Weapons");
        player = GetComponent<controller>();
        camera = transform.Find("Camera").GetComponent<MouseL>();
        messageObject = GameObject.Find("Message");
        StartCoroutine(BarsUpdate());
        StartCoroutine(Oxygen());
        messageObject.SetActive(false);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Message")
        {
            messageObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Message")
        {
            messageObject.SetActive(false);
        }
    }

    public void MainMenuLoad()
    {
        Application.LoadLevel("Menu");
    }

    public void GetDamage(float damage)
    {
        if (!player.inWater)
        {
            if(hpPlayer > 0)
            {
                hpPlayer -= damage;
                int rnd1 = Random.Range(0, damageSounds.Length);
                playerAudio.PlayOneShot(damageSounds[rnd1]);
            }            
        }
        else
        {
            if(hpPlayer > 0)
            {
                hpPlayer -= damage;
                int rnd2 = Random.Range(0, underwaterDamageSounds.Length);
                playerAudio.PlayOneShot(underwaterDamageSounds[rnd2]);
            }            
        }
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
                    GetDamage(10);
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
