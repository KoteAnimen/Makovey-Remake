using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
	public GameObject modelWeapon;
	public bool isActivate;
	public bool isGet;
	public float damage;
	public bool closeBattle;
	public GameObject bullet;
	public float bulletForce;
	public int bulletAmount;
	public Animator animator;
	public string walkState;
	public string attackState;
	public Vector3 startPosition; 
	
	public void Activate(bool active)
	{
		isActivate = active;
		modelWeapon.transform.localPosition = startPosition;
		if(isActivate == true)
		{
			modelWeapon.SetActive(true);
		}
		else
		{
			modelWeapon.SetActive(false);
		}
	}
	public void IsGet(bool isget)
	{
		isGet = isget;
	}
	
	public void WalkAnimation(bool activeState)
	{
		animator.SetBool(walkState, activeState);
	}
	public void AttackAnimation(bool activeState)
	{
		animator.SetBool(attackState, activeState);
	}	
	
}

public class Weapons : MonoBehaviour
{
    
	public List<Weapon> weapons = new List<Weapon>();	
	private CharacterController player;
	
    void Start()
    {
		player = GameObject.Find("Player").GetComponent<CharacterController>();
        for(int i = 0; i < weapons.Count; i++)
		{
			weapons[i].Activate(false);
		}		
    }

    // Update is called once per frame
    void Update()
    {
        ChangeWeapon();
		PlayerAnimation();

    }
	
	void PlayerAnimation()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			for(int i = 0; i < weapons.Count; i++)
			{
				weapons[i].AttackAnimation(true);
			}	
		}
		else if(Input.GetKeyUp(KeyCode.Mouse0))//Доработать!!!
		{
			for(int i = 0; i < weapons.Count; i++)
			{				
				weapons[i].AttackAnimation(false);
			}	
		}
		
		if(player.velocity.magnitude >= 1)
		{
			for(int i = 0; i < weapons.Count; i++)
			{
				weapons[i].WalkAnimation(true);
			}	
			
		}
		
		else if(player.velocity.magnitude < 1)//Доработать!!!
		{
			for(int i = 0; i < weapons.Count; i++)
			{
				weapons[i].WalkAnimation(false);				
			}	
		}
	}
	
	void ActivateWeapon(int id)
	{
		for(int i = 0; i < weapons.Count; i++)
		{			
			weapons[i].Activate(false);
		}
		weapons[id].Activate(true);
	}
	
	public void FunctionGetWeapon(int id)
	{
		weapons[id].IsGet(true);
		ActivateWeapon(id);		
	}
	
	void ChangeWeapon()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1) && weapons[0].isGet == true)
		{
			ActivateWeapon(0);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2) && weapons[1].isGet == true)
		{
			ActivateWeapon(1);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3) && weapons[2].isGet == true)
		{
			ActivateWeapon(2);
		}
	}
	
}

