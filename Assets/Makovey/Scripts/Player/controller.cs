﻿using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {

	private float speed = 0f;
	public float minSpeed;
	public float maxSpeed;
    public float gravity;		
    private Vector3 moveDirection = Vector3.zero;
	public float sens;
	private MouseL cam;
	public string camera;
	public float jumpSpeed;
	public float jumpSpeedinWater;
	public bool inWater;
	public AudioClip[] waterSounds;
	public float timePlay;
	private AudioSource playerSource;
	private bool play = false;
	

	void Start()
	{
		cam = GameObject.Find(camera).GetComponent<MouseL> ();
		playerSource = GetComponent<AudioSource>();
		StartCoroutine(WaterMoveSounds());
	}
	
    void Update()
	{	
		transform.rotation = Quaternion.Euler (0, cam.CurrentCoord.y, 0);	
		CharacterController controller = GetComponent<CharacterController>();  	
		    
		if (controller.isGrounded) 
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection.y = -gravity * Time.deltaTime;			
			
			if (Input.GetButtonDown ("Jump"))
			{
				moveDirection.y = jumpSpeed;				
			}			
			
		}
		else
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}
		
		if(inWater == true)
		{
			RenderSettings.fogDensity = 0.11f;
			RenderSettings.fogColor = Color.blue;
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection.y = -gravity * Time.deltaTime * 10;			

			if (Input.GetButton ("Jump")) 
			{
				moveDirection.y = jumpSpeedinWater;				
			}

			if (controller.velocity.magnitude >= 1f) play = true;
			else play = false;
		}
        else
        {
			RenderSettings.fogDensity = 0.02f;
			RenderSettings.fogColor = Color.black;
			play = false;
        }

		if(Input.GetButton("Strafe"))
		{
			speed = maxSpeed;
		}
        else
        {
			speed = minSpeed;
		}
        controller.Move(moveDirection * speed * Time.deltaTime);
    }

	IEnumerator WaterMoveSounds()
    {
        while (true)
        {
			yield return new WaitForSeconds(0.1f);
            if (play)
			{				
				int rnd = Random.Range(0, waterSounds.Length);
				playerSource.PlayOneShot(waterSounds[rnd]);
				yield return new WaitForSeconds(timePlay);
			}            
        }
    }
}