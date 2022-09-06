using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitter : BulletHitter
{
    private PlayerDamageTaker player;
    private void Start()
    {
        player = FindObjectOfType<PlayerDamageTaker>();
    }
    public override void Hit(BulletCollision.TriggerParams param)
    {
        Debug.Log(param.gameObject);
        if (param.gameObject.GetComponent<BasicDamageTaker>()){
            if (param.gameObject.GetComponent<BasicDamageTaker>().myTeam == hitTeam){
                param.gameObject.GetComponent<BasicDamageTaker>().DealDamage(damage, type);
                return;
            }
        }
        if (param.gameObject.GetComponent<BulletHitter>()) {
            BulletHitter bulletHitter = param.gameObject.GetComponent<BulletHitter>();
            if (bulletHitter.hitTeam == hitTeam)
                return;
            switch (bulletHitter.type)
            {
                case (BulletType.enemy):
                    {
                        break;
                    }
                case (BulletType.health):
                    {
                        player.Heal(1);
                        break;
                    }
                case (BulletType.energy):
                    {
                        player.AddEnergy(1);
                        break;
                    }
            }
            return;
        }
        //onDie.Invoke();
    }
}
