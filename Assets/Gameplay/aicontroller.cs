using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class aicontroller : MonoBehaviour
{
    NavMeshAgent agent;
    playercharacter character;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<playercharacter>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("Firecontrol", 1, 3);
    }

    void Firecontrol()
    {
        character.Attack();
    }
    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
        transform.LookAt(player.transform);
    }
}
