using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabRat : NPC
{
	private bool _isPlayerInRange;

	public void Start()
	{
        _isPlayerInRange = default;
	}

    private void Update()
    {

    }

	public override void InRange()
	{
        Debug.Log($"<{name}> is in range");
        _isPlayerInRange = true;
	}

	public override void NoLongerInRange()
	{

        Debug.Log($"<{name}> is no longer in range");
        _isPlayerInRange = false;
	}

	public override void Interact()
	{
		Debug.Log($"Interacted with <{name}>");
	}
}
