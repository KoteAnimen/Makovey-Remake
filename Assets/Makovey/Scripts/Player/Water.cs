using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	private controller cont;	
	void Start () {
		cont = GameObject.Find("Player").GetComponent<controller>();
	}
	
	void OnTriggerEnter(Collider col){
		if(col.GetComponent<Collider>().tag == "Water"){
			cont.inWater = true;
		}
		
	}
	
	void OnTriggerExit(Collider col){
		if(col.GetComponent<Collider>().tag == "Water"){
			cont.inWater = false;
		}
		
	}
	
}
