using System;
using UnityEngine;

public abstract class Collectable : IEquatable<Collectable>
{
	[SerializeField]
	private Sprite itemImage;

	public abstract Rarity Rarity { get; }
	public abstract ItemCategory Category { get; }
	public abstract string Description { get; }
	public abstract string CustomName { get; }
	public int BasePrice { get; set; }
	public byte Ammount { get; set; }

	public Sprite ItemImage { get => itemImage; }
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

	public override string ToString()
	{
		return 
			"Name: " + CustomName + "\n" +
			"Rarity: Tier " + RarityTier + ", " + Rarity + "\n" +
			"Base Price: " + BasePrice + "\n" +
			"Final Price: " + FinalPrice + "\n" +
			"Ammount: " + Ammount;
	}

	public bool Equals(Collectable other)
	{
		return CustomName.Equals(other.CustomName) && Rarity.Equals(other.Rarity);
	}
}
