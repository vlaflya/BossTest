using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossRightHandController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform handTarget;
    [SerializeField] private Transform handAnimationTarget;
    private bool syncPositionToAnimationTarget = true;
    private bool syncRotationToAnimationTarget = true;
    [SerializeField] private float playerFollowSpeed;
    [SerializeField] private Transform playerSlamFollow;
    [SerializeField] private DamageZone slamZone;

    private void Update(){
        if (syncPositionToAnimationTarget)
            handTarget.position = handAnimationTarget.position;
        if (syncRotationToAnimationTarget)
            handTarget.rotation = handAnimationTarget.rotation;
        playerSlamFollow.position = Vector3.Lerp(playerSlamFollow.position, player.position, Time.deltaTime * playerFollowSpeed);
    }
    public void SlamPlayer() {
        UnsyncRightTargetPosition();
        UnsyncRightTargetRotation();
        slamZone.ShowZone();
        handTarget.DOMove(playerSlamFollow.position, 0.5f).OnComplete(() => { 
            slamZone.TryDealDamage();
            FindObjectOfType<PlayerController>().ShakeHead(1f, 20, 5);
        });
    }

    public void UnsyncRightTargetPosition()
    {
        syncPositionToAnimationTarget = false;
    }

    public void UnsyncRightTargetRotation()
    {
        syncRotationToAnimationTarget = false;
    }

    public void ResyncRightTargetPosition(float time)
    {
        handTarget.DOMove(handAnimationTarget.position, time).OnComplete(() => {
            syncPositionToAnimationTarget = true;
        });
    }

    public void ResyncRightTargetRotation(float time)
    {
        handTarget.DORotate(handAnimationTarget.eulerAngles, time).OnComplete(() => {
            syncRotationToAnimationTarget = true;
        });
    }
}
