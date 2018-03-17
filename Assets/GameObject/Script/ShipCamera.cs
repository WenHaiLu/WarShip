using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCamera : MonoBehaviour
{

	private GameObject gameController;
	private DefaultButton button;



	//缩放限制
	public Vector2 zoomLimit = new Vector2(30f, 80f);
	//上下视角限制
	public Vector2 rotationXLimit = new Vector2(-40,70);
	//左右视角限制
	public Vector2 rotationYLimit = new Vector2(-360, 360);

	//缩放速度
	public float zoomSpeed = 4f;

	public float defaultZoom = 60f;


	private Vector2 currentMosueLook = Vector2.zero;

	private float xAngle;
	private float yAngle;


	void Start()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController");

		button = gameController.GetComponent<DefaultButton>();
		button.lockCursor = true;
		Camera.main.fieldOfView = defaultZoom;

	}


	void Update()
	{
		UpdateRotated();


	}

	void LateUpdate()
	{
		CameraControl();

	}



	private void CameraControl()
	{
		CameraZoom();
		CameraRotated();

	}

	private void CameraZoom()
	{
		float fieldOfView = Camera.main.fieldOfView;

		if (button.GetAxis("Mouse ScrollWheel") < 0f)
		{
			if (fieldOfView < zoomLimit.y)
			{
				Camera.main.fieldOfView += zoomSpeed;
				if (fieldOfView >= zoomLimit.y)
				{
					fieldOfView = zoomLimit.y;
					Camera.main.fieldOfView = fieldOfView;

				}
			}

		}

		if (button.GetAxis("Mouse ScrollWheel") > 0f)
		{
			if (fieldOfView > zoomLimit.x)
			{
				Camera.main.fieldOfView -= zoomSpeed;
				if (fieldOfView <= zoomLimit.x)
				{
					fieldOfView = zoomLimit.x;
					Camera.main.fieldOfView = fieldOfView;
				}
			}

		}


	}

	private void CameraRotated()
	{
		Quaternion xQuaternion = Quaternion.AngleAxis(xAngle, Vector3.up);
		Quaternion yQuaternion = Quaternion.AngleAxis(yAngle, Vector3.left);
		transform.rotation = xQuaternion * yQuaternion;


	}


	private void UpdateRotated()
	{
		GetMouseLook();

		if (currentMosueLook == Vector2.zero)
			return;
		

		xAngle += currentMosueLook.x;
		yAngle += currentMosueLook.y;


		yAngle = yAngle < -360 ? yAngle += 360 : yAngle;
		yAngle = yAngle > 360 ? yAngle -= 360 : yAngle;

		yAngle = Mathf.Clamp (yAngle,rotationXLimit.x,rotationXLimit.y);


		xAngle = xAngle < -360 ? xAngle += 360 : xAngle;
		xAngle = xAngle > 360 ? xAngle -= 360 : xAngle;

		xAngle = Mathf.Clamp (xAngle,rotationYLimit.x,rotationYLimit.y);

		
	}




	private void GetMouseLook()
	{
		currentMosueLook.x = button.GetAxis("Mouse X");
		currentMosueLook.y = button.GetAxis("Mouse Y");

	}


















}
