using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEAttack : DiceEffect
{
    public DamageType damageType;
    public int damage;
    public GameObject projectilePrefab;

    private Player target;

    protected override void Start()
    {
        base.Start();
        if (dice.enemyDice)
        {
            if (GameManager.singleton != null)
                target = GameManager.singleton.Ally;
        }
        else
        {
            if (GameManager.singleton != null)
                target = GameManager.singleton.Enemy;
        }
    }

    public override void UseEffect()
    {
        base.UseEffect();
        GameManager.effectsRemaining++;
        GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, new Quaternion(0, 0, 0, 0));
        projectileInstance.transform.LookAt(target.transform.position, new Vector3(0, 1, 0));
        Projectile projectile = projectileInstance.GetComponent<Projectile>();
        projectile.damageType = damageType;
        projectile.damage = damage;
        projectile.target = target;
    }

    public override void ApplyData(DiceEffectScriptibleObject data)
    {
        base.ApplyData(data);
        AttackDEScriptibleObject newData = (AttackDEScriptibleObject)data;
        damageType = newData.damageType;
        damage = newData.damage;
        projectilePrefab = newData.projectile;
    }
}
