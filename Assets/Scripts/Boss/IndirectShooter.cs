using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndirectShooter : MonoBehaviour
{
    [SerializeField] List<ShooterTrigger> triggers = new List<ShooterTrigger>();
    public void Shoot(BossAnimationParam param){
        for (int i = 0; i < param.triggerIds.Count; i++) {
            triggers[param.triggerIds[i]].PullTrigger(param.bulletIds[i]);
        }
    }
    public void Test(GameObject ob) { }
}
