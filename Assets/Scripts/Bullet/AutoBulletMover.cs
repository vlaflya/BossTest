using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBulletMover : BulletMover
{
    [SerializeField] private float lookSpeed;
    private Transform player;

    public override void OnStart(){
        player = FindObjectOfType<PlayerController>().transform;
    }
    public override void Move(){
        Quaternion rot = Quaternion.LookRotation(player.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, lookSpeed * Time.fixedDeltaTime);
        base.Move();
    }
}
