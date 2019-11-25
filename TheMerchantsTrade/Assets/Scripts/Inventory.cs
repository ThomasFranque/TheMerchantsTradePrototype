using System.Collections;
using System.Collections.Generic;

public class Inventory
{
	public ICollection<Collectable> Items { get; private set; }

	public Inventory()
	{
		Items = new List<Collectable>();
	}

	// FIX ADD NOT WORKING
	public void AddItem(Collectable item)
	{
		bool wasAdded = false;
		foreach (Collectable c in Items)
		{
			wasAdded = false;

			if (c.Equals(item) && c != null)
			{
				c.Ammount++;
				wasAdded = true;
				break;
			}
		}

		if (!wasAdded)
			Items.Add(item);
	}
}

