using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindControls : MonoBehaviour
{
	public float MinimumHeight = 5f;

	public float WindIntensity = 2f;
	public Vector3 BaseDirection = Vector3.right;
	public float RotationPerUnit = 36;

	public Vector3 WindForce;

	private Rigidbody _rigidBody;


	private void Awake()
	{
		_rigidBody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		var heightDiff = transform.position.y - MinimumHeight;
		if (heightDiff >= 0)
		{
			var directionVector = Quaternion.AngleAxis(heightDiff * RotationPerUnit, Vector3.up) * BaseDirection;
			WindForce = directionVector * WindIntensity;
			_rigidBody.AddForce(WindForce, ForceMode.Force);
		}
		else
		{
			var lowIntensity = (transform.position.y / MinimumHeight);
			WindForce = BaseDirection * lowIntensity * WindIntensity;
			_rigidBody.AddForce(WindForce, ForceMode.Force);
		}
	}
}
