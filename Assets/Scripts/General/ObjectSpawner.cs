using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    public virtual void SpawnObject() {
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }
}
