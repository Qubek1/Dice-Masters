using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseDE : DiceEffect
{
    public Player target;
    public int amount;
    public DefenseType defenseType;

    protected override void Start()
    {
        base.Start();
        if (dice.enemyDice)
        {
            if(GameManager.singleton != null)
                target = GameManager.singleton.Enemy;
        }
        else
        {
            if (GameManager.singleton != null)
                target = GameManager.singleton.Ally;
        }
    }

    public override void UseEffect()
    {
        base.UseEffect();
        target.TakeDefense(amount, defenseType);
    }

    public override void ApplyData(DiceEffectScriptibleObject data)
    {
        base.ApplyData(data);
        DefenseDEScriptableObject newData = (DefenseDEScriptableObject)data;
        amount = newData.amount;
        defenseType = newData.defenseType;
    }
}
