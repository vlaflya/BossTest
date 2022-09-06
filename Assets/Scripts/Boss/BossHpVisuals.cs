using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BossHpVisuals : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private BasicDamageTaker damageTaker;

    private void Start()
    {
        hpSlider.maxValue = damageTaker.maxHp;
        hpSlider.value = damageTaker.maxHp;
        damageTaker.onHealthChange.AddListener(ChangeHp);
    }
    public void StartFight() {
        canvasGroup.DOFade(1, 1f);
    }
    public void ChangeHp(int hp) {
        hpSlider.DOValue(hp, 0.5f);
    }
}
