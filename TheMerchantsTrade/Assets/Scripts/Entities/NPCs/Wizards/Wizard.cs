using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : NPC
{
	private const byte _ITEM_MULTIPLIER_FACTOR = 2;

	[SerializeField] StoneType inflatuatedStoneType;

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
				MagicStone cAsMagicStone = c as MagicStone;
				if (cAsMagicStone.StoneType == inflatuatedStoneType)
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
