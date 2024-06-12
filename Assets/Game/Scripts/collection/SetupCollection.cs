using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CI.QuickSave;
using UnityEngine.SceneManagement;
using Save;

public class SetupCollection : MonoBehaviour
{
    public DicesCollection[] diceCollections;
    public List<Dice> dices;
    public Transform Group;
    public Transform positions;
    public GameObject ButtonDicePrefab;
    public List<int> deck;
    public List<int> collection;
    public Color HighlightColor;

    void Start()
    {
        deck = SaveSystem.Load(DataType.Deck);
        collection = SaveSystem.Load(DataType.Colletion);

        InstantiateDices(diceCollections[0]);
        UpdateVisuals();
    }

    void InstantiateDices(DicesCollection diceCollection)
    {
        for(int i = 0; i < collection.Count; i++)
        {
            InstantiateDice(diceCollection, collection[i], i);
        }
    }

    void InstantiateDice(DicesCollection diceCollection, int diceID, int i)
    {
        DiceScriptibleObject diceSO = diceCollection.diceList[diceID];
        dices.Add(diceSO.CreateDice(Group, positions.GetChild(i).position, new Quaternion(0, 0, 0, 0)));
        dices[i].GetComponent<Rigidbody>().isKinematic = true;
        dices[i].GetComponent<Rigidbody>().useGravity = false;
        dices[i].transform.localScale = Vector3.one * 100;
        dices[i].GetComponent<BasicDiceRotation>().rotating = true;
    }

    public void UpdateVisuals()
    {
        for (int i = 0; i < collection.Count; i++)
        {
            if (deck.Contains(collection[i]))
            {
                Group.GetChild(i).GetComponent<Image>().color = HighlightColor;
            }
            else
            {
                Color a = Color.black;
                a.a = 0;
                Group.GetChild(i).GetComponent<Image>().color = a;
            }
        }
    }

    public void DiceClicked(GameObject button)
    {
        int index = 0;
        bool udalosie = false;
        for(int i=0; i < dices.Count; i++)
        {
            if(Group.GetChild(i).gameObject == button)
            {
                udalosie = true;
                index = i;
                break;
            }
        }
        if (!udalosie)
            return;
        int diceID = collection[index];
        if (deck.Contains(diceID))
        {
            return;
        }
        deck.RemoveAt(0);
        deck.Add(diceID);
        UpdateVisuals();
        SaveSystem.Save(DataType.Deck, deck);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /*public void Save()
    {
        bool[] listaa = new bool[dicesCollection.diceList.Length];
        for (int i = 0; i < dicesCollection.diceList.Length; i++)
        {
            listaa[i] = false;
        }
        listaa[deck[0]] = true;
        listaa[deck[1]] = true;
        listaa[deck[2]] = true;
        QuickSaveWriter writer = QuickSaveWriter.Create("PlayerDeck");
        writer.Write("PlayerDeck",listaa);
        writer.Commit();
        UpdateVisuals();
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
