using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(LineRenderer))]
public class LineTargets : MonoBehaviour
{
	public Transform target1;
	public Transform target2;

	private LineRenderer _line;
	private Vector3[] _positions = new Vector3[2];

	private void Awake()
	{
		_line = GetComponent<LineRenderer>();
	}

	private void Update()
	{
		_line.GetPositions(_positions);
		if(target1 != null)
		{
			_positions[0] = target1.position;
		}
		if(target2 != null)
		{
			_positions[1] = target2.position;
		}
		_line.SetPositions(_positions);
	}
}
