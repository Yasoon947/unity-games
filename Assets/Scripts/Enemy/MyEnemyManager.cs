using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MyEnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject CreateEnemyPoint;

    public float FirstCreateEnemyTime = 0f;
    public float CreateEnemyTime = 3f;
    private void Start()
    {
        InvokeRepeating("Spawn", FirstCreateEnemyTime, CreateEnemyTime);
    }

    void Spawn()
    {
        Instantiate(enemy,CreateEnemyPoint.transform.position,CreateEnemyPoint.transform.rotation);
    }
}
