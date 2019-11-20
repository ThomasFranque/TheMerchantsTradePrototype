using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabRat : NPC
{
	private bool _isPlayerInRange;

	private List<Collectable> _inventory;

	public void Start()
	{
		_inventory = new List<Collectable>();
		_isPlayerInRange = default;

		// THIS WILL BE ADDED ON THE NPC.CS ONLY HERE FOR DEBUG
		_inventory.Add(new RustySword(25));
		_inventory.Add(new Firecell(25));

		foreach (Collectable c in _inventory)
		{
			Debug.LogWarning("Name: " + c.CustomName);
			Debug.Log("Rarity: Tier " + c.RarityTier + ", " + c.Rarity);
			Debug.Log("Base Price: " + c.BasePrice);
			Debug.Log("Final Price: " + c.FinalPrice);
		}
		// #####################################################
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
