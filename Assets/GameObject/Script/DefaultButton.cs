using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultButton : MonoBehaviour
{

	private Dictionary<string, KeyCode> buttons = new Dictionary<string, KeyCode>();

	private List<string> axis = new List<string>();

	public bool lockCursor { 
		get { return Cursor.lockState == CursorLockMode.Locked ? true : false; }
		set {
			Cursor.visible = value;
			Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
		}
	
	}


void Start()
	{
		SetDefault();
	}


	private void SetDefault()
	{

		AddButton("Fire", KeyCode.Mouse0);
		AddButton("LockFire", KeyCode.Mouse1);
		AddButton("RRotate",KeyCode.C);//右转炮
		AddButton("LRotate",KeyCode.V);//左转炮

		AddAxis("Horizontal");
		AddAxis("Vertical");
		AddAxis("Mouse X");
		AddAxis("Mouse Y");
        AddAxis("Mouse ScrollWheel");
		
	}

	public void AddButton(string n, KeyCode k)
	{
		if (!buttons.ContainsKey(n))
		{
			buttons.Add(n, k);
		}
		else
		{
			return;
		}
	}

	public bool Getbutton(string button)
	{

		if (buttons.ContainsKey(button))
		{
			return Input.GetKey(buttons[button]);
		}
		return false;

	}

	public void AddAxis(string Axis)
	{
		if (!axis.Contains(Axis))
		{
			axis.Add(Axis);
		}
		else
		{
			return;
		}
	}


	public float GetAxis(string Axis)
	{
		if (axis.Contains(Axis))
		{
			return Input.GetAxis(Axis);
		}
		return 0;
	}








}
