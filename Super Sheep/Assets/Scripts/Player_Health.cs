﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {

    GameObject spawn;
    GameObject player;
    GameObject xLife;
    GameObject ammo;

    private void Start()
    {
        spawn = GameObject.Find("Spawn");
        player = GameObject.Find("Player");
        xLife = GameObject.Find("xLife");
        ammo = GameObject.Find("Ammo");

        if (CtrlLife.health < 3 && Xlife.xLifeTaken)
        {
            xLife.SetActive(false);
            
        }

        if (weapon.ammunationTaken)
        {
            ammo.SetActive(false);
        }

    }

   
    // Death when the sheep touchs an enemy or spike
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Spikes")
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            CtrlLife.health -= 1;
            StartCoroutine(Wait());
            player.transform.position = spawn.transform.position;
        }

        else if (col.gameObject.name == "EnemyAlien" || col.gameObject.name == "EnemyFox")
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            CtrlLife.health -= 1;
            StartCoroutine(Wait());
            player.transform.position = spawn.transform.position;
        }
    }

    // Time gap after death
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("GameScene");
    }

}