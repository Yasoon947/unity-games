using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyPlayerHealth : MonoBehaviour
{
    public int playerHealth=100;
    public bool isPlayerDeath=false;

    public Text PlayerHealthUI;
    private Animator playerAnimator;
    private AudioSource playerAudioSource;
    public AudioClip playerAudioClip;
    private PlayerMovement playerMovement;
    private MyPlayerShooting playerShooting;

    public Image DamageImage;
    private bool damage=false;
    public Color FlashColor = new Color(1f,0f,0f,0.1f);
    private void Awake()
    {
        playerAudioSource = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<MyPlayerShooting>();
    }
    public void TakeDamage(int amount)
    {
       if (!isPlayerDeath)
       {
            playerHealth -= amount;
            damage = true;
        }
        else
        {
            return;
        }
        if (playerHealth <= 0) 
        {
            Death();
        }
        playerAudioSource.Play();
        
        PlayerHealthUI.text = playerHealth.ToString();
    }
    void Death()
    {
        if (playerHealth<=0)
        {
            isPlayerDeath = true;
        }

        playerAudioSource.clip = playerAudioClip;
        playerAudioSource.Play();

        playerAnimator.SetTrigger("Death");

        playerMovement.enabled = false;
        playerShooting.enabled = false;

    }
    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Debug.Log($"Final Scores: {MyPlayerScores.Scores}");
        MyPlayerScores.Scores = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (damage)
        {
            DamageImage.color = FlashColor;
        }
        else
        {
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, 5f * Time.deltaTime);
        }
        damage =false;
    }
}
