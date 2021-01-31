using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AltitudeText : MonoBehaviour
{
	public Transform TargetTransform;

	private TextMeshProUGUI _text;

	private void Awake()
	{
		_text = GetComponent<TextMeshProUGUI>();
	}

	private void Update()
	{
		_text.text = $"Altitude : {TargetTransform.position.y.ToString()}";
	}
}
