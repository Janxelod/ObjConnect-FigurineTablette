﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcBullet : MonoBehaviour {

    public float damage;
    private ArrayList  enemyList;
	// Use this for initialization
	void Start () {
        enemyList = new ArrayList();
        GetComponent<SpriteRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision) {
        HealthEnemy enemy = collision.GetComponent<HealthEnemy>();
        if (enemy != null) {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Animator>().SetTrigger("EnemyEnter");
            if (enemyList.IndexOf(enemy) == -1) enemyList.Add(enemy);
            enemy.SetLife(damage, true);
            
        }
        GetComponent<Animator>().SetTrigger("EnemyExit");
    }

    private void OnTriggerStay(Collider collision)
    {
        HealthEnemy enemy = collision.GetComponent<HealthEnemy>();
        if (enemy != null)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Animator>().SetTrigger("EnemyEnter");
            if (enemyList.IndexOf(enemy) == -1) enemyList.Add(enemy);
            enemy.SetLife(damage, true);
            
        }
        GetComponent<Animator>().SetTrigger("EnemyExit");
    }


    public void OnTriggerExit(Collider collision) {
        HealthEnemy enemy = collision.GetComponent<HealthEnemy>();
        if (enemy != null) {
            enemyList.Remove(enemy);
            if(enemyList.Count == 0) {
              GetComponent<Animator>().SetTrigger("EnemyExit");
              GetComponent<SpriteRenderer>().enabled = false;
            }
            enemy.FinishDamage();
        }
    }
}
