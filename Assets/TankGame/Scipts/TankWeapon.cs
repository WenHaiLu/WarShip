using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon : MonoBehaviour {

	public GameObject shell;
	public float shootPower;
	public Transform shootPoint;
	public float shootCoolDown;

	private AudioSource audioSource;
	private LayerMask enemyLayer;
	private bool isWeaponReady = true;

	void Start(){
		audioSource = GetComponent<AudioSource> ();


	}

	public void Init(Team team)
	{
		
		enemyLayer = LayerManage.GetEnemyLayer (team);
	}



	// Update is called once per frame

	public void shoot(){
		if (!isWeaponReady)
			return;
		//Quaternion quaternion = Quaternion.AngleAxis(90.0f,transform.up);
		GameObject newShell	= Instantiate (shell, shootPoint.position, transform.rotation);
		newShell.GetComponent<Shell> ().Init (enemyLayer);
		Rigidbody r = newShell.GetComponent<Rigidbody>();
		r.velocity = shootPoint.forward * shootPower;
		audioSource.Play ();
		isWeaponReady = false;
		StartCoroutine (WeaponCoolDown());
		}

	IEnumerator WeaponCoolDown()
	{
		yield return new WaitForSeconds (shootCoolDown);
		isWeaponReady = true;
	}

}
