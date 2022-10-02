using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpriteChange : MonoBehaviour
{
    public Sprite spriteDefault;
    public Sprite spriteForest;
    public Sprite spriteBusiness;

    private Renderer rend;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteDefault;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            spriteRenderer.sprite = spriteForest;
        }
        else if (collision.gameObject.name == "Player2")
        {
            spriteRenderer.sprite = spriteBusiness;
        }

    }

}
