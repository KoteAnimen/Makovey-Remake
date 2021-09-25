using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseL : MonoBehaviour {
	[SerializeField]
	float smootch;
	[SerializeField]
	Vector2 sens = new Vector2 (4, 4);
	private Vector2 NewCoord;
	public Vector2 CurrentCoord;
	[SerializeField]
	Vector2 Limit = new Vector2 (-70, 80);
	private Vector2 vel;	
	
	void Update () {
		NewCoord.x = Mathf.Clamp (NewCoord.x, Limit.x, Limit.y);
		NewCoord.x -= Input.GetAxis ("Mouse Y") * sens.x / 100;
		NewCoord.y += Input.GetAxis ("Mouse X") * sens.x / 100;
		CurrentCoord.x = Mathf.SmoothDamp (CurrentCoord.x, NewCoord.x, ref vel.x, smootch);
		CurrentCoord.y = Mathf.SmoothDamp (CurrentCoord.y, NewCoord.y, ref vel.y, smootch);
		transform.rotation = Quaternion.Euler (CurrentCoord.x, CurrentCoord.y, 0);		
	}
}
