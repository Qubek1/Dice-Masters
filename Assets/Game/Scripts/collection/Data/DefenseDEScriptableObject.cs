using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceEffect", menuName = "ScriptableObjects/DiceEffectData/Defense", order = 1)]
public class DefenseDEScriptableObject : DiceEffectScriptibleObject
{
    public int amount;
    public DefenseType defenseType;
}
