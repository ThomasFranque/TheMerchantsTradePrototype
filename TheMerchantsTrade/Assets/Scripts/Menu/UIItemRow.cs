using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemRow : MonoBehaviour
{
	[SerializeField]
	private Image			_itemImage;
	[SerializeField]
	private TextMeshProUGUI _itemNameTxt;
	[SerializeField]
	private TextMeshProUGUI _itemRarityTxt;
	[SerializeField]
	private TextMeshProUGUI _askedPriceTxt;
	[SerializeField]
	private TextMeshProUGUI _flavorTextTxt;
	[SerializeField]
	private TextMeshProUGUI _ammountTxt;
	[SerializeField]
	private Button			_itemButton;

	private Collectable		_collectableScript;
	private string			_customName;
	private string			_flavorText;
	private int				_askedPrice;
	private int				_ammount;

	public void InitializeItemRow(Collectable item)
	{
		_collectableScript = item;

		if (_flavorTextTxt != null)
			_flavorTextTxt.text = _flavorText = item.Description;

		_itemNameTxt.text = name = _customName = item.CustomName;
		_itemImage.overrideSprite = item.ItemImage;
		_itemRarityTxt.text = item.Rarity.ToString();
		_askedPrice = item.FinalPrice;
		_askedPriceTxt.text = _askedPrice.ToString();
		_ammount = item.Ammount;

		if (item.MultiplierFactor > 1)
			_itemImage.color = new Color(255, 255, 0);

		UpdateRow();

		_itemButton.onClick.AddListener(MakeSelected);
	}

	public void UpdateRow()
	{
		_ammount = _collectableScript.Ammount;

		if (_ammountTxt != null)
		{
			_ammountTxt.text = _ammount.ToString();

			if (_ammount <= 0)
				_itemButton.interactable = false;
		}
	}

	private void MakeSelected()
	{
		TradeMenu.CurrentInstance.ChangeSelectedItem(this, _collectableScript);
	}
}
