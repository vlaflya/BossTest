using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordVisualsController : MonoBehaviour
{
    [SerializeField] private MeshRenderer blade;
    [SerializeField] private Shader shader;
    public float chargeTime;
    public float readyTime;
    private Material material;
    private void Start()
    {
        material = new Material(shader);
        blade.material = material;
    }
    private void Update()
    {
        material.SetFloat("_ChargeTime", chargeTime);
        material.SetFloat("_ReadyTime", readyTime);
    }
}
