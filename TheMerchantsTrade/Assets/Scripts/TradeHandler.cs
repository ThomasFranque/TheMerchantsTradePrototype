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
				break;
			case Rarity.Uncommon:
				multipier = .05f;
				break;
			case Rarity.Rare:
				multipier = .25f;
				break;
			case Rarity.VeryRare:
				multipier = .35f;
				break;
			case Rarity.Legendary:
				multipier = .45f;
				break;
			case Rarity.Ancient:
				multipier = .60f;
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
}
