using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMovementBehaviour : MonoBehaviour
{


	public float MoveSpeed = 5.0f;

	public float frequency = 20.0f;  // Speed of sine movement
	public float magnitude = 0.5f;   // Size of sine movement
	private Vector3 axis;

	private Vector3 pos;

	private bool checkChange = true;
	private int valueToRotateZ = 0;

	void Start()
	{
		pos = transform.position;
		axis = transform.up;  // May or may not be the axis you want

	}

	void Update()
	{

		Vector3 rotation = new Vector3(0, 0, valueToRotateZ);
		gameObject.transform.eulerAngles = rotation;

/*		if (pos.x > -2.5)
		{
			pos += -(transform.right * Time.deltaTime * MoveSpeed);

		}
		else
		{

			pos += (transform.right * Time.deltaTime * MoveSpeed);
		}*/
		transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;

		Debug.Log(transform.position);

		if (checkChange)
		{
			valueToRotateZ++;

			if (valueToRotateZ == 5)
			{
				checkChange = false;

			}
		}
		else
		{
			valueToRotateZ--;

			if (valueToRotateZ == -5)
			{
				checkChange = true;

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
  