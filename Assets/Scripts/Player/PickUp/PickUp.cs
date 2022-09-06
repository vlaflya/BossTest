using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPickup", menuName = "MyScriptableObjects/PickUp")]
public class PickUp : ScriptableObject
{
    public string objectPath;
    public PickUpType type;
    public enum PickUpType {
        gun,
        tool
    }

}
