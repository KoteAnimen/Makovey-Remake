using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public int maxScore;
    private int score = 0;
    public GameObject portal;
    public AudioClip gameOver;
    private AudioSource source;
    private bool win = false;
    private Transform player;
    void Start()
    {
        source = GetComponent<AudioSource>();
        portal.SetActive(false);
        StartCoroutine(UpdateScore());
        player = GameObject.Find("Player").transform;
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if(score == maxScore && !win)
            {
                portal.SetActive(true);
                portal.gameObject.transform.position = new Vector3(player.position.x + 20, player.position.y, player.position.z);
                source.PlayOneShot(gameOver);
                win = true;
            }
        }
    }

    public void ScoreIncrement()
    {
        score++;
    }    
}
