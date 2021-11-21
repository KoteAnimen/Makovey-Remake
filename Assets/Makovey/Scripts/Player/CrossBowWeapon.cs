using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBowWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform attackPoint;
    private Animator anim;
    private AudioSource audioPlayer;
    public CharacterController player;
    public string walkState;
    public string attackState;
    public int countBullet;
    public float damage;
    public float force;    
    public AudioClip attackSound;
    public bool mayAttack = true;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        audioPlayer = GameObject.Find("Player").GetComponent<AudioSource>();
    }

    void Update()
    {
        PlayerAnimation();
        StartCoroutine(Reload());
        StartCoroutine(MayAttack());
    }

    void PlayerAnimation()
    {       
        if (Input.GetKeyDown(KeyCode.Mouse0) && mayAttack)
        {
            anim.SetBool(attackState, true);
            mayAttack = false;
        }        

        if (player.velocity.magnitude >= 1 && player.isGrounded)
        {
            anim.SetBool(walkState, true);
        }
        if (!player.isGrounded)
        {
            anim.SetBool(walkState, false);
        }

        else if (player.velocity.magnitude < 1)
        {
            anim.SetBool(walkState, false);
        }
    }

    public void Attack() //зависит от AnimationEvent
    {
        GameObject cloneBullet;
        cloneBullet = Instantiate(bullet, transform.position, attackPoint.rotation);
        cloneBullet.GetComponent<Rigidbody>().AddForce(attackPoint.forward * force);
        audioPlayer.PlayOneShot(attackSound);
    }

    IEnumerator Reload()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (!mayAttack)
            {
                yield return new WaitForSeconds(0.5f);
                anim.SetBool(attackState, false);
            }
        }
    }

    IEnumerator MayAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (!mayAttack)
            {
                yield return new WaitForSeconds(1);
                mayAttack = true;
            }
        }
    }
}
