using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpawner : MonoBehaviour
{
    public BoxCollider spawnArea;
    public float maxPushPower = 1f;

    public Dice[] Spawn(DiceScriptibleObject[] dices)
    {
        Dice[] diceInstances = new Dice[dices.Length];
        for(int i=0; i<dices.Length; i++)
        {
            diceInstances[i] = CreateDice(dices[i]);
        }
        return diceInstances;
    }

    public Dice CreateDice(DiceScriptibleObject data)
    {
        Dice dice = data.CreateDice(GameManager.singleton.diceHolder, RandomPointInBounds(spawnArea.bounds), Random.rotation);
        dice.GetComponent<Rigidbody>().AddForce(RandomVector3() * maxPushPower, ForceMode.Acceleration);
        return dice;
    }

    /*public void CreateDice(GameObject diceGameObject)
    {
        GameObject dice = Instantiate(diceGameObject, RandomPointInBounds(spawnArea.bounds), Random.rotation, GameManager.singleton.diceHolder);
        dice.GetComponent<Rigidbody>().AddForce(RandomVector3() * maxPushPower, ForceMode.Acceleration);
    }*/

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    public static Vector3 RandomVector3()
    {
        return new Vector3(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f) * 2f;
    }
}
