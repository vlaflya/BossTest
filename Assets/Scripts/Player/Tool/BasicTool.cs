using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicTool : MonoBehaviour
{
    public UnityEvent onUse = new UnityEvent();
    public virtual void Use() {
        Debug.Log("Tool used!");
        onUse.Invoke();
    }
}
