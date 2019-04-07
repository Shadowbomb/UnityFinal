﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;
    [SerializeField] private CardAssigner controller;

    public int ID;

    public void OnMouseDown()
    {
        if (cardBack.activeSelf && controller.canReveal)
        {
            cardBack.SetActive(false);
            controller.CardRevealed(this);
        }
    }//end OnMouseDown()

    public void SetCard(int id, Sprite image)
    {
        ID = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }//end SetCard()

    public void setUnused()
    {
        gameObject.SetActive(false);
    }// end SetUnused

    public void setUsed()
    {
        gameObject.SetActive(true);
    }

    public void Reveal()
    {
        if (cardBack.activeSelf)
        {
            cardBack.SetActive(false);
        }
    }//end Reveal()

    public void Unreveal()
    {
        if (!cardBack.activeSelf)
        {
            cardBack.SetActive(true);
        }    
    }// end Unreveal()
}
