using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDamageTaker : BasicDamageTaker
{
    public override void DealDamage(int damage, BulletHitter.BulletType type)
    {
        onTakeDamage.Invoke();
        onHealthChange.Invoke(damage);
        if (hp <= 0)
            Die();
    }
}
