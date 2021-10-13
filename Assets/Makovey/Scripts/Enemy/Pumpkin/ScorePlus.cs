using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlus : MonoBehaviour
{
    private EnemyManager em;
    private EnemyCounter ec;
    private bool checkedEnemy = false;
    void Start()
    {
        em = GetComponent<EnemyManager>();
        ec = GameObject.Find("GameManager").GetComponent<EnemyCounter>();
        StartCoroutine(UpdateState());        
    }

    IEnumerator UpdateState()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);            
            if (em.isDead == true && !checkedEnemy)
            {                
                ec.ScoreIncrement();
                checkedEnemy = true;
            }
        }
    }
}
