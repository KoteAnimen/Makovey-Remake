using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {

	private float speed = 0f;
	public float minSpeed;
	public float maxSpeed;
    public float gravity;		
    private Vector3 moveDirection = Vector3.zero;	
	private MouseL cam;
	public string camera;
	public float jumpSpeed;
	public float jumpSpeedinWater;
	public AudioClip[] jumpSounds; 
	public bool inWater;
	public AudioClip[] waterSounds;
	public Color underWaterColor;
	public float underWaterFog = 0.11f;
	public float timePlay;
	private AudioSource playerSource;
	private bool play = false;
	private AudioReverbZone underWaterEffect;
	

	void Start()
	{
		cam = GameObject.Find(camera).GetComponent<MouseL> ();
		playerSource = GetComponent<AudioSource>();
		underWaterEffect = GetComponent<AudioReverbZone>();
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
				int rnd = Random.Range(0, jumpSounds.Length);
				moveDirection.y = jumpSpeed;
				playerSource.PlayOneShot(jumpSounds[rnd]);
			}			
			
		}
		else
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}
		
		if(inWater == true)
		{
			RenderSettings.fogDensity = underWaterFog;
			RenderSettings.fogColor = underWaterColor;
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection.y = -gravity * Time.deltaTime * 10;
			underWaterEffect.enabled = true;

			if (Input.GetButton ("Jump")) 
			{
				moveDirection.y = jumpSpeedinWater;				
			}
            if (Input.GetKey(KeyCode.C))
            {
				moveDirection.y = -jumpSpeedinWater;
			}

			if (controller.velocity.magnitude >= 1f) play = true;
			else play = false;
		}
        else
        {
			RenderSettings.fogDensity = 0.005f;
			RenderSettings.fogColor = Color.black;
			underWaterEffect.enabled = false;
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
