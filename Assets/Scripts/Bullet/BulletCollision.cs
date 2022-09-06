using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletCollision : MonoBehaviour
{

    public TriggerEvent onCollision = new TriggerEvent();
    private void OnTriggerEnter(Collider other)
    {
        Hit(other);
    }
    public virtual void Hit(Collider other) {
        TriggerParams param = new TriggerParams(other.gameObject, transform.position);
        onCollision.Invoke(param);
    }

    public class TriggerEvent : UnityEvent<TriggerParams> {}
    public class TriggerParams {
        public GameObject gameObject;
        public Vector3 position;
        public TriggerParams(GameObject g, Vector3 pos) {
            gameObject = g;
            position = pos;
        }
    }
}
