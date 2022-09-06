using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLoot", menuName = "MyScriptableObjects/LootObject")]
public class LootObject : ScriptableObject
{
    public enum Rarity {
        common,
        rare
    }
    public Rarity rarity;
    public string path;
}
