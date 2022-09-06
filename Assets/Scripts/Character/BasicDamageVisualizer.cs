using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BasicDamageVisualizer : MonoBehaviour
{
    [SerializeField] private Shader shader;
    [SerializeField] private MeshRenderer renderer;
    [SerializeField] private float duration;
    [SerializeField] private Color color;
    [SerializeField] private float emission;
    [SerializeField] private float alpha = 1;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = new Material(shader);
        Material[] materials = new Material[renderer.materials.Length + 1];
        for (int i = 0; i < materials.Length - 1; i++) {
            materials[i] = renderer.materials[i];
        }
        materials[materials.Length - 1] = mat;
        mat.SetColor("_Color", color);
        mat.SetFloat("_EmissionAm", emission);
        mat.SetFloat("_Alpha", alpha);

        renderer.materials = materials;
    }
    public void TakeDamage() {
        mat.DOFloat(1, "_Timer", duration).OnComplete(() => { mat.SetFloat("_Timer", -1); });
    }
}
