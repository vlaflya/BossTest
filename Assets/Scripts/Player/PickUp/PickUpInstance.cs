using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInstance : MonoBehaviour
{
    [SerializeField] private PickUp pick;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerInventoryController>())
            return;
        other.GetComponent<PlayerInventoryController>().PickObject(pick);
        Destroy(gameObject);
    }
}
