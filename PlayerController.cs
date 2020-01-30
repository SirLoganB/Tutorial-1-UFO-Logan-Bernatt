﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public Text countText;

    public Text winText;

    public Text livesText;

    private Rigidbody2D rb2d;

    private int count;

    private int lives;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";
        SetCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("RedEnemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetCountText();

            if (lives <= 0)
            {
                gameObject.SetActive(false);
            }

            if (count == 12)
            {
                transform.position = new Vector2(-11f, 46.0f);
            }

        }

        void SetCountText()
        {
            countText.text = "Count: " + count.ToString();
            if (count >= 24)
            {
                winText.text = "You win! Game created by Logan Bernatt";
            }
            livesText.text = "Lives: " + lives.ToString();

            if (lives <= 0)
            {
                winText.text = "You Lose! :( Game created by Logan Bernatt";
            }

        }
    }
}