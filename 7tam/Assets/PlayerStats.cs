using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private Rigidbody2D rb;

    public Text scoreCounter;


    public float maxHealth;
    public static float health;

    public static int coins;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coins = 0;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounter.text = coins.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        CoinCheck(collision);

    }

    private void CoinCheck(Collider2D collision)
    {
        if (collision.tag.Equals("Coin"))
        {
            
            
            coins ++;
            Destroy(collision.gameObject);

        }
    }

    }
