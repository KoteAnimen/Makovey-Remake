using UnityEngine;
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
	

	void Start()
	{
		cam = GameObject.Find(camera).GetComponent<MouseL> ();
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
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection.y = -gravity * Time.deltaTime;
			
			
			if (Input.GetButton ("Jump")) 
			{
				moveDirection.y = jumpSpeedinWater;				
			}
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
}
