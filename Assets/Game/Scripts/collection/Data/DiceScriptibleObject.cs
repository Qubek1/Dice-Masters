using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dice", menuName = "ScriptableObjects/Dice", order = 1)]
public class DiceScriptibleObject : ScriptableObject
{
    public int sides = 6;
    public DiceEffectScriptibleObject[] diceEffects;
    public GameObject dicePrefab;

    public Dice CreateDice(Transform holder, Vector3 position, Quaternion rotation)
    {
        Dice dice = Instantiate(dicePrefab, position, rotation, holder).GetComponent<Dice>();
        for (int i = 0; i < sides; i++)
        {
            if (diceEffects[i] != null)
            {
                diceEffects[i].Create(dice.sides[i]);
            }
        }
        return dice;
    }
}
