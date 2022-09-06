using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicDamageTaker : MonoBehaviour
{
    public int maxHp;
    public Team myTeam;
    public enum Team
    {
        player,
        enemy
    }
    public UnityEvent onTakeDamage = new UnityEvent();
    public HealthEvent onHealthChange = new HealthEvent();
    public UnityEvent onDeath = new UnityEvent();
    public int hp;

    private void Start()
    {
        hp = maxHp;
    }

    private void Update()
    {
        OnUpdate();
    }

    public virtual void OnUpdate() {}

    public int GetHp() {
        return hp;
    }

    public virtual void DealDamage(int damage, BulletHitter.BulletType type){
        hp -= damage;
        onTakeDamage.Invoke();
        onHealthChange.Invoke(hp);
        if (hp <= 0)
            Die();
    }
    public virtual void Die() {
        onDeath.Invoke();
    }
    public class HealthEvent : UnityEvent<int> { }
}
