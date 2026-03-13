using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyEnemyMovement : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent nav;
    private MyEnemyHealth enemyHealth;
    private MyPlayerHealth playerHealth;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<MyEnemyHealth>();
        playerHealth = player.GetComponent<MyPlayerHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!enemyHealth.isDeath && !playerHealth.isPlayerDeath)
        {
            nav.SetDestination(player.transform.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
