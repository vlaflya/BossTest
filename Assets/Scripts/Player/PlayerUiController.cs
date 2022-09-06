using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerUiController : MonoBehaviour
{
    [SerializeField] private PlayerInventoryController inventory;
    [SerializeField] private PlayerDamageTaker taker;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Text hpText;
    private int maxHp;

    [SerializeField] private CanvasGroup energyGroup;
    [SerializeField] private Slider energySlider;
    [SerializeField] private Text energyText;
    private float maxEnergy;


    [SerializeField] private CanvasGroup shieldGroup;
    [SerializeField] private Slider shieldSlider;
    public bool shieldReady;

    [SerializeField] private CanvasGroup gunGroup;
    [SerializeField] private Text gunName;

    [SerializeField] private CanvasGroup toolGroup;
    [SerializeField] private Text toolName;

    void Start()
    {
        maxHp = taker.maxHp;
        hpSlider.maxValue = maxHp;
        taker.onHealthChange.AddListener(ChangeHealth);
        inventory.tookTool.AddListener(OnTookTool);
        inventory.tookGun.AddListener(OnTookGun);
        ChangeHealth(maxHp);
    }

    private void Update()
    {
        shieldSlider.value = taker.timer;
        if (shieldSlider.value >= 100)
        {
            shieldReady = true;
            shieldGroup.DOFade(0, 0.2f);
        }
        else if (shieldReady) {
            shieldReady = false;
            shieldGroup.DOFade(1, 0.3f);
        }
    }

    private void OnTookTool(ToolController toolController) {
        energyGroup.DOFade(1, 1f);
        toolGroup.DOFade(1, 1f);
        toolName.text = toolController.intarfaceName;
        toolController.onEnergyChanged.AddListener(ChangeEnergy);
        maxEnergy = toolController.needEnergy;
        energySlider.maxValue = maxEnergy;
        ChangeEnergy(0);
    }
    private void OnTookGun(PlayerGunController gunController) {
        gunGroup.DOFade(1, 1f);
        gunName.text = gunController.intarfaceName;
    }

    private void ChangeHealth(int value) {
        hpText.text = value + "/" + maxHp;
        hpSlider.DOValue(value, 0.5f);
    }
    private void ChangeEnergy(float value) {
        energyText.text = value + "/" + maxEnergy;
        energySlider.DOValue(value, 0.5f);
    }

}
