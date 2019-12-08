using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TradeMenu : MonoBehaviour
{
	public static TradeMenu CurrentInstance { get; private set; }

	private NPC					_targetNPC;
	private Collectable			_currentSelectedItem;
	private UIItemRow			_currentSelectedRow;
	private bool				_npcAcceptsPrice;
	private bool				_playerHasResources;
	private bool				_npcHasResources;
	private bool				_itemInStock;
	private bool				_playerIsBuying;
	private int					_currentProposedPrice;

	private event Action SellItem;
	private event Action BuyItem;
	private event Action ProposePrice;

	// Instantiation
	[Header("### Object Info ###")]
	[SerializeField] private Transform			_traderInventoryViewport;
	[SerializeField] private Transform			_playerInventoryViewport;
	[SerializeField] private GameObject			_itemRowPrefab;

	// Player Info
	[Header("### Player Info ###")]
	[SerializeField] private TextMeshProUGUI	_playerCoinTxt;
	[SerializeField] private TextMeshProUGUI	_playerGemsTxt;

	// Selected item
	[Header("### Selected Item Info ###")]
	[SerializeField] private GameObject			_selectedItemRegion;
	[SerializeField] private Image				_selectedItemImage;
	[SerializeField] private TextMeshProUGUI	_selectedItemNameTxt;
	[SerializeField] private TextMeshProUGUI	_selectedItemRarityTxt;
	[SerializeField] private TextMeshProUGUI	_selectedItemAskedCoinTxt;
	[SerializeField] private TextMeshProUGUI	_selectedItemAskedGemsTxt;
	[SerializeField] private Button				_buySellButton;
	[SerializeField] private Button				_proposePriceButton;
	[SerializeField] private TMP_InputField		_valueInputField;

	[Header("### Tab Management ###")]
	[SerializeField] private Button				_buyTabButton;
	[SerializeField] private Button				_sellTabButton;

	[Header("### Dialog Box ###")]
	[SerializeField] private TextMeshProUGUI	_dialogBoxText;
	[SerializeField] private TextMeshProUGUI	_npcNameText;

	private void Start()
	{
		CurrentInstance =		this;
		_npcAcceptsPrice =		false;
		_playerHasResources =	false;
		_npcHasResources =		false;
		_itemInStock =			true;
		_playerIsBuying =		true;
		_currentProposedPrice = 0;
		_currentSelectedItem =	null;
		_selectedItemRegion.SetActive(false);

		ProposePrice += UpdateProposedPrice;
		ProposePrice += CheckResources;
		ProposePrice += CheckPriceWithNpc;
		ProposePrice += CheckItemAvailability;
		ProposePrice += BuySellButtonUpdate;

		BuyItem += PerformBuy;
		BuyItem += UpdatePlayerCurrencyText;
		BuyItem += CheckPlayerResources;
		BuyItem += UpdateSelectedRow;
		BuyItem += CheckItemAvailability;
		BuyItem += BuySellButtonUpdate;
		
		SellItem += PerformSell;
		SellItem += UpdatePlayerCurrencyText;
		SellItem += CheckNPCResources;
		SellItem += UpdateSelectedRow;
		SellItem += CheckItemAvailability;
		SellItem += BuySellButtonUpdate;

		if (_buySellButton != null)
		{
			_buySellButton.onClick.AddListener(OnTradeItem);
			_buySellButton.interactable = false;

			_proposePriceButton.onClick.AddListener(OnProposePrice);
			_proposePriceButton.onClick.AddListener(UpdateDialogTxtOnProposePrice);

			_buyTabButton.onClick.AddListener(UpdateNPCInventoryRows);
			_buyTabButton.onClick.AddListener(BuySellButtonUpdate);
			_buyTabButton.onClick.AddListener(ClearSelectedItem);
			_buyTabButton.onClick.AddListener(TabChange);

			_sellTabButton.onClick.AddListener(UpdatePlayerInventoryRows);
			_sellTabButton.onClick.AddListener(BuySellButtonUpdate);
			_sellTabButton.onClick.AddListener(ClearSelectedItem);
			_sellTabButton.onClick.AddListener(TabChange);
		}
		_valueInputField.onValueChanged.AddListener(OnProposePrice);
		UpdatePlayerCurrencyText();
	}

	public void Initialize(NPC npc)
	{
		_targetNPC = npc;

		_npcNameText.text = _targetNPC.name;

		ChangeDialogBoxText(_targetNPC.GetRandomWelcomeTxt());
		UpdateNPCInventoryRows();
	}

	private void UpdatePlayerInventoryRows()
	{
		_traderInventoryViewport.gameObject.SetActive(false);
		UpdateRows(Player.instance.Inventory.Items, _playerInventoryViewport);
		_playerInventoryViewport.gameObject.SetActive(true);
	}
	private void UpdateNPCInventoryRows()
	{
		_playerInventoryViewport.gameObject.SetActive(false);
		UpdateRows(_targetNPC.Inventory.Items, _traderInventoryViewport);
		_traderInventoryViewport.gameObject.SetActive(true);
	}

	private void UpdateRows(List<Collectable> inventory, Transform viewport)
	{
		foreach (Transform child in viewport)
			Destroy(child.gameObject);

		for (int i = 0; i < inventory.Count; i++)
			AddRow(inventory[i], i, viewport);
	}

	private void AddRow(Collectable c, int index, Transform viewport)
	{
		if (c == null) return;

		GameObject itemRowGO = Instantiate( _itemRowPrefab, viewport);

		itemRowGO.GetComponent<UIItemRow>().InitializeItemRow(c);
	}

	public void ChangeSelectedItem(UIItemRow row, Collectable item)
	{
		_selectedItemImage.sprite = item.ItemImage;
		_selectedItemNameTxt.SetText(item.CustomName);
		_selectedItemRarityTxt.SetText(item.Rarity.ToString());
		_selectedItemAskedCoinTxt.SetText(item.FinalPrice.ToString());
		if (_targetNPC is Merchant)
			_selectedItemAskedGemsTxt.SetText(item.GemPrice.ToString());
		_selectedItemRegion.SetActive(true);

		_currentSelectedItem = item;
		_currentSelectedRow = row;

		_selectedItemRegion.SetActive(true);

		ChangeDialogBoxText(_targetNPC.GetRandomRandomTxt());

		ProposePrice.Invoke();
	}

	private void ClearSelectedItem()
	{
		_selectedItemRegion.SetActive(false);
	}

	private void TabChange()
	{
		_playerIsBuying = !_playerIsBuying;

		TextMeshProUGUI buySellButtonText =
			_buySellButton.GetComponentInChildren<TextMeshProUGUI>();
		if (!_playerIsBuying)
			buySellButtonText.text = "SELL";
		else
			buySellButtonText.text = "BUY";
	}

	private void OnProposePrice()
	{
		ProposePrice.Invoke();
	}

	private void OnProposePrice(string a = "a")
	{
		ProposePrice.Invoke();
	}
	private void OnTradeItem()
	{
		if (_playerIsBuying)
			OnBuyItem();
		else
			OnSellItem();
	}
	private void OnBuyItem()
	{
		BuyItem.Invoke();
	}

	private void OnSellItem()
	{
		SellItem.Invoke();
	}

	// BUYING
	private void UpdateProposedPrice()
	{
		if (_valueInputField.text.Length > 0)
			_currentProposedPrice = int.Parse(_valueInputField.text);
	}

	private void CheckPriceWithNpc()
	{
		if (_playerIsBuying)
			_npcAcceptsPrice =
				_targetNPC.ProposeSellingPrice(_currentSelectedItem, _currentProposedPrice);
		else
			_npcAcceptsPrice =
				_targetNPC.ProposeBuyingPrice(_currentSelectedItem, _currentProposedPrice);
	}

	private void UpdateDialogTxtOnProposePrice()
	{
		if (_npcAcceptsPrice)
			ChangeDialogBoxText(_targetNPC.GetRandomAcceptTradeTxt());
		else
			ChangeDialogBoxText(_targetNPC.GetRandomRefuseTradeTxt());

		if (!_playerHasResources && _playerIsBuying)
			ChangeDialogBoxText
				("Whoops, looks like you don't have enought to afford that...");
	}

	private void CheckResources()
	{
		if (_playerIsBuying)
			CheckPlayerResources();
		else
			CheckNPCResources();
	}

	private void CheckPlayerResources()
	{
		if (_targetNPC is Merchant)
			_playerHasResources =
				Player.instance.Inventory.Currency.HasEnoughCurrency(_currentProposedPrice, _currentSelectedItem.GemPrice);
		else
			_playerHasResources =
				Player.instance.Inventory.Currency.HasEnoughCurrency(_currentProposedPrice);

		if (!_playerHasResources)
			ChangeDialogBoxText
				("Whoops, looks like you don't have enought to afford that...");
	}

	private void CheckNPCResources()
	{
		_npcHasResources =
			_targetNPC.Inventory.Currency.HasEnoughCurrency(_currentProposedPrice);

		if (!_npcHasResources)
			ChangeDialogBoxText(_targetNPC.GetRandomCantAffordTxt());
	}

	private void PerformBuy()
	{
		_targetNPC.SellItem(_currentSelectedItem, _currentProposedPrice);
		if (_targetNPC is Merchant)
			Player.instance.BuyItem(_currentSelectedItem.GetNewClone(), _currentProposedPrice, _currentSelectedItem.GemPrice);
		else
			Player.instance.BuyItem(_currentSelectedItem.GetNewClone(), _currentProposedPrice);
	}

	// SELL
	private void PerformSell()
	{
		if (_targetNPC is Merchant)
			Player.instance.SellItem(_currentSelectedItem, _currentProposedPrice, _currentSelectedItem.GemPrice);
		else
			Player.instance.SellItem(_currentSelectedItem, _currentProposedPrice);

		_targetNPC.BuyItem(_currentSelectedItem.GetNewClone(), _currentProposedPrice);

	}

	private void CheckItemAvailability()
	{
		_itemInStock = _currentSelectedItem.inStock;

		if (!_itemInStock)
			ChangeDialogBoxText("Looks like that item is out of stock...");
	}

	// UPDATE UI
	private void ChangeDialogBoxText(string txt)
	{
		_dialogBoxText.text = txt;
	}

	private void UpdatePlayerCurrencyText()
	{
		_playerCoinTxt.SetText(Player.instance.Coin.ToString());
		_playerGemsTxt.SetText(Player.instance.Gems.ToString());
	}

	private void UpdateSelectedRow()
	{
		_currentSelectedRow.UpdateRow();
	}

	private void PlayerBoughtTextUpdate()
	{
		ChangeDialogBoxText(_targetNPC.GetRandomPlayerBoughtTxt());
	}

	private void PlayerSoldTextUpdate()
	{
		ChangeDialogBoxText(_targetNPC.GetRandomPlayerSoldTxt());
	}

	private void BuySellButtonUpdate()
	{
		if (_npcAcceptsPrice && 
			(_playerIsBuying ? _playerHasResources : _npcHasResources) && 
			_itemInStock)
			_buySellButton.interactable = true;
		else
			_buySellButton.interactable = false;
	}
}
