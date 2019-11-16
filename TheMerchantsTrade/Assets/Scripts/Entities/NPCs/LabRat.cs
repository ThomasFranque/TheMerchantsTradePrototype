using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabRat : NPC
{
	private bool playerInRange;

	public void Start()
	{
		playerInRange = false;
	}

	public override void InRange()
	{
		transform.position = new Vector3
			(
			transform.position.x,
			transform.position.y + 1.0f,
			transform.position.z
			);

		playerInRange = true;
	}

	public override void NoLongerInRange()
	{

		transform.position = new Vector3
			(
			transform.position.x,
			transform.position.y - 1.0f,
			transform.position.z
			);

		playerInRange = false;
	}

	public override void Interact()
	{
		Debug.Log(name);
	}
}
