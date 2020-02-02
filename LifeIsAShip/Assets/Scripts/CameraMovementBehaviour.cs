using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMovementBehaviour : MonoBehaviour
{


	public float MoveSpeed = 5.0f;

	public float frequency = 20.0f;  
	public float magnitude = 0.5f;   

	private Vector3 axis;

	private bool checkChange = true;
	private int valueToRotateZ = 0;
	float timeToUp = 0;
	public float controlTime = 0.5f;
	public float valueToAdd = 0.2f;

	void Start()
	{
		axis = transform.up;  

	}

	void Update()
	{

		timeToUp += Time.deltaTime;


		Vector3 rotation = new Vector3(0, 0, valueToRotateZ);
		gameObject.transform.eulerAngles = rotation;
		float correctedZ = -10;
		transform.position =  axis * Mathf.Sin(Time.time * frequency) * magnitude;
		Vector3 correctedFinal = transform.position;
		correctedFinal.z = correctedZ;
		transform.position = correctedFinal;

		if (timeToUp >= controlTime)
		{
			controlTime+= valueToAdd;
			if (checkChange)
			{
				valueToRotateZ++;

				if (valueToRotateZ == 2)
				{
					checkChange = false;

				}
			}
			else
			{
				valueToRotateZ--;

				if (valueToRotateZ == -2)
				{
					checkChange = true;

				}

			}

		}


	}

}

	// Use this for initialization

/*	private int valueToRotateZ = 0;
	private int valueToRotatey = 0;
	bool checkChange = true;
	bool checkDown = true;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{


		Vector3 rotation = new Vector3(0, 0, valueToRotateZ);

		Vector3 positon = new Vector3(0, valueToRotatey, 0);


		gameObject.transform.position = (gameObject.transform.right *Time.deltaTime*100) + gameObject.transform.up*Mathf.Sin(Time.deltaTime * 20f) * 50f;*/
/*
		if (checkChange)
		{
			valueToRotateZ++;

			if (valueToRotateZ == 45)
			{
				checkChange = false;
				checkDown = true;

			}

			if (valueToRotateZ % 5 == 0)
			{
				valueToRotatey++;
			}
		}
		else
		{
			valueToRotateZ--;

			if (valueToRotateZ == -45)
			{
				checkChange = true;

			}

			if (valueToRotateZ % 5 == 0 )
			{
				if (valueToRotatey == 0)
				{
					checkDown = false;

				}
				if (checkDown)
				{
					valueToRotatey--;
				}

				else
				{
					valueToRotatey++;
				}

			}
			
		}*/

/*}
}
*/
  