using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	private const float Y_ANGLE_MIN = -80.0f;
	private const float Y_ANGLE_MAX = 0.0f;

	[SerializeField]
	private Transform lookAt;
	[SerializeField]
	private float distance;
	[SerializeField]
	private float sensitivityX;
	[SerializeField]
	private float sensitivityY;
	[SerializeField]
	private float offsetX;
	[SerializeField]
	private float offsetY;

	private float currentX;
	private float currentY;

	private void Start()
	{
		currentX = 0.0f;
		currentY = 0.0f;
	}

	private void Update()
	{
		currentX += Input.GetAxis("Mouse X") * sensitivityX;
		currentY += Input.GetAxis("Mouse Y") * sensitivityY;

		currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
	}

	private void LateUpdate()
	{
		Vector3 dir = new Vector3(0, 0, distance);
		Vector3 offset = new Vector3(offsetX, offsetY, 0);
		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
		transform.position = lookAt.position + rotation * dir;
		transform.LookAt(lookAt.position);
		transform.position += offset;
	}
}
