using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class CardAssigner : MonoBehaviour
{
    [SerializeField] private Card[] cards;
    [SerializeField] private Sprite[] images;
    [SerializeField] private Sprite[] borders;

    private int numCards = 3;

    private List<int> usedID;
    private List<int> usedPOS;

    private Card currentCard;


    public bool canReveal
    {
        get { return currentCard == null; }
    }


    void Start()
    {
        PlayGame();
    }

    public void PlayGame()
    {
        foreach (Card card in cards)
        {
            card.SetBorder(borders[0]);
        }
        usedID = new List<int>(12);
        usedPOS = new List<int>(12);
        

        for (int i = 0; i < numCards; i++)
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
    } // end CardRevealed()

    IEnumerator CheckSequence()
    {
        if(currentCard.ID == usedID.Min())
        { 
            Debug.Log("Corrrect");
            usedID.Remove(usedID.Min());
            currentCard = null;

            if(usedID.Count == 0)
            {
                foreach(Card card in cards)
                {
                    card.SetBorder(borders[1]);
                }
                yield return new WaitForSeconds(1f);
                numCards++;
                PlayGame();
            }
        }
        else
        {
            foreach (Card card in cards)
            {
                card.SetBorder(borders[2]);
            }
            for (int i = 0; i < cards.Length; i++)
            {
                if (usedPOS.Contains(i))
                {
                    cards[i].Reveal();
                }
            }
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("MainMenu");
        }
    }// end CheckSequence()


}
