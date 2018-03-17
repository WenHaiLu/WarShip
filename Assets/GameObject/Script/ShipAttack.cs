using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAttack : MonoBehaviour {

	public bool isFrontGun = true;
	public GameObject shell;//炮弹实体
	public float shootPower;//炮弹推力
	public float shootCoolDown;//冷却

	private DefaultButton buttons;
	private AudioSource audioSource;
	private bool isWeaponReady = true;
	private GameObject newSheel;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		buttons = GameObject.FindGameObjectWithTag("GameController").GetComponent<DefaultButton>();
	}


	void Update()
	{
		Shoot();
	}

	private void Shoot()
	{
		if (buttons.Getbutton("Fire"))
		{
			Debug.Log("Fire");
			if (!isWeaponReady)
			return;

			newSheel = Instantiate(shell, transform.position,transform.rotation);

			if (isFrontGun)
			{
				Rigidbody r = newSheel.GetComponent<Rigidbody>();
				r.velocity = -transform.up * shootPower;
			}
			else
			{ 
				Rigidbody r = newSheel.GetComponent<Rigidbody>();
				r.velocity = transform.up * shootPower;
			}
		
		audioSource.Play();
		isWeaponReady = false;
		StartCoroutine(WeaponCoolDown());
		
		}


	}

	IEnumerator WeaponCoolDown()
	{
		yield return new WaitForSeconds(shootCoolDown);
		isWeaponReady = true;
		Destroy(newSheel);
	}





}
