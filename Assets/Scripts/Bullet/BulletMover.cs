using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speed;
    public Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void OnStart()
    {
    }

    public virtual void Move() {
        rigidbody.MovePosition(rigidbody.position + transform.forward * speed * Time.fixedDeltaTime);
    }
}
