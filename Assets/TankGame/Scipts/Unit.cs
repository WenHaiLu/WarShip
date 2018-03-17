using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Team
{
	Red,Blue,Green
}

public class Unit : MonoBehaviour {

	public float health = 100;
	public Team team;
	public GameObject deadEffect;

	private float curHealth;

	public float GetCurHealth()
	{
		return curHealth;
	}

	virtual public void Start()
	{
		curHealth = health;
	}


	public void ApplyDamage (int damage)
	{
		if (curHealth > damage) {
			curHealth -= damage;
		} else {
			Destruct ();

		}


	}

	public void Destruct()
	{
		curHealth = 0;
		if (deadEffect != null) {
			Instantiate (deadEffect,transform.position,transform.rotation);
		}
		Destroy (gameObject);

	}

}
