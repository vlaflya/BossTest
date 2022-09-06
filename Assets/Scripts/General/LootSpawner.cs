using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : ObjectSpawner
{
    [SerializeField] private List<LootObject> lootObjects = new List<LootObject>();
    [SerializeField] private LootTable[] lootTables = new LootTable[Enum.GetNames(typeof(LootObject.Rarity)).Length];
    public override void SpawnObject(){
        int totalValue = 0;
        foreach (var t in lootTables) {
            totalValue += t.value;
        }
        int r = UnityEngine.Random.Range(0, totalValue);
        int minValue = 0;
        LootObject.Rarity rarity = lootTables[0].rarity;
        for (int i = 0; i < lootTables.Length; i++) {

            if (r >= minValue && r < lootTables[i].value + minValue) {
                rarity = lootTables[i].rarity;
                minValue = lootTables[i].value;
            }
        }
        List<LootObject> rarityObjects = new List<LootObject>();
        foreach (var l in lootObjects) {
            if (l.rarity == rarity)
                rarityObjects.Add(l);
        }
        r = UnityEngine.Random.Range(0, rarityObjects.Count);
        LootObject loot = rarityObjects[r];
        Instantiate(Resources.Load(loot.path) as GameObject, transform.position, Quaternion.identity);
    }
    [System.Serializable]
    public class LootTable {
        public LootObject.Rarity rarity;
        public int value;
    }
}
