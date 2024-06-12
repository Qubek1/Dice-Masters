using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceEffect", menuName = "ScriptableObjects/DiceEffectData/BasicEffect", order = 1)]
public class DiceEffectScriptibleObject : ScriptableObject
{
    public GameObject diceEffectPrefab;
    public Mesh mesh;
    public Material material;

    public void Create(Transform holder)
    {
        Instantiate(diceEffectPrefab, holder, false);
        diceEffectPrefab.GetComponent<DiceEffect>().ApplyData(this);
    }
}
