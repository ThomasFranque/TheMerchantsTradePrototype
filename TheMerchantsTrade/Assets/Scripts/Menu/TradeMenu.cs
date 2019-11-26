using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeMenu : MonoBehaviour
{
	private const float ITEM_ADDICTIVE_Y = 75;
	private const float FIRST_ITEM_Y = 45;

	[SerializeField] private Transform contents;
	[SerializeField] private GameObject itemRowPrefab;

	private int currentItemYIndex;

	private void Start()
	{
		currentItemYIndex = 0;
	}

	public void AddRow(Collectable c)
	{
		if (c == null) return;

		Vector3 rowRectPosition = 
			new Vector2(
				contents.position.x, 
				contents.position.y - FIRST_ITEM_Y - (ITEM_ADDICTIVE_Y * currentItemYIndex));

		GameObject itemRowGO = 
		Instantiate(
			itemRowPrefab, 
			transform.position, 
			Quaternion.identity, 
			contents);

		itemRowGO.transform.position = rowRectPosition;
		
		itemRowGO.GetComponent<UIItemRow>().InitializeItemRow(c);

		currentItemYIndex++;
	}
}
