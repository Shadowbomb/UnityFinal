using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardAssigner : MonoBehaviour
{
    [SerializeField] private Card[] cards;
    [SerializeField] private Sprite[] images;

    private int numCards;

    private List<int> usedID;
    private List<int> usedPOS;

    private Card currentCard;


    public bool canReveal
    {
        get { return currentCard == null; }
    }

    public void playGame(int numberOfCards)
    {
        numCards = numberOfCards;
        usedID = new List<int>(12);
        usedPOS = new List<int>(12);
        

        for (int i = 0; i < numberOfCards; i++)
        {
            bool unique = true;

            //set random id and image
            int id = Random.Range(0, cards.Length);
            if (!usedID.Contains(id))
            {
                usedID.Add(id);
            }
            else
            {
                unique = false;

            }
            while (!unique)
            {
                id = Random.Range(0, cards.Length);
                if (!usedID.Contains(id))
                {
                    usedID.Add(id);
                    unique = true;
                }
            }

            //set random position
            int pos = Random.Range(0, cards.Length);
            if (!usedPOS.Contains(pos))
            {
                usedPOS.Add(pos);
            }
            else
            {
                unique = false;

            }
            while (!unique)
            {
                pos = Random.Range(0, cards.Length);
                if (!usedPOS.Contains(pos))
                {
                    usedPOS.Add(pos);
                    unique = true;
                }
            }

            cards[pos].SetCard(id, images[id]);
        }


        for (int i = 0; i < cards.Length; i++)
        {
            if (usedPOS.Contains(i))
            {
                cards[i].setUsed();
                cards[i].Reveal();
            }
            else
            {
                cards[i].setUnused();
            }
        }

        StartCoroutine(PlayRound());
    }

    IEnumerator PlayRound()
    {
        Debug.Log("play round started");


        yield return new WaitForSeconds(4f);

        for(int i = 0; i < cards.Length; i++)
        {
            if (usedPOS.Contains(i))
            {
                cards[i].Unreveal();
            }
        }
    }// end playRound()

    public void CardRevealed(Card card)
    {
        if(currentCard == null)
        {
            currentCard = card;
            StartCoroutine(CheckSequence());
        }
    }

    IEnumerator CheckSequence()
    {
        yield return new WaitForSeconds(0.01f);
        if(currentCard.ID == usedID.Min())
        { 
            Debug.Log("Corrrect");
            usedID.Remove(usedID.Min());
            currentCard = null;

            if(usedID.Count == 0)
            {
                Debug.Log("You Win!");
                playGame(++numCards);
            }
        }
        else
        {
            Debug.Log("Incorrect");
        }
    }


}
