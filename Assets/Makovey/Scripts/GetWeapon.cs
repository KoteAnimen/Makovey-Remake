using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeapon : MonoBehaviour
{
    private Weapons weapon;
	public int weaponId;
	
	void Start()
	{
		weapon = GameObject.Find("Weapons").GetComponent<Weapons>();
	}
	
	public void OnTriggerEnter(Collider col)
	{
		if(col.GetComponent<Collider>().tag == "Player")
		{
			weapon.FunctionGetWeapon(weaponId);
		}
	}
}
