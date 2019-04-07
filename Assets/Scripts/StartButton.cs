using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>(); if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    public void OnMouseUp()
    {
        transform.localScale = Vector3.one; if (targetObject != null)
        {
            targetObject.SendMessage("playGame", 3);
        }
    }
}
