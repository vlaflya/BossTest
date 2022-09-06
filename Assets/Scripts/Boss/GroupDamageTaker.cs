using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroupDamageTaker : BasicDamageTaker
{
    [SerializeField] private List<PartDamageTaker> damageTakers = new List<PartDamageTaker>();
    public UnityEvent onHalfHp = new UnityEvent();
    private bool inSecondPhase;
    private void Start()
    {
        hp = maxHp;
        foreach (var taker in damageTakers) {
            taker.onHealthChange.AddListener(RecieveDamage);
        }
    }
    public void RecieveDamage(int damage) {
        hp -= damage;
        Debug.Log(hp);
        onTakeDamage.Invoke();
        onHealthChange.Invoke(hp);
        if (hp <= maxHp / 2 && !inSecondPhase) {
            inSecondPhase = true;
            FindObjectOfType<BossController>().SecondPhaseStart();
        }
        if (hp <= 0)
            Die();
    }
}
