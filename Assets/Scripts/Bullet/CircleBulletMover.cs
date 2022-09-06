using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleBulletMover : BulletMover
{
    public Vector3 centerPosition;
    public Vector3 pos;
    public float radius;
    private Vector3 forwDirection;
    private Vector3 curveDirection;
    public float forwardSpeed;
    public float curve;

    public override void OnStart()
    {
        Debug.Log("Start");
        centerPosition = FindObjectOfType<BossController>().transform.position;
        centerPosition.y = transform.position.y;
        pos = transform.position - centerPosition;
        pos.y = 0;
        radius = pos.magnitude;
        Debug.Log(radius);
        forwardSpeed = Time.fixedDeltaTime * speed;
        curve = radius - Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(forwardSpeed, 2));
    }

    public override void Move()
    {
        pos = transform.position - centerPosition;
        pos.y = 0;
        curveDirection = pos.normalized;
        forwDirection = Vector3.Cross(curveDirection, Vector3.up).normalized;
        Vector3 addPosF = forwDirection * forwardSpeed;
        Vector3 addPosC = curveDirection * curve;
        Debug.Log(addPosF + " " + addPosC);
        rigidbody.MovePosition(rigidbody.position + addPosF - addPosC);
        //rigidbody.MovePosition(centerPosition + pos * radius);
    }
}
