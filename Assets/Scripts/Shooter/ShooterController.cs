using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] private Shooter shooter;
    [SerializeField] private ShooterTrigger trigger;
    private void Start()
    {
        trigger.onTrigger.AddListener(TriggerShooter);
    }
    private void TriggerShooter(int id) {
        shooter.Shoot(id);
    }
}
