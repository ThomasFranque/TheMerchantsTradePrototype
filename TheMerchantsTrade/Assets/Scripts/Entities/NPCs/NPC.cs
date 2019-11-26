using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, IInteractable
{
	[SerializeField] private GameObject tradeMenuPrefab;

	public abstract void InRange();
	public abstract void NoLongerInRange();

	protected bool _isPlayerInRange;

	protected Inventory _inventory;
	protected GameObject tradeMenuGO;
	protected TradeMenu tradeMenuScript;

	private void Update()
	{
		if (Player.instance.isInteracting && tradeMenuGO != null)
			WhileTradeMenuOpen();
	}

	public virtual void Interact()
	{
		if (tradeMenuGO != null) return;

		CreateMenu();
		Player.instance.isInteracting = true;
	}

	public virtual void ExitInteraction()
	{
		ExitMenu();
		Player.instance.isInteracting = false;
	}

	private void Start()
	{
		_isPlayerInRange = default;

		GenerateInventory();
	}

	private void CreateMenu()
	{
		tradeMenuGO = Instantiate(tradeMenuPrefab);
		tradeMenuScript = tradeMenuGO.GetComponent<TradeMenu>();

		foreach(Collectable c in _inventory.Items)
			tradeMenuScript.AddRow(c);
	}
	
	private void ExitMenu()
	{
		Destroy(tradeMenuGO);
	}

	private void WhileTradeMenuOpen()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			ExitInteraction();
	}

	protected void GenerateInventory(int? minItems = null, int? maxItems = null)
	{
		if (minItems == null)
			minItems = Random.Range(10, 20);

		if (maxItems == null)
			maxItems = Random.Range(20, 30);

		_inventory = TradeHandler.GetRandomItemInventory(Random.Range((int)minItems, (int)maxItems));
	}
}
