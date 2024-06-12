using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum DamageType
{
    Physical,
    Magic,
    Penetration
}

public enum DefenseType
{
    Armor,
    MagicResist
}

public class Player : MonoBehaviour
{
    public int HP;
    public int HPMax;
    public int armor;
    public int magicResist;

    public TMP_Text HPText;
    public TMP_Text armorText;
    public TMP_Text magicResistText;
    public Transform attackTarget;

    private void Start()
    {
        HPText.text = HP.ToString();
        armorText.text = armor.ToString();
        magicResistText.text = magicResist.ToString();
    }

    public void TakeDefense(int amount, DefenseType defenseType)
    {
        switch(defenseType)
        {
            case DefenseType.Armor:
                armor += amount;
                UpdateArmor();
                break;
            case DefenseType.MagicResist:
                magicResist += amount;
                UpdateMagicResist();
                break;
        }
    }

    public void TakeDamage(int damage, DamageType damageType)
    {
        switch(damageType)
        {
            case DamageType.Penetration:
                HP -= damage;
                UpdateHP();
                break;

            case DamageType.Magic:
                if (magicResist > 0)
                {
                    magicResist--;
                    UpdateMagicResist();
                }
                else
                {
                    HP -= damage;
                    if(HP < 0)
                    {
                        HP = 0;
                    }
                    UpdateHP();
                }
                break;

            case DamageType.Physical:
                if(damage > armor)
                {
                    HP -= damage - armor;
                    if(HP < 0)
                    {
                        HP = 0;
                    }
                    armor = 0;
                    UpdateArmor();
                    UpdateHP();
                }
                else
                {
                    armor -= damage;
                    UpdateArmor();
                }
                break;
        }
    }

    private void UpdateHP()
    {
        HPText.text = HP.ToString();
        HPText.transform.GetComponent<TextUdateAnimation>().PlayAnimation(1);
    }

    private void UpdateMagicResist()
    {
        magicResistText.text = magicResist.ToString();
        magicResistText.transform.GetComponent<TextUdateAnimation>().PlayAnimation(1);
    }

    private void UpdateArmor()
    {
        armorText.text = armor.ToString();
        armorText.transform.GetComponent<TextUdateAnimation>().PlayAnimation(1);
    }
}
