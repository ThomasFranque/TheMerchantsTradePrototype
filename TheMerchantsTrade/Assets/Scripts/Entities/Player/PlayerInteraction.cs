using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	[SerializeField]
	private float maxRange;
	[SerializeField]
	private string npcTag;
	NPC _npcInRangeScript;

	private void Start()
	{
		_npcInRangeScript = null;
	}

	private void FixedUpdate()
	{
		UpdateInteractionRay();
	}

	private void UpdateInteractionRay()
	{
		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit, maxRange))
		{
			if (_npcInRangeScript == null)
			{
				if (hit.collider.gameObject.tag == npcTag)
				{
					_npcInRangeScript = hit.collider.GetComponent<NPC>();
					_npcInRangeScript.InRange();

				}
			}
		}
		else
		{
			if (_npcInRangeScript != null)
			{
				_npcInRangeScript.NoLongerInRange();
				_npcInRangeScript = null;

			}
		}

		if (_npcInRangeScript != null)
		{
			if (Input.GetKeyDown(KeyCode.E))
				InteractWith(hit);
		}
	}

	private void InteractWith(RaycastHit hit)
	{
		_npcInRangeScript.Interact();
	}

	private void OnDrawGizmosSelected()
	{
		// Draws a blue line from this transform to the target
		Gizmos.color = Color.blue;
		Gizmos.DrawRay(transform.position, transform.forward);
	}
}
