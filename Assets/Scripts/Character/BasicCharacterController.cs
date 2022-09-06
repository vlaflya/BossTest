using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicCharacterController : MonoBehaviour
{

    private void Start()
    {
    }
    public virtual void OnTakeDamage() {}
    public virtual void Die() {
        Destroy(gameObject);
    }
}
