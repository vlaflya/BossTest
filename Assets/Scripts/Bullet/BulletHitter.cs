using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static BulletCollision;

public class BulletHitter : MonoBehaviour
{
    public int damage;
    public enum BulletType {
        enemy,
        player,
        health,
        energy
    }
    public BulletType type;
    public BasicDamageTaker.Team hitTeam;
    public UnityEvent onDie = new UnityEvent();
    public virtual void Hit(TriggerParams param) {
        if (param.gameObject.GetComponent<BasicDamageTaker>()) {
            if (param.gameObject.GetComponent<BasicDamageTaker>().myTeam == hitTeam) {
                param.gameObject.GetComponent<BasicDamageTaker>().DealDamage(damage, type);
            }
        }
        onDie.Invoke();
    }
}
