using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class WindDirectionUI : MonoBehaviour
{
	public WindControls WindControl;
	public Camera Camera;

	private RectTransform _transform;
	
    void Awake()
    {
		_transform = GetComponent<RectTransform>();

	}
	
    void Update()
    {
		var rotation = _transform.rotation;

		var camForwardXZ = Camera.transform.forward;
		camForwardXZ.y = 0;

		var angleBetween = Vector3.SignedAngle(camForwardXZ, WindControl.WindForce, Vector3.up);

		var eulerAngles = rotation.eulerAngles;
		eulerAngles.z = -angleBetween;
		rotation.eulerAngles = eulerAngles;

		_transform.rotation = rotation;
	}
}
