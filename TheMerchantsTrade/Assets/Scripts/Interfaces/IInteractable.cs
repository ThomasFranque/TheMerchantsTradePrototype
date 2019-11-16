using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
	/// <summary>
	/// When is in range of the player
	/// </summary>
	void InRange();

	/// <summary>
	/// That
	/// </summary>
	void NoLongerInRange();

	/// <summary>
	/// When player presses key to interact with.
	/// </summary>
	void Interact();
}
