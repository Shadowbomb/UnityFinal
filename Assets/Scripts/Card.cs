using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;

    private int ID;

    public void OnMouseDown()
    {
        if (cardBack.activeSelf)
        {
            cardBack.SetActive(false);
        }
    }//end OnMouseDown()

    public void SetCard(int id, Sprite image)
    {
        ID = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }//end SetCard()
}
