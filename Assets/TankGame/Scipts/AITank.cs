using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITank : Unit {

	public float enemySearchRange;
	public float moveSpeed;
	public float rotateSpeed;
	public ISRange attackRange;
	public ISRange stopingDistance;
	public float AICoreTimerInterval;


	private GameObject enemy;
	private UnityEngine.AI.NavMeshAgent nam;
	private TankWeapon tw;
	private LayerMask enemyLayer;
	private float curAR;
	private float CurSD;


	void Start()
	{
		base.Start ();
		enemyLayer = LayerManage.GetEnemyLayer (team);
		nam = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		tw = GetComponent<TankWeapon> ();
		tw.Init (team);
		StartCoroutine (Timer());
		
	}




	void Update()
	{
//		timer += Time.fixedDeltaTime;

		if (enemy == null) {
			SearchEnemy ();
			return;
		}

		float dist = Vector3.Distance (enemy.transform.position,transform.position);


		if (dist > CurSD) {
			nam.SetDestination (enemy.transform.position);
		} else {
			
			nam.ResetPath ();
			Vector3 dir = enemy.transform.position - transform.position;
			Quaternion wantedRotation = Quaternion.LookRotation (dir);
			transform.rotation = Quaternion.Slerp (transform.rotation,wantedRotation,rotateSpeed * Time.deltaTime);
		}
		if (dist < curAR) {
			tw.shoot ();

		}	

	}

	IEnumerator Timer()
	{
		while (enabled) {
			curAR = ISMath.Random (attackRange);
			CurSD = ISMath.Random (stopingDistance);
			CurSD = Mathf.Min (curAR,CurSD);
			SearchEnemy ();
			yield return  new WaitForSeconds (AICoreTimerInterval);
		}
	}



	public void SearchEnemy()
	{
		Collider[] cols = Physics.OverlapSphere (transform.position,enemySearchRange,enemyLayer);
		if (cols.Length > 0) {
			float curMinDist = Mathf.Infinity;
			for (int i = 0; i < cols.Length; i++) {
				float curDist = Vector3.Distance (transform.position,cols[i].transform.position);
				if (curDist < curMinDist) {
					curMinDist = curDist;
					enemy = cols [i].gameObject;
				}
			    
			}



		}

	}



}
