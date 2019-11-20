using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
	public abstract Rarity Rarity { get; }
	public abstract ItemCategory Category { get; }
	public abstract int BasePrice { get; }
	public abstract string Description { get; }
	public abstract string CustomName { get; }

	public byte RarityTier => TradeHandler.GetRarityTier(Rarity);
	public int FinalPrice
	{
		get => Mathf.RoundToInt(
			BasePrice + (BasePrice * TradeHandler.GetRarityMultiplier(Rarity))
			);
	}
}
