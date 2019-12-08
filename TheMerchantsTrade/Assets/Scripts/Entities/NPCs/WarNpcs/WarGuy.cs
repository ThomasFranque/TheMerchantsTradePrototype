using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarGuy : NPC
{
	private const byte _ITEM_MULTIPLIER_FACTOR = 2;

	[SerializeField] WarGearType inflatuatedWarGearType;

	protected override void Start()
	{
		base.Start();
		// aa
		ApplyMultiplyersToInventory();
	}

	private void ApplyMultiplyersToInventory()
	{
		foreach (Collectable c in _inventory.Items)
			if (c is MagicStone)
			{
				WarItem cAsWarItem = c as WarItem;
				if (cAsWarItem.GearType == inflatuatedWarGearType)
					c.MultiplierFactor = _ITEM_MULTIPLIER_FACTOR;
			}
	}

	public override void InRange()
	{
		Debug.Log("aaaaa");
	}

	public override void NoLongerInRange()
	{		
	}
}
