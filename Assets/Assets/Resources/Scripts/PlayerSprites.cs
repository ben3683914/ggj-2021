using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprites : MonoBehaviour
{
    public Sprite Front;
    public Sprite Back;
    public Sprite FrontSide;
    public Sprite BackSide;
    public Player player;
    private SpriteRenderer sr;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var movement = player.Movement;
        if(movement.x == 0 && movement.y == 0)
        {
            // sr.sprite = Front;
        }

        if (movement.x == 0 && movement.y > 0)
            sr.sprite = Back;

        if (movement.x == 0 && movement.y < 0)
            sr.sprite = Front;

        if(movement.x < 0 && movement.y <= 0)
        {
            sr.sprite = FrontSide;
            sr.flipX = false;
        }

        if(movement.x > 0 && movement.y <= 0)
        {
            sr.sprite = FrontSide;
            sr.flipX = true;
        }

        if(movement.x < 0 && movement.y > 0)
        {
            sr.sprite = BackSide;
            sr.flipX = true;
        }

        if (movement.x > 0 && movement.y > 0)
        {
            sr.sprite = BackSide;
            sr.flipX = false;
        }
    }
}
