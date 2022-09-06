using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShieldVisuals : MonoBehaviour
{
    [SerializeField] private Material material;
    private bool active;

    private void Start()
    {
        material.SetFloat("_Active", 0);
    }

    public void ShowShield() {
        active = true;
        material.SetFloat("_Switch", 0);
        material.SetFloat("_LerpTime", 0);
        material.DOFloat(1, "_Active", 0.5f);
    }
    public void HideShield() {
        active = false;
        material.DOFloat(0, "_Active", 0.5f);
    }
    public void GetHit() {
        if (!active)
            return;
        material.SetFloat("_Switch", 0);
        material.DOFloat(1, "_LerpTime", 0.1f).OnComplete(() => {
            material.DOFloat(0, "_LerpTime", 0.1f);
        });


    }
    public void AddEnergy() {
        if (!active)
            return;
        material.SetFloat("_Switch", 1);
        material.DOFloat(1, "_LerpTime", 0.4f).OnComplete(() => {
            material.DOFloat(0, "_LerpTime", 0.4f);
        });
    }
    public void AddHealth() {
        if (!active)
            return;
        material.SetFloat("_Switch", 2);
        material.DOFloat(1, "_LerpTime", 0.4f).OnComplete(() => {
            material.DOFloat(0, "_LerpTime", 0.4f);
        });
    }
}
