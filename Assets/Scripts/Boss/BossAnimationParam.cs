using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBossShootTrigger", menuName = "MyScriptableObjects/BossShootTrigger")]
public class BossAnimationParam : ScriptableObject
{
    public List<int> triggerIds;
    public List<int> bulletIds;
}
