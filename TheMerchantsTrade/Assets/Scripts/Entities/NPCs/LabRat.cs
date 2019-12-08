using UnityEngine;

public class LabRat : NPC
{
	public override void InRange()
	{
        //Debug.Log($"<{name}> is in range");
        _isPlayerInRange = true;
	}

	public override void NoLongerInRange()
	{

        //Debug.Log($"<{name}> is no longer in range");
        _isPlayerInRange = false;
	}

	public override void Interact()
	{
		base.Interact();

		Debug.Log($"Interacted with <{name}>");
		//foreach (Collectable c in _inventory.Items)
		//	Debug.Log(c);
	}
}
