using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private float maxRange = default;
    [SerializeField]
    private string npcTag = default;

    NPC _npcInRangeScript;
    RaycastHit _interactionLineHit;

    public bool HasNpcInRange
    {
        get => _interactionLineHit.distance <= maxRange - 0.02f &&
            _interactionLineHit.distance >= 0.1f;
    }

    private void Start()
    {
        _npcInRangeScript = default;
        _interactionLineHit = default;
    }

    private void Update()
    {
        UpdateInteractionRay();
    }

    private void UpdateInteractionRay()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _interactionLineHit, maxRange))
        {
            if (HasNpcInRange)
            {
                if ((_npcInRangeScript == null || _npcInRangeScript.gameObject != _interactionLineHit.collider.gameObject) &&
                    _interactionLineHit.collider.tag == npcTag)
                {
                    if (_npcInRangeScript != null) _npcInRangeScript.NoLongerInRange();

                    _npcInRangeScript = _interactionLineHit.collider.GetComponent<NPC>();
                    _npcInRangeScript.InRange();
                }

                if (Input.GetKeyDown(KeyCode.E))
                    InteractWith(_interactionLineHit.collider.gameObject);
            }
        }

        else if (_npcInRangeScript != null)
        {
            _npcInRangeScript.NoLongerInRange();
            _npcInRangeScript = null;
        }
    }

    private void InteractWith(GameObject gameObject)
    {
        _npcInRangeScript.Interact();
    }

    private void OnDrawGizmosSelected()
    {
        // Draws a blue line from this transform to the target
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
