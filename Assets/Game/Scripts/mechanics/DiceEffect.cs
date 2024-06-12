using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEffect : MonoBehaviour
{
    [System.NonSerialized]
    public Dice dice;

    protected virtual void Start()
    {
        dice = transform.parent.parent.parent.GetComponent<Dice>();
    }
    public virtual void UseEffect()
    {
        /*if (spell != null)
        {
            GameObject spellGameObject = Instantiate(spell, transform.position, new Quaternion(0, 0, 0, 0));
            spellGameObject.GetComponent<Spell>().diceEffect = this;
        }*/
    }

    public virtual void ApplyData(DiceEffectScriptibleObject data)
    {
        //spell = data.spell;
        GetComponent<MeshFilter>().mesh = data.mesh;
        GetComponent<MeshRenderer>().material = data.material;
    }
}
