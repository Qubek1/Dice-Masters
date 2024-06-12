using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CI.QuickSave;

public class GameManager : MonoBehaviour
{
    public Transform diceHolder;
    [System.NonSerialized]
    public Dice[] dices;
    [System.NonSerialized]
    public Dice[] allyDices;
    [System.NonSerialized]
    public Dice[] enemyDices;
    [System.NonSerialized]
    public static GameManager singleton;

    public DiceSpawner spawner;
    public Slider slider;
    public float roundDuration;
    public float roundBreakDuration;
    private float roundStartTime;
    private float roundBreakTime;

    public Player Ally;
    public Player Enemy;

    public DiceScriptibleObject[] allyDicesData;
    public DiceScriptibleObject[] EnemyDicesData;

    public GameObject VictoryScreen;
    public GameObject DefeatScreen;

    public static int effectsRemaining = 0;

    public DicesCollection dicesColletion;

    public enum GameState 
    {
        gameplay,
        waiting,
        summary,
        GameOver
    }

    public GameState gameState;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        List<int> playerDeck = Save.SaveSystem.Load(Save.DataType.Deck);
        allyDicesData = new DiceScriptibleObject[3];
        for(int i=0; i<3; i++)
        {
            allyDicesData[i] = dicesColletion.diceList[playerDeck[i]];
        }
        StartNewRound();
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.gameplay:
                slider.value = 1 - (Time.time - roundStartTime) / roundDuration;
                if (Time.time - roundStartTime >= roundDuration)
                {
                    gameState = GameState.waiting;
                }
                break;
            case GameState.waiting:
                if(!MovingDices())
                {
                    FinishRound();
                }
                break;
            case GameState.summary:
                if(effectsRemaining == 0)
                {
                    if (Time.time - roundBreakTime > roundDuration)
                    {
                        roundBreakTime = Time.time;
                        if(Ally.HP == 0)
                        {
                            Lose();
                            break;
                        }
                        if(Enemy.HP == 0)
                        {
                            Win();
                            break;
                        }

                    }
                    if (Time.time - roundBreakTime > roundBreakDuration)
                    {
                        foreach (Dice dice in dices)
                        {
                            Destroy(dice.gameObject);
                        }
                        StartNewRound();
                    }
                }
                break;
            case GameState.GameOver:
                break;
        }
    }

    private void Win()
    {
        Debug.Log("Wygranko");

        List<int> collection = Save.SaveSystem.Load(Save.DataType.Colletion);
        int i = (int)(Random.value * dicesColletion.diceList.Length);
        if(i == collection.Count)
        {
            i--;
        }
        if(!collection.Contains(i))
        {
            collection.Add(i);
            Dice newDice = dicesColletion.diceList[i].CreateDice(VictoryScreen.transform, new Vector3 (0, 0, 0), new Quaternion(0, 0, 0 ,0));
            newDice.GetComponent<Rigidbody>().isKinematic = true;
            newDice.GetComponent<Rigidbody>().useGravity = false;
            newDice.transform.localScale = Vector3.one * 50;
            newDice.transform.localPosition = new Vector3(0, -18, -222);
            newDice.GetComponent<BasicDiceRotation>().rotating = true;
        }
        Debug.Log(i);

        Save.SaveSystem.Save(Save.DataType.Colletion, collection);

        gameState = GameState.GameOver;
        VictoryScreen.SetActive(true);
    }

    private void Lose()
    {
        Debug.Log("Przegranko");
        gameState = GameState.GameOver;
        DefeatScreen.SetActive(true);
    }

    private bool MovingDices()
    {
        foreach(Dice dice in dices)
        {
            if(dice.rigidBody.velocity.magnitude != 0 || dice.rigidBody.angularVelocity.magnitude != 0)
            {
                return true;
            }
        }
        return false;
    }

    private void StartNewRound()
    {
        gameState = GameState.gameplay;
        roundStartTime = Time.time;
        allyDices = spawner.Spawn(allyDicesData);
        enemyDices = spawner.Spawn(EnemyDicesData);
        List<Dice> newDices = new List<Dice>();

        foreach (Dice dice in allyDices)
        {
            dice.enemyDice = false;
            newDices.Add(dice);
        }
        foreach (Dice dice in enemyDices)
        {
            dice.enemyDice = true;
            dice.GetComponent<MeshRenderer>().material.color = Color.Lerp(dice.GetComponent<MeshRenderer>().material.color, Color.red, 0.8f);
            dice.GetComponent<MeshRenderer>().material.color = Color.Lerp(dice.GetComponent<MeshRenderer>().material.color, Color.black, 0.7f);
            newDices.Add(dice);
        }
        dices = newDices.ToArray();
    }

    private void FinishRound()
    {
        gameState = GameState.summary;
        Debug.Log("Finished!");

        foreach (Dice dice in dices)
        {
            if (dice.WinningDiceEffect() != null)
                dice.WinningDiceEffect().UseEffect();
        }
        //podsumowanie
    }
}
