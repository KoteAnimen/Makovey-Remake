using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
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
    

    // Start is called before the first frame update
    void Start()
    {        
        anim = GetComponent<Animator>();
        audioPlayer = GameObject.Find("Player").GetComponent<AudioSource>();        
    }

    void Update()
    {        
        PlayerAnimation();
    }

	void PlayerAnimation()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{			
			anim.SetBool(attackState, true);			
		}
		else if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			anim.SetBool(attackState, false);			
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
}
