using System;
using UnityEngine;

public abstract class Collectable : IEquatable<Collectable>, IComparable<Collectable>
{
	[SerializeField]
	private Sprite _itemImage;

	public abstract Rarity Rarity { get; }
	public abstract ItemCategory Category { get; }
	public abstract string Description { get; }
	public abstract string CustomName { get; }
	public int BasePrice { get; set; }
	public int Ammount { get; set; }
	// In times
	public byte MultiplierFactor { get; set; }
	public bool inStock => Ammount > 0;

	public Sprite ItemImage { get => _itemImage; }
	public byte RarityTier => TradeHandler.GetRarityTier(Rarity);

	public int FinalPrice
	{
		get => Mathf.RoundToInt(
			BasePrice + (BasePrice * TradeHandler.GetRarityMultiplier(Rarity)))
			 * MultiplierFactor;
	}

	public int GemPrice => Mathf.RoundToInt(FinalPrice / 10);

	public Collectable(int basePrice, int ammount = 1)
	{
		Ammount = ammount;
		BasePrice = basePrice;
		MultiplierFactor = 1;
	}

	public Collectable GetNewClone(int ammount = 1)
	{
		Collectable newCollectable = (Collectable)MemberwiseClone();
		newCollectable.Ammount = ammount;
		return newCollectable;
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
		return CustomName.Equals(other.CustomName) && 
			Rarity.Equals(other.Rarity);
	}

	public int CompareTo(Collectable other)
	{
		if (other == null) return 1;

		if (Rarity == other.Rarity)
		{
			return other.FinalPrice.CompareTo(FinalPrice);
		}

		return other.Rarity.CompareTo(Rarity);
	}
}
