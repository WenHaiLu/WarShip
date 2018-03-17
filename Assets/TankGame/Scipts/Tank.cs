using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Unit {

	public float moveSpeed;
	public float rotateSpeed;

	private TankWeapon tw;


    void Start()
	{
		base.Start ();
		tw = GetComponent<TankWeapon> ();
		tw.Init (team);
	}

	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log (Input.GetAxis("Horizontal1"));
		float horizontal1 = Input.GetAxis("Horizontal1");
		float vertical1 = Input.GetAxis ("Vertical1");
		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime * vertical1);
		//transform.Translate (Vector3.forward * -moveSpeed * Time.deltaTime * vertical1);
		transform.Rotate (Vector3.up * rotateSpeed * Time.deltaTime * horizontal1);

		if (Input.GetKey (KeyCode.Space)) {
			tw.shoot ();
		}

		//transform.Rotate (Vector3.up * rotateSpeed * Time.deltaTime * horizontal1);
//		if (Input.GetKey (KeyCode.W)) 
//		{
//			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
//		}
//
//		if (Input.GetKey (KeyCode.S))
//		{
//			transform.Translate (Vector3.forward * -moveSpeed * Time.deltaTime);
//		}
//
//		if (Input.GetKey (KeyCode.A)) {
//			transform.Rotate (Vector3.up * -rotateSpeed * Time.deltaTime);
//		}
//
//		if (Input.GetKey (KeyCode.D)) {
//			transform.Rotate (Vector3.up * rotateSpeed * Time.deltaTime);
//		}

	}
}
