﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject spawnType;
    public int spawnNumber = 6;

    public void SpawnEnemy()
    {
        spawnNumber--;
        GameObject spawn = Instantiate(spawnType, transform.position, transform.rotation);
        spawn.transform.parent = transform.parent;
    }
}
