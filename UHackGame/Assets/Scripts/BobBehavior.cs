using UnityEngine;
using System;
using System.Collections;

public class BobBehavior : MonoBehaviour
{
	
	public float bobspeed = 17f;
	public bool directionbool = true;
	public float floatStrength = 0.2f; 

	float originalY;
	float direction;

	void Start()
	{
		this.originalY = this.transform.position.y;
		if (directionbool) {
			direction = 1f;
		} else {
			direction = -1f;
		}
	}

	void Update()
	{
		transform.position = new Vector3(transform.position.x,
			originalY + (direction*(float)Math.Sin(Time.time*bobspeed) * floatStrength),
			transform.position.z);
	}
}