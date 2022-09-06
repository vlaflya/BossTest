using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExplosionHitter : BulletHitter
{
    [SerializeField] private float maxSize;
    [SerializeField] private float time;
    private void Start()
    {
        transform.DOScale(Vector3.one * maxSize, time).OnComplete(() => {
            onDie.Invoke();
        });
    }
    public override void Hit(BulletCollision.TriggerParams param)
    {
        Debug.Log(param.gameObject.name);
        if (param.gameObject.GetComponent<BasicDamageTaker>())
        {
            if (param.gameObject.GetComponent<BasicDamageTaker>().myTeam == hitTeam)
            {
                param.gameObject.GetComponent<BasicDamageTaker>().DealDamage(damage, type);
            }
        }
    }
}
