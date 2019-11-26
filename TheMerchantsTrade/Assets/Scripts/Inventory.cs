using System.Collections;
using System.Collections.Generic;

public class Inventory
{
	public ICollection<Collectable> Items { get; private set; }

	public Inventory()
	{
		Items = new List<Collectable>();
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
			Items.Add(item);
	}

}

