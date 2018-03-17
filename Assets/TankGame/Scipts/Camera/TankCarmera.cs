using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCarmera : MonoBehaviour {

	public Transform target;
	
	// Update is called once per frame
	void LateUpdate () {
		if (target == null)
			return;
		
		transform.position = target.position;
	}
}
