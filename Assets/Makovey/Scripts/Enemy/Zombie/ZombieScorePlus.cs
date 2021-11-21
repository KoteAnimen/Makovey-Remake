using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScorePlus : MonoBehaviour
{
    private ZombieManager em;
    private EnemyCounter ec;
    private bool checkedEnemy = false;
    void Start()
    {
        em = GetComponent<ZombieManager>();
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
