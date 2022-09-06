using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public UnityEvent onTrigger = new UnityEvent();
    public bool dispose;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player")) {
            onTrigger.Invoke();
            if (dispose)
                Destroy(gameObject);
        }
    }
}
