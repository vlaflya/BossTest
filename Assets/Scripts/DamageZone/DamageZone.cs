using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private Collider zone;
    [SerializeField] private int damage;
    private PlayerDamageTaker player;
    private bool active;
    public void ShowZone() {
        zone.enabled = true;
        active = true;
    }
    public void TryDealDamage() {
        if (player != null)
            player.DealDamage(damage, BulletHitter.BulletType.enemy);
        active = false;
        zone.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerDamageTaker>())
            player = other.GetComponent<PlayerDamageTaker>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (player == null)
            return;
        if (other.gameObject == player.gameObject)
            player = null;
    }
}
