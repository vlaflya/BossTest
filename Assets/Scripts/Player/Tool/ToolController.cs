using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToolController : MonoBehaviour
{
    [SerializeField] private BasicTool tool;
    public string intarfaceName;
    public float needEnergy;
    public EnergyEvent onEnergyChanged = new EnergyEvent();
    private float currentEnergy = 0;
    private void Start()
    {
        currentEnergy = needEnergy;
    }
    public void AddEnergy(float add) {
        if (currentEnergy + add > needEnergy) {
            currentEnergy = needEnergy;
            onEnergyChanged.Invoke(currentEnergy);
            return;
        }
        currentEnergy += add;
        onEnergyChanged.Invoke(currentEnergy);
    }
    public float GetEnergy() {
        return currentEnergy;
    }

    public void UseTool() {
        if (currentEnergy < needEnergy)
            return;
        currentEnergy = 0;
        onEnergyChanged.Invoke(currentEnergy);
        tool.Use();
    }
    public class EnergyEvent : UnityEvent<float> {}
}
