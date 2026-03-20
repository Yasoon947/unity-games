using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class playercharacter : MonoBehaviour
{
    CharacterController cc;
    Animator animator;
    
    public float speed;
    public float turnSpeed;

    public Rigidbody shell;
    public Transform muzzle;
    public float lauchForce = 0;
    public AudioSource shootAudioSource;

    bool attacking = false;
    public float atttackTime;

    bool isAlive = true;

    public float hp;
    public float hpMax = 100;

    public Slider hpSlider;
    public Image hpFillImage;
    public Color hpColorFull = Color.green;
    public Color hpColorNull = Color.red;

    public ParticleSystem explosionEffect;
    public void Move(Vector3 v)
    {
        if (!isAlive) return;
        if (attacking) return;

        Vector3 movement = v * speed;
        cc.SimpleMove(movement);

        if(animator)
        {
            animator.SetFloat("Speed", cc.velocity.magnitude);
        }
    }
    public void Attack()
    {
        if (!isAlive) return;
        if (attacking) return;

        var shellinstance = Instantiate(shell, muzzle.position,muzzle.rotation) as Rigidbody;
        shellinstance.velocity = lauchForce * muzzle.forward;
        if (animator)
        {
            animator.SetTrigger("Attack");
        }
        attacking = true;
        shootAudioSource.Play();
        Invoke("RefreshAttack", atttackTime);
    }
    void RefreshAttack()
    {
        attacking = false;
        
    }
    public void Rotate(Vector3 lookDir)
    {
        if (!isAlive) return;
        if (attacking) return;

        var targetPos = transform.position + lookDir;
        var characterPos = transform.position;

        characterPos.y = 0;
        targetPos.y = 0;

        var faceToTargetDir = targetPos - characterPos;

        var faceToQuat = Quaternion.LookRotation(faceToTargetDir);

        Quaternion slerp = Quaternion.Slerp(transform.rotation, faceToQuat, turnSpeed * Time.deltaTime);

        transform.rotation = slerp;
    }
    public void Death()
    {
        isAlive = false;
        explosionEffect.transform.parent = null;
        explosionEffect.gameObject.SetActive(true);

        ParticleSystem.MainModule mainModule = explosionEffect.main;
        Destroy(explosionEffect.gameObject, mainModule.duration);

        gameObject.SetActive(false);
    }
    public void TakeDamage(float amount)
    {
        hp -= amount;
        RefreshHealthHUD();

        if (hp <= 0f && isAlive)
        {
            Death();
        }
    }
    public void RefreshHealthHUD()
    {
        hpSlider.value = hp;
        hpFillImage.color = Color.Lerp(hpColorNull, hpColorFull, hp / hpMax);
    }
    // Start is called before the first frame update
    void Start()
    {
        cc=GetComponent<CharacterController>();
        animator=GetComponentInChildren<Animator>();
        //shootAudioSource.GetComponent<AudioSource>();

        hp = hpMax;
        RefreshHealthHUD();
        explosionEffect.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
