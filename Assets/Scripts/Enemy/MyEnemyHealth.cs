using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MyEnemyHealth : MonoBehaviour
{
    public int StartingHealth = 100;

    private AudioSource enemyAudioSource;
    private ParticleSystem enemyParticals;
    public AudioClip DeathClip;
    private Animator enemyAnimator;
    private CapsuleCollider enenmyCollider;
    private SphereCollider enemyCollider2;

    public bool isDeath=false;
    bool isSinking=false;
    private void Update()
    {
        if (isSinking)
        {
            transform.Translate(-transform.up*2.5f*Time.deltaTime);
        }
    }
    private void Awake()
    {
        enemyAudioSource=GetComponent<AudioSource>();
        enemyParticals=GetComponentInChildren<ParticleSystem>();
        enemyAnimator=GetComponentInChildren<Animator>();
        enenmyCollider=GetComponentInChildren<CapsuleCollider>();
        enemyCollider2 = GetComponent<SphereCollider>();
    }
    public void TakeDamage(int amount,Vector3 vector)
    {
        if (isDeath) { return; }

        StartingHealth -= amount;

        enemyAudioSource.Play();

        enemyParticals.transform.position=vector;
        enemyParticals.Play();

        if (StartingHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        enemyAudioSource.clip = DeathClip;
        enemyAudioSource.Play();

        enemyAnimator.SetTrigger("Death");

        enenmyCollider.enabled = false;
        enemyCollider2.enabled = false;
        
        isDeath=true;

        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        MyPlayerScores.Scores += 10;
    }

    public void StartSinking() 
    {
        isSinking=true;

        Destroy(gameObject,2f);
    }
}
