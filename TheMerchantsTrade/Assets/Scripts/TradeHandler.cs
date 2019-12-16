using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TradeHandler
{
	public static float GetRarityMultiplier(Rarity rarity)
	{
		float multipier = .0f;

		switch (rarity)
		{
			case Rarity.Common:
				multipier = GameInfo.COMMON_RARITY_MULTIPLIER;
				break;
			case Rarity.Uncommon:
				multipier = GameInfo.UNCOMMON_RARITY_MULTIPLIER;
				break;
			case Rarity.Rare:
				multipier = GameInfo.RARE_RARITY_MULTIPLIER;
				break;
			case Rarity.VeryRare:
				multipier = GameInfo.VERY_RARE_RARITY_MULTIPLIER;
				break;
			case Rarity.Legendary:
				multipier = GameInfo.LEGENDAY_RARITY_MULTIPLIER;
				break;
			case Rarity.Ancient:
				multipier = GameInfo.ANCIENT_RARITY_MULTIPLIER;
				break;
		}

		return multipier;
	}

	public static byte GetRarityTier(Rarity rarity)
	{
		byte tier = 1;

		switch (rarity)
		{
			case Rarity.Common:
			case Rarity.Uncommon:
				break;
			case Rarity.Rare:
			case Rarity.VeryRare:
				tier = 2;
				break;
			case Rarity.Legendary:
			case Rarity.Ancient:
				tier = 3;
				break;
		}

		return tier;
	}

	public static Rarity GetRandomRarity(byte maxTier)
	{
		Rarity rarity = default;

		float tier1Chance = .6f;
		float tier2Chance = .3f;
		float tier3Chance = .1f;

		float choice = default;

		choice = Random.Range(0.0f, 1.0f);

		if (choice < tier1Chance || maxTier == 1)
			rarity = RandomT1Rarity();
		else if (choice < tier1Chance + tier2Chance || maxTier == 2)
			rarity = RandomT2Rarity();
		else if (choice < tier1Chance + tier2Chance + tier3Chance)
			rarity = RandomT3Rarity();

		return rarity;
	}

	// ADD OPTIONAL PROPERTIE FOR NPC TYPE LATER
	public static Inventory GetRandomItemInventory(int ammount)
	{
		Inventory inventory;
		inventory = new Inventory(Random.Range(200, 500), Random.Range(5, 100));

		for (int i = 0; i < ammount; i++)
			inventory.AddItem(GetRandomItem());

		return inventory;
	}

	private static Rarity RandomT1Rarity()
	{
		Rarity rarity = default;
		double randChoice = Random.Range(0.0f, 1.0f);

		if (randChoice < .55f)
			rarity = Rarity.Common;
		else
			rarity = Rarity.Uncommon;

		return rarity;
	}
	private static Rarity RandomT2Rarity()
	{
		Rarity rarity = default;
		double randChoice = Random.Range(0.0f, 1.0f);

		if (randChoice < .75f)
			rarity = Rarity.Rare;
		else
			rarity = Rarity.VeryRare;

		return rarity;
	}
	private static Rarity RandomT3Rarity()
	{
		Rarity rarity = default;
		double randChoice = Random.Range(0.0f, 1.0f);

		if (randChoice < .85f)
			rarity = Rarity.Legendary;
		else
			rarity = Rarity.Ancient;

		return rarity;
	}

	private static Collectable GetRandomItem()
	{
		Collectable item = null;

		float randPercentage = Random.Range(0.0f, 1.0f);
		byte randTier = GetRarityTier(GetRandomRarity((byte)Random.Range(0, 3)));

		switch (Random.Range(0, 2))
		{
			// War gear
			case 0:
				switch (Random.Range(0, 2))
				{
					// Sword
					case 0:
						item = CreateItem(randTier, WarGearType.Sword);
						break;
					// Shield
					case 1:
						item = CreateItem(randTier, WarGearType.Shield);
						break;
					// Bow
					case 2:
						item = CreateItem(randTier, WarGearType.Bow);
						break;
				}
				break;
			// Magic stone
			case 1:
				switch (Random.Range(0, 3))
				{
					// Fire
					case 0:
						item = CreateItem(randTier, stoneType: StoneType.Fire);
						break;
					// Naturt
					case 1:
						item = CreateItem(randTier, stoneType: StoneType.Nature);
						break;
					// Necro
					case 2:
						item = CreateItem(randTier, stoneType: StoneType.Necromancy);
						break;
					// Water
					case 3:
						item = CreateItem(randTier, stoneType: StoneType.Water);
						break;
				}
				break;
			// Common
			case 2:
				Debug.LogWarning("CommonItemGenerated");
				break;
		}

		// In case of something somehow going wrong
		if (item == null)
		{
			item = new RustySword(Random.Range(5, 20));
			Debug.LogWarning("A created item as Null");
		}

		return item;
	}

	private static Collectable CreateItem
		(byte maxTier, WarGearType? warType = null, StoneType? stoneType = null)
	{
		Collectable collect = null;

		switch (maxTier)
		{
			case 1:
				if (warType != null)
				{
					if (warType == WarGearType.Sword)
						collect = new RustySword(Random.Range(5, 20));
					else if (warType == WarGearType.Shield)
						collect = new RustyShield(Random.Range(3, 15));
					else if (warType == WarGearType.Bow)
						collect = new StickAndString(Random.Range(4, 17));
				}
				else if (stoneType != null)
				{
					if (stoneType == StoneType.Fire)
						collect = new Firecell(Random.Range(8, 23));
					else if (stoneType == StoneType.Nature)
						collect = new Leafcell(Random.Range(8, 23));
					else if (stoneType == StoneType.Necromancy)
						collect = new Bloodcell(Random.Range(8, 23));
					else if (stoneType == StoneType.Water)
						collect = new Watercell(Random.Range(8, 23));
				}
				break;
			case 2:
				if (warType != null)
				{
					if (warType == WarGearType.Sword)
						collect = new ShinySword(Random.Range(30, 75));
					else if (warType == WarGearType.Shield)
						collect = new ShinyShield(Random.Range(20, 55));
					else if (warType == WarGearType.Bow)
						collect = new WellCraftedBow(Random.Range(16, 47));
				}
				else if (stoneType != null)
				{
					if (stoneType == StoneType.Fire)
						collect = new Burnedzima(Random.Range(40, 80));
					else if (stoneType == StoneType.Nature)
						collect = new Naturezima(Random.Range(40, 80));
					else if (stoneType == StoneType.Necromancy)
						collect = new Necrozima(Random.Range(40, 80));
					else if (stoneType == StoneType.Water)
						collect = new Moisterzima(Random.Range(40, 80));
				}
				break;
			case 3:
				if (warType != null)
				{
					if (warType == WarGearType.Sword)
						collect = new DivineSword(Random.Range(60, 210));
					else if (warType == WarGearType.Shield)
						collect = new DivineShield(Random.Range(50, 180));
					else if (warType == WarGearType.Bow)
						collect = new DivineBow(Random.Range(40, 155));
				}
				else if (stoneType != null)
				{
					if (stoneType == StoneType.Fire)
						collect = new LavaStone(Random.Range(100, 300));
					else if (stoneType == StoneType.Nature)
						collect = new NatureStone(Random.Range(100, 300));
					else if (stoneType == StoneType.Necromancy)
						collect = new LifeStone(Random.Range(100, 300));
					else if (stoneType == StoneType.Water)
						collect = new DepthStone(Random.Range(100, 300));
				}
				break;
		}

		return collect;
	}
}
