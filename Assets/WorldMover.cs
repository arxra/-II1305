﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour {

	public const string TAG = "Moving"; 

	private List<GameObject> targets; 
	public Vector3 MovementDirection;

	public float MaxSpeed = 16f;

	// Use this for initialization
	void Start () {
		targets = new List<GameObject>(GameObject.FindGameObjectsWithTag(TAG));
		MovementDirection = new Vector3(0f, 0f, -100f);
	}
	
	// Update is called once per frame
	void Update () {
		
		foreach(GameObject target in targets) {
			Rigidbody body = target.GetComponent<Rigidbody>();

			if (body.velocity.magnitude < MaxSpeed)
				body.AddForce(MovementDirection);
		}

		foreach(GameObject target in targets) {
			if (target.name.Equals("Road")){
				Transform transf = target.GetComponent<Transform>();
			
				if (transf.position.magnitude > 10)
					transf.SetPositionAndRotation(Vector3.zero, transf.rotation);
			}
		}
	}
}
