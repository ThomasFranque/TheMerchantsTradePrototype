using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, IInteractable
{
	[SerializeField] private GameObject tradeMenuPrefab;
	[SerializeField] private string _customName;

	[TextArea]
	[SerializeField] private string[] _welcomeText;
	[TextArea]
	[SerializeField] private string[] _cannotAffordText;
	[TextArea]
	[SerializeField] private string[] _acceptTradeText;
	[TextArea]
	[SerializeField] private string[] _refuseTradeText;
	[TextArea]
	[SerializeField] private string[] _playerBoughtText;
	[TextArea]
	[SerializeField] private string[] _playerSoldText;
	[TextArea]
	[SerializeField] private string[] _randomText;

	public abstract void InRange();
	public abstract void NoLongerInRange();

	protected bool _isPlayerInRange;

	protected Inventory _inventory;
	protected GameObject _tradeMenuGO;
	protected TradeMenu _tradeMenuScript;

	public Inventory Inventory { get { return _inventory; } set { _inventory = value; } }

	protected virtual void Start()
	{
		_isPlayerInRange = default;

		name = _customName;

		GenerateInventory();
	}

	private void Update()
	{
		if (Player.instance.isInteracting && _tradeMenuGO != null)
			WhileTradeMenuOpen();
	}

	public virtual void Interact()
	{
		if (_tradeMenuGO != null) return;

		CreateMenu();
		Player.instance.isInteracting = true;
	}

	public virtual void ExitInteraction()
	{
		ExitMenu();
		Player.instance.isInteracting = false;
	}

	private void CreateMenu()
	{
		_tradeMenuGO = Instantiate(tradeMenuPrefab);
		_tradeMenuScript = _tradeMenuGO.GetComponent<TradeMenu>();
		_tradeMenuScript.Initialize(this);
	}

	private void ExitMenu()
	{
		Destroy(_tradeMenuGO);
		//_inventory.Refresh();
		Player.instance.RefreshInventory();
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
			maxItems = Random.Range(30, 50);

		_inventory = TradeHandler.GetRandomItemInventory(Random.Range((int)minItems, (int)maxItems));
	}

	public virtual bool ProposeSellingPrice(Collectable item, int suggestedPrice)
	{
		if (suggestedPrice >= item.FinalPrice) return true;

		return false;
	}

	public virtual bool ProposeBuyingPrice(Collectable item, int suggestedPrice)
	{
		if (suggestedPrice < item.FinalPrice) return true;

		return false;
	}

	public virtual void SellItem(Collectable item, int coin, int gems = 0)
	{
		_inventory.SellItem(item, coin, gems);
	}

	public void BuyItem(Collectable item, int coin = 0, int gems = 0)
	{
		Inventory.BuyItem(item, coin, gems);
	}

	public string GetRandomCantAffordTxt() => 
		_cannotAffordText[Random.Range(0, _cannotAffordText.Length )];

	public string GetRandomAcceptTradeTxt() =>
		_acceptTradeText[Random.Range(0, _acceptTradeText.Length )];
	public string GetRandomRefuseTradeTxt() =>
		_refuseTradeText[Random.Range(0, _refuseTradeText.Length )];

	public string GetRandomPlayerBoughtTxt() =>
		_playerBoughtText[Random.Range(0, _playerBoughtText.Length )];

	public string GetRandomPlayerSoldTxt() =>
		_playerSoldText[Random.Range(0, _playerSoldText.Length )];

	public string GetRandomWelcomeTxt() =>
		_welcomeText[Random.Range(0, _welcomeText.Length )];

	public string GetRandomRandomTxt() =>
		_randomText[Random.Range(0, _randomText.Length )];
}
