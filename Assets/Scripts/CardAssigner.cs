using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAssigner : MonoBehaviour
{
    [SerializeField] private Card[] cards;
    [SerializeField] private Sprite[] images;
    public int numberOfCards = 3;

    void Start()
    {
        List<int> used = new List<int>(12);

        for (int i = 0; i < numberOfCards; i++)
        {
            bool unique = true;
            int id = Random.Range(0, images.Length);
            if(!used.Contains(id)){
                used.Add(id);
            }
            else
            {
                unique = false;

            }
            while (!unique)
            {
                id = Random.Range(0, images.Length);
                if (!used.Contains(id))
                {
                    used.Add(id);
                    unique = true;
                }

            }

            cards[i].SetCard(id, images[id]);
        }

    }//end Start()

}
