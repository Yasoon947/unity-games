using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyAttack : MonoBehaviour
{
    private MyPlayerHealth playerHealth;
    private GameObject player;
    private Animator enemyAnimator;
    private float timer = 0;
    public int damage = 10;
    bool playerInRange=false;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<MyPlayerHealth>();
        enemyAnimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange= false;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!playerHealth.isPlayerDeath&&playerInRange && timer>2f)
        {
            Attack();
        }
        if (playerHealth.isPlayerDeath)
        {
            enemyAnimator.SetTrigger("PlayerDeath");
        }
    }
    void Attack()
    {
        timer = 0;
        playerHealth.TakeDamage(damage);
        
    }
}
