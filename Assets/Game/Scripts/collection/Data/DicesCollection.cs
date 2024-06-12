using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceCollection", menuName = "ScriptableObjects/DiceCollection", order = 1)]
public class DicesCollection : ScriptableObject
{
    public DiceScriptibleObject[] diceList;
}
