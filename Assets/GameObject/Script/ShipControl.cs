using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipControl : MonoBehaviour {


	public Slider fSlider;//前进滑条
	public Slider bSlider;//后退滑条
	public Slider lSlider;//左转滑条
	public Slider rSlider;//右转滑条

	public float moveASpeed = 10f;//直行加速度
	public float MoveRSpeed = 10f;//转弯加速度
	public float MaxSpeed = 31f;//最大前进速度
	public float MaxBSpeed = 10f;//最大后退速度
	public float MaxRotatedSPeed = 30f;//最大转弯速度
	public float rotatedSpeed = 4f;


	private DefaultButton buttons;
	private float curMoveSpeed = 0f;
	private float curRotatedSpeed = 0f;




	void Start()
	{
		buttons = GameObject.FindGameObjectWithTag("GameController").GetComponent<DefaultButton>();		

	}




	void Update()
	{
		UpdateMov();
		//UpdateRotatedSpeed();
		UpdateRotated();
	}



	void UpdateMov()
	{
		UpdateSpeed();
		transform.position -= transform.up * curMoveSpeed * Time.deltaTime / 10;
	}

	void UpdateRotated()
	{
		UpdateRotatedSpeed();
		transform.Rotate(Vector3.forward,curRotatedSpeed);
	}






	private void UpdateSpeed()
	{
		
		if (buttons.GetAxis("Vertical") > 0)
		{
			if(bSlider.value > 0)
			{
				bSlider.value -= moveASpeed / 10 * buttons.GetAxis("Vertical") * 0.1f * Time.deltaTime;
				curMoveSpeed += bSlider.value * MaxSpeed * Time.deltaTime / 10;

			}
			if (bSlider.value <= 0)
			{
				//if (fSlider.value == 0)
				//	curMoveSpeed = 0;
				fSlider.value += moveASpeed / 10 * buttons.GetAxis("Vertical") * 0.1f * Time.deltaTime;
				curMoveSpeed += fSlider.value* MaxSpeed * Time.deltaTime /10;

			}
			//curMoveSpeed += (fSlider.value - bSlider.value) * MaxSpeed * Time.deltaTime;
			if (curMoveSpeed > MaxSpeed)
				curMoveSpeed = MaxSpeed;

		}
		else if (buttons.GetAxis("Vertical") < 0)
		{
			Debug.Log(buttons.GetAxis("Vertical") );
			if (fSlider.value > 0)
			{
				fSlider.value += MaxBSpeed / 10 * buttons.GetAxis("Vertical") * 0.1f * Time.deltaTime;
				curMoveSpeed -= fSlider.value * MaxBSpeed * Time.deltaTime;
			}
			if (fSlider.value <= 0)
			{
				//if (bSlider.value == 0)
				//	curMoveSpeed = 0;
				bSlider.value += MaxBSpeed / 10 * Mathf.Abs(buttons.GetAxis("Vertical") * 0.1f) * Time.deltaTime;
				curMoveSpeed -= bSlider.value * MaxBSpeed * Time.deltaTime;

			}

			//curMoveSpeed += (fSlider.value - bSlider.value) * MaxBSpeed * Time.deltaTime;
			if (curMoveSpeed < -MaxBSpeed)
				curMoveSpeed = -MaxBSpeed;

		}
	}

	private void UpdateRotatedSpeed()
	{
		if (buttons.GetAxis("Horizontal") > 0)
		{
			if (lSlider.value > 0)
			{
				lSlider.value -= buttons.GetAxis("Horizontal") * Time.deltaTime;
				curRotatedSpeed += lSlider.value * rotatedSpeed * Time.deltaTime * 0.1f;

				if (lSlider.value == 0)
					curRotatedSpeed = 0;
			}

			if (lSlider.value <= 0)
			{
				
			if (rSlider.value >= 0)
			{ 
					rSlider.value += buttons.GetAxis("Horizontal") * Time.deltaTime;
					curRotatedSpeed += rSlider.value * rotatedSpeed * Time.deltaTime * 0.1f;

				if (curRotatedSpeed >= MaxRotatedSPeed)
						curRotatedSpeed = MaxRotatedSPeed * Time.deltaTime;
			}

			}

		}

		if (buttons.GetAxis("Horizontal") < 0)
		{
			if (rSlider.value > 0)
			{
				rSlider.value += buttons.GetAxis("Horizontal") * Time.deltaTime;
				curRotatedSpeed -= rSlider.value * rotatedSpeed * Time.deltaTime * 0.1f;
				if (rSlider.value == 0)
				{
					curRotatedSpeed = 0;
				}
			}

			if (rSlider.value <= 0)
			{
				
				if (lSlider.value >= 0)
				{
					lSlider.value += Mathf.Abs(buttons.GetAxis("Horizontal")) * Time.deltaTime;
					curRotatedSpeed -= lSlider.value * rotatedSpeed * Time.deltaTime * 0.1f;

					if (curRotatedSpeed <= -MaxRotatedSPeed)
						curRotatedSpeed = -MaxRotatedSPeed * Time.deltaTime;

				}
			
			}

		}

	
	}












}
