using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SinBulletMover : BulletMover
{
    public float distance;
    private bool movingForward = true;
    private Vector3 startPos;
    public override void OnStart()
    {
        startPos = transform.position;
    }
    public override void Move()
    {
        if (movingForward){
            rigidbody.MovePosition(rigidbody.position + transform.forward * Time.fixedDeltaTime);
            if (Vector3.Distance(transform.position, startPos) > distance) {
                Debug.Log("ChangeDir");
                movingForward = false;
            }
        }
        else {
            rigidbody.MovePosition(rigidbody.position - transform.forward * Time.fixedDeltaTime);
            if (Vector3.Distance(transform.position, startPos) < 0.1f){
                movingForward = true;
            }
        }
    }
}
