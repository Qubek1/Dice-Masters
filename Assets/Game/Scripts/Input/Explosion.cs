using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion
{
    public void Boom(Vector3 position, float strenght, float radius)
    {
        foreach (Rigidbody rigidbody in GameManager.singleton.diceHolder.GetComponentsInChildren<Rigidbody>())
        {
            rigidbody.AddExplosionForce(strenght, position, radius, 0.7f, ForceMode.Impulse);
        }
    }
}
