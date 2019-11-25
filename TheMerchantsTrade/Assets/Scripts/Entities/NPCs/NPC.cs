using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, IInteractable
{
	public abstract void InRange();
	public abstract void NoLongerInRange();
	public abstract void Interact();

	protected bool _isPlayerInRange;

	protected Inventory _inventory;

	private void Start()
	{
		_isPlayerInRange = default;
		_inventory = TradeHandler.GetRandomItemInventory(Random.Range(10, 20));

		foreach (Collectable c in _inventory.Items)
		{
			Debug.LogWarning(c);
		}
	}
}
