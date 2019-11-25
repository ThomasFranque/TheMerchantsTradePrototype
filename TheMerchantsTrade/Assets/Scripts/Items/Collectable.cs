using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
	public abstract Rarity Rarity { get; }
	public abstract ItemCategory Category { get; }
	public abstract string Description { get; }
	public abstract string CustomName { get; }

	public int BasePrice { get; set; }
	public byte Ammount { get; set; }

	public byte RarityTier => TradeHandler.GetRarityTier(Rarity);
	public int FinalPrice
	{
		get => Mathf.RoundToInt(
			BasePrice + (BasePrice * TradeHandler.GetRarityMultiplier(Rarity))
			);
	}

	public Collectable(int basePrice, byte ammount = 1)
	{
		Ammount = ammount;
		BasePrice = basePrice;
	}

	public override bool Equals(object other)
	{
		Collectable otherAsColl = other as Collectable;

		if (other == null) return false;

		return GetHashCode() == otherAsColl.GetHashCode();
	}

	public override int GetHashCode()
	{
		return CustomName.GetHashCode() ^ Rarity.GetHashCode();
	}

	public override string ToString()
	{
		return 
			"Name: " + CustomName + "\n" +
			"Rarity: Tier " + RarityTier + ", " + Rarity + "\n" +
			"Base Price: " + BasePrice + "\n" +
			"Final Price: " + FinalPrice + "\n" +
			"Ammount: " + Ammount;
	}
}
