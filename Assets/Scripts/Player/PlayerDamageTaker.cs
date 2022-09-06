using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PlayerDamageTaker : BasicDamageTaker
{
    [SerializeField] private float shieldDecaySpeed;
    [SerializeField] private float shieldRachargeSpeed;
    [SerializeField] private PlayerInventoryController inventoryController;
    private ToolController toolController = null; 
    public UnityEvent onActivateShield = new UnityEvent();
    public UnityEvent onDisableShield = new UnityEvent();
    public UnityEvent onShieldHp = new UnityEvent();
    public UnityEvent onShieldEnergy = new UnityEvent();
    public UnityEvent onShieldDamage = new UnityEvent();
    private bool shieldActive;
    public float timer;

    private void Start()
    {
        hp = maxHp;
        inventoryController.tookTool.AddListener(OnTakeTool);
    }

    private void OnTakeTool(ToolController toolController) {
        this.toolController = toolController;
    }

    public override void OnUpdate()
    {
        if (shieldActive)
            return;
        if(timer < 100) {
            timer += Time.deltaTime * shieldRachargeSpeed;
            if (timer >= 100) {
                ActivateShield();
            }
        }
    }

    public void ActivateShield() {
        onActivateShield.Invoke();
        shieldActive = true;
    }

    public void Heal(int damage) {
        if (hp + damage > maxHp)
        {
            hp = maxHp;
            onHealthChange.Invoke(hp);
            return;
        }
        hp += damage;
        onHealthChange.Invoke(hp);
    }

    public void AddEnergy(int damage) {
        if (toolController == null)
            return;
        Debug.Log("Energy");
        onShieldEnergy.Invoke();
        toolController.AddEnergy(damage);
    }

    public override void DealDamage(int damage, BulletHitter.BulletType type)
    {
        if (shieldActive) {
            onTakeDamage.Invoke();
            shieldActive = false;
            timer = 0;
            onDisableShield.Invoke();
            return;
        }
        timer = 0;
        FindObjectOfType<PlayerController>().ShakeHead(0.3f, 5, 2);
        base.DealDamage(damage, type);
    }
}
