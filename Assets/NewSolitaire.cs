﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSolitaire : MonoBehaviour
{
    public Sprite[] cardFace;
    public GameObject cardPrefab;

    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public List<string> deck;

    void Start()
    {
        PlayCrads();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayCrads()
    {
        deck = GenerateDeck();
        Shuffle(deck);

        foreach (string card in deck)
        {
            print(card);
        }
        SolitaireDeal();
    }

    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();
        foreach (string s in suits)
        {
            foreach (string v in values)
            {
                newDeck.Add(s + v);
            }
        }
        return newDeck;
    }

    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    void SolitaireDeal()
    {
        foreach (string card in deck)
        {
            float yoffset = 0;
            float zoffset = 0.3f;
            //GameObject newCard = Instantiate(cardPrefab,new Vector3(transform.position.x, transform.position.y - yoffset, transform.position.z + zoffset), Quaternion.identity));
            GameObject newCard = Instantiate(cardPrefab, new Vector3(transform.position.x, transform.position.y - yoffset, transform.position.z + zoffset), Quaternion.identity);
            newCard.name = card;

            yoffset = yoffset + 0.1f;
        }
    }
}
