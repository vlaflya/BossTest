using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamageVisuals : MonoBehaviour
{
    [SerializeField] private Material material;

    private void Start()
    {
        material.SetFloat("_Alpha", 0);
    }
    public void TakeDamage() {
        material.DOFloat(1,"_Alpha",0.1f).OnComplete(() => {
            material.DOFloat(0, "_Alpha", 0.1f);
        });
    }
}
