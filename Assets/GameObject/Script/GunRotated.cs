using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotated : MonoBehaviour {

	public bool isFrontGun = true;

	public float rotatedSpeed = 8f;
	public float maxAngle = 140f;//前炮最大旋转角度

	private float curRotatedSpeed = 0;
	private float curAngle = 0;
	private DefaultButton buttons;




	void Start()
	{
		buttons = GameObject.FindGameObjectWithTag("GameController").GetComponent<DefaultButton>();
	
	}

	// Update is called once per frame
	void Update () {
		//mosue Y 向右是负值
		Debug.Log(buttons.GetAxis("Mouse Y"));
		GunRotate();

	}




	private void GunRotate()
	{
		//前炮
		//if (isFrontGun)
		//{
		//	curRotatedSpeed = -buttons.GetAxis("Mouse Y") * rotatedSpeed * Time.deltaTime * 10f;
		//	curAngle += curRotatedSpeed;
		//	if (curAngle >= maxFR || curAngle <= -maxFR)
		//		curRotatedSpeed = 0;

		//	transform.Rotate(Vector3.forward,curRotatedSpeed);

		//}

		if (isFrontGun)
		{
			if (buttons.Getbutton("RRotate"))//右转
			{
				curRotatedSpeed = rotatedSpeed * Time.deltaTime;

				transform.Rotate(Vector3.forward, curRotatedSpeed);
			}

			if (buttons.Getbutton("LRotate"))//左转
			{

				curRotatedSpeed = -rotatedSpeed * Time.deltaTime;

				transform.Rotate(Vector3.forward, curRotatedSpeed);
			}

		}
		else
		{ 
			if (buttons.Getbutton("RRotate"))//右转
			{
				curRotatedSpeed = -rotatedSpeed* Time.deltaTime;

				transform.Rotate(Vector3.forward, curRotatedSpeed);
			}

			if (buttons.Getbutton("LRotate"))//左转
			{

				curRotatedSpeed = rotatedSpeed* Time.deltaTime;

				transform.Rotate(Vector3.forward, curRotatedSpeed);
			}



		}







	
	}



}
