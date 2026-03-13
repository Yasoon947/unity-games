using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerShooting : MonoBehaviour
{
    float time = 0f;
    public float effctsDisplayTime = 0.2f;
    public float timeBetweenBullets = 0.15f;
    public int damage = 10;
    private AudioSource gunAudio;
    private Light gunLight;
    private LineRenderer gunLine;
    private ParticleSystem gunParticle;

    private Ray shootRay;
    private RaycastHit shootHit;
    private int shootMask;
    private void Awake()
    {
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        gunLine = GetComponent<LineRenderer>();
        gunParticle = GetComponent<ParticleSystem>();
        shootMask = LayerMask.GetMask("Enemy");
    }
    // Update is called once per frame
    void Update()
    {
        time=time+Time.deltaTime;

        if(Input.GetButton("Fire1") && time>=timeBetweenBullets) 
        {
            Shoot();
        }

        if (time >= effctsDisplayTime*timeBetweenBullets)
        {
            gunLight.enabled = false;
            gunLine.enabled = false;
        }
        
    }

    void Shoot()
    {
        time = 0;

        gunAudio.Play();

        gunLight.enabled = true;

        gunLine.SetPosition(0,transform.position);
        //gunLine.SetPosition(1,transform.position + transform.forward * 100);
        gunLine.enabled=true;

        gunParticle.Play();


        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if (Physics.Raycast(shootRay, out shootHit, 100, shootMask))
        {
            gunLine.SetPosition(1,shootHit.point);

            MyEnemyHealth enemyHealth = shootHit.collider.GetComponent<MyEnemyHealth>();
            enemyHealth.TakeDamage(damage,shootHit.point);
            
        }
        else
        {
            gunLine.SetPosition(1,transform.position + transform.forward * 100);
        }
    }
}
