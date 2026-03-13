using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFoolow : MonoBehaviour
{
    public float Smoothing = 5f;
    private GameObject player;
    private Vector3 offset;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            offset+player.transform.position,
            Smoothing*Time.deltaTime);
    }
}

