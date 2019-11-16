using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, IInteractable
{
	public abstract void InRange();
	public abstract void NoLongerInRange();
	public abstract void Interact();
}
