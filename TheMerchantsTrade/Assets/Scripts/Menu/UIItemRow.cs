using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemRow : MonoBehaviour
{
	[SerializeField]
	private Image _itemImage;
	[SerializeField]
	private TextMeshProUGUI _itemNameTxt;
	[SerializeField]
	private TextMeshProUGUI _itemRarityTxt;
	[SerializeField]
	private TextMeshProUGUI _flavorTextTxt;
	[SerializeField]
	private TextMeshProUGUI _ammountTxt;

	public Collectable ItemScript { get; private set; }
	private string customName;
	private string flavorText;
	private int ammount;

	private void Start()
	{

	}

	public void InitializeItemRow(Collectable c)
	{

		_flavorTextTxt.text = flavorText = c.Description;
		_itemNameTxt.text = name = customName = c.CustomName;
		_itemRarityTxt.text = c.Rarity.ToString();

		ammount = c.Ammount;
		_ammountTxt.text = ammount.ToString();
	}

}
