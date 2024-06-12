using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Transform[] sides;
    [System.NonSerialized]
    public Rigidbody rigidBody;
    public bool enemyDice;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public DiceEffect WinningDiceEffect()
    {
        Transform winningSide = sides[0];
        foreach (Transform side in sides)
        {
            if(winningSide.position.y < side.position.y)
            {
                winningSide = side;
            }
        }
        return winningSide.GetComponentInChildren<DiceEffect>();
    }
}
