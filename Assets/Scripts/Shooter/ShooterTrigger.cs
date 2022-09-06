using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShooterTrigger : MonoBehaviour
{
    public TriggerEvent onTrigger = new TriggerEvent();
    public virtual void PullTrigger(int id = 0) {
        onTrigger.Invoke(id);
    }
    public void EmptyEvent() {}
    public class TriggerEvent : UnityEvent<int> { }
}
