using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    private SpriteRenderer sRend;

    private Text scoreCounter;


    public float maxHealth;
    public float health, opponentHealth;

    private Slider hpBar;

    public static int coins;

    public Sprite secondSkin;

    PhotonView view;

    public TMP_Text popUp;


    void Start()
    {
        scoreCounter = GameObject.FindGameObjectWithTag("scoreCounter").GetComponent<Text>();
        hpBar = GameObject.FindGameObjectWithTag("hpBar").GetComponent<Slider>();
        popUp = GameObject.FindGameObjectWithTag("popUp").GetComponent<TMP_Text>();
        popUp.enabled = false;

        view = GetComponent<PhotonView>();
        sRend = GetComponent<SpriteRenderer>();
        if(view.IsMine == false)
        {
            sRend.sprite = secondSkin;
        }

        coins = 0;
        health = maxHealth;
        hpBar.maxValue = maxHealth;
    }

    void Update()
    {
        if (view.IsMine)
        {
        scoreCounter.text = coins.ToString();
        hpBar.value = health;
        }

        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {

            if (player.GetComponent<PhotonView>().IsMine == false)
            {
                opponentHealth = player.GetComponent<PlayerStats>().health;
            }
        }


        if (view.IsMine)
        {
        if(health < 0 || opponentHealth < 0)
        {
            popUp.enabled = true;
            if(health > 0)
            {
                popUp.text = "You Won";
                popUp.color = new Color32(106, 200, 31, 255);
            }
            if (health < 0)
            {
                popUp.text = "You Lose";
                popUp.color = new Color32(172, 32, 39, 255);
            }
        }
    }
        }


    void OnTriggerEnter2D(Collider2D collision)
    {
            CoinCheck(collision);
    }

    private void CoinCheck(Collider2D collision)
    {
        if (collision.tag.Equals("Coin"))
        {
            
            if (view.IsMine)
            coins ++;
            Destroy(collision.gameObject);

        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }


    }
