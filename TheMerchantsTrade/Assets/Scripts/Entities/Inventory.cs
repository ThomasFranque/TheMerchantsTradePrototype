using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
	public List<Collectable> Items { get; private set; }

	public Currency Currency { get; }

	public Inventory(int startingCoin, int startingGems)
	{
		Items = new List<Collectable>();

		Currency = new Currency(startingCoin, startingGems);
	}

	public void AddItem(Collectable item)
	{
		bool wasAdded = false;
			
		foreach (Collectable c in Items)
		{
			wasAdded = false;

			if (c.Equals(item))
			{
				c.Ammount++;
				wasAdded = true;
				break;
			}
		}

		if (!wasAdded)
		{
			Items.Add(item);
			Items.Sort();
		}
	}

	public void SellItem(Collectable item, int recievedCoin, int recievedGems = 0, int ammount = 1)
	{
		Currency.RecieveCurrency(recievedCoin, recievedGems);
		RemoveItem(item, ammount);
	}

	public void BuyItem(Collectable item, int spentCoin, int spentGems = 0, int ammount = 1)
	{
		Currency.SpendCurrency(spentCoin, spentGems);
		AddItem(item);
	}

	public bool HasInInventory(Collectable item, int ammount)
	{
		if (Items.Contains(item))
			return Items[Items.IndexOf(item)].Ammount >= ammount;
		
		return false;
	}

	public void Refresh()
	{
		for (int i = 0; i < Items.Count; i++)
			if (!Items[i].inStock)
				Items.RemoveAt(i);
	}

	private void RemoveItem(Collectable item, int ammount)
	{
		int targetItemIdex;

		targetItemIdex = Items.IndexOf(item);

		if (Items[targetItemIdex].Ammount >= ammount)
		{
			Items[targetItemIdex].Ammount--;
		}
		else
			Items[targetItemIdex].Ammount = 0;
	}

}

