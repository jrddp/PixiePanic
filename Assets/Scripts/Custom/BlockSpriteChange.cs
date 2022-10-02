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

    public int player1_score;
    public int player2_score;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteDefault;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1" && gameObject.tag != "tile_green")
        {
            if (gameObject.tag == "tile_red")
                player2_score--;

            player1_score++; 
            spriteRenderer.sprite = spriteForest;
            gameObject.tag = "tile_green";
        }
        else if (collision.gameObject.name == "Player2" && gameObject.tag != "tile_red")
        {
            if (gameObject.tag == "tile_green")
                player1_score--;

            player2_score++;
            spriteRenderer.sprite = spriteBusiness;
            gameObject.tag = "tile_red";
        }
    }

}
