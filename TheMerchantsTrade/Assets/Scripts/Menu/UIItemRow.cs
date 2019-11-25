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
	private TextMeshProUGUI _flavorTextTxt;
	[SerializeField]
	private TextMeshProUGUI _ammountTxt;

    public string Name { get; private set; }
    public string FlavorText { get; private set; }
    public int Ammount { get; private set; }

	private void Start()
	{

	}

	public void InitializeItemRow(Image itemImg, string name, string flavorTxt, int ammount)
	{
		_itemImage = itemImg;
		Ammount = ammount;

		_flavorTextTxt.text = FlavorText = flavorTxt;
		_itemNameTxt.text = Name = name;
		_ammountTxt.text = Ammount.ToString();
	}

}
