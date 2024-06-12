using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceEffect", menuName = "ScriptableObjects/DiceEffectData/Attack", order = 1)]
public class AttackDEScriptibleObject : DiceEffectScriptibleObject
{
    public DamageType damageType;
    public int damage;
    public GameObject projectile;
}
