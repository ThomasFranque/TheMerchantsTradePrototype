using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency
{
	private const int _MAX_COIN				= 999999;
	private const int _MAX_GEMS				= 9999;
	private const int _GEM_VALUE_IN_COIN	= 85;

	public int Coin { get; private set; }
	public int Gems { get; private set; }
	public int TotalCurrencyValue { get => Coin + (Gems * _GEM_VALUE_IN_COIN); }

	public Currency(int startCoin, int startGems)
	{
		Coin = startCoin;
		Gems = startGems;
	}

	public void RecieveCurrency(int coin = 0, int gems = 0)
	{
		if (Coin + coin < _MAX_COIN)
			Coin += coin;
		else
			Coin = _MAX_COIN;

		if (Gems + gems < _MAX_GEMS)
			Gems += gems;
		else
			Gems = _MAX_GEMS;
	}

	public void SpendCurrency(int coin = 0, int gems = 0)
	{
		Coin -= coin;
		Gems -= gems;
	}

	public bool HasEnoughCurrency(int coin = 0, int gems = 0) => 
		Coin >= coin && Gems >= gems;
}
