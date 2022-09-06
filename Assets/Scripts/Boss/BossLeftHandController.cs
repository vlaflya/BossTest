using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossLeftHandController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform handTarget;
    [SerializeField] private Transform handAnimationTarget;
    [SerializeField] private float playerFollowSpeed;
    [SerializeField] private Transform playerShootFollow;
    public Vector3 angle;
    private bool syncPositionToAnimationTarget = true;
    private bool syncRotationToAnimationTarget = true;
    private bool pointAtPlayer;

    void Update()
    {
        if (syncPositionToAnimationTarget)
            handTarget.position = handAnimationTarget.position;
        if (syncRotationToAnimationTarget)
            handTarget.rotation = handAnimationTarget.rotation;
        playerShootFollow.position = Vector3.Lerp(playerShootFollow.position, player.position, Time.deltaTime * playerFollowSpeed);
        if (pointAtPlayer) {
            Quaternion rot = Quaternion.LookRotation(playerShootFollow.position - handTarget.position, Vector3.left);
            handTarget.rotation = Quaternion.Lerp(handTarget.rotation, rot, Time.deltaTime * 5);
        }
    }

    public void LeftHandStartPointAtPlayer() {
        pointAtPlayer = true;
    }

    public void LeftHandEndPointAtPlayer()
    {
        pointAtPlayer = true;
    }

    public void UnsyncLeftTargetPosition()
    {
        syncPositionToAnimationTarget = false;
    }

    public void UnsyncLeftTargetRotation()
    {
        syncRotationToAnimationTarget = false;
    }

    public void ResyncLeftTargetPosition(float time)
    {
        handTarget.DOMove(handAnimationTarget.position, time).OnComplete(() => {
            syncPositionToAnimationTarget = true;
        });
    }

    public void ResyncLeftTargetRotation(float time)
    {
        handTarget.DORotate(handAnimationTarget.eulerAngles, time).OnComplete(() => {
            syncRotationToAnimationTarget = true;
        });
    }
}
