using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigationController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject[] pathPositions;   
    public int actualObjective;

    enum State { PATROL, CHASE, ATTACK };
    State state;

    public GameObject player;
    private float playerDetectionRange = 20f;

    public GameObject spikyball;
    float lastShotTime = 0;
    float shotInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        if (agent == null)
        {
            state = State.PATROL;

            // The first path position the agent has to go is the 0
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(pathPositions[0].transform.position);   
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.PATROL:
                Patrol();
                break;

            case State.CHASE:
                Chase();
                break; 

            case State.ATTACK:
                Attack();
                break;
        }
    }

    private void Patrol()
    {
        // When the agent reaches the position
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            actualObjective++;

            // Sets the next position of the path
            if (actualObjective >= pathPositions.Length)
            {
                actualObjective = 0;
            }
            agent.destination = pathPositions[actualObjective].transform.position;
        }

        // Detecting the Player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, playerDetectionRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                agent.speed = 10f;
                state = State.CHASE;
            }
        }
    }

    private void Chase()
    {
        agent.SetDestination(player.transform.position);
        transform.LookAt(player.transform);

        // Si el jugador está dentro del rango de ataque, cambia al estado de ataque
        if (Vector3.Distance(transform.position, player.transform.position) <= playerDetectionRange)
        {
            state = State.ATTACK;
        }

        // Si el jugador está fuera del rango de detección, vuelve al estado de patrulla
        if (Vector3.Distance(transform.position, player.transform.position) > playerDetectionRange)
        {
            state = State.PATROL;
        }
    }

    private void Attack()
    {
        // Dispara balas solo si está en el estado de ataque
        if (Time.time > (lastShotTime + shotInterval))
        {
            transform.position += Vector3.up * 2;
            GameObject x = Instantiate(spikyball, transform.position, transform.rotation);
            Destroy(x, 0.75f);
            lastShotTime = Time.time;
        }

        // Si el jugador está fuera del rango de ataque, vuelve al estado de persecución
        if (Vector3.Distance(transform.position, player.transform.position) > playerDetectionRange)
        {
            state = State.PATROL;
        }
    }
}
