using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LiftProvider : MonoBehaviour
{
	// reference only
	public float OutsidePressure;
	public float InsidePressure;
	public float CurrentForce;


	public float MaxHeight = 15f;

	[Range(0,10)]
	public float FirePressureChange = 1.1f;

	[Range(0, 10)]
	public float ReleasePressureChange = 0.5f;

	[Range(0, 10)]
	public float ConstantPressureChange = 0.1f;

	public float CorrectiveForceFactor = 5f;

	private Rigidbody _rigidBody;

	private void Awake()
	{
		_rigidBody = GetComponent<Rigidbody>();

		OutsidePressure = (1 - (transform.position.y / MaxHeight)) * 100;
		InsidePressure = OutsidePressure - 1;
	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		OutsidePressure = (1 - (transform.position.y / MaxHeight)) * 100;
		OutsidePressure = Mathf.Clamp(OutsidePressure, 0f, 100f);
		
		if (Input.GetKey(KeyCode.Space))
		{
			InsidePressure -= Time.fixedDeltaTime * FirePressureChange;
		}
		else if(Input.GetKey(KeyCode.LeftControl))
		{
			InsidePressure += Time.fixedDeltaTime * ReleasePressureChange;
		}

		InsidePressure += Time.fixedDeltaTime * ConstantPressureChange;

		InsidePressure = Mathf.Clamp(InsidePressure, 1f, 100f);

		CurrentForce = CorrectiveForceFactor * (OutsidePressure - InsidePressure);

		_rigidBody.AddForce(0f, CurrentForce, 0f,ForceMode.Force);
	}
}
