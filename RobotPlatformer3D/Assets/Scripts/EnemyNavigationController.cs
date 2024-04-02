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
    private float playerDetectionRange = 15f;
    private float rotationSpeed = 720;

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
                agent.speed = 20f;
                state = State.CHASE;
            }
        }
    }

    private void Chase()
    {
        agent.SetDestination(player.transform.position);
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // Calcula la rotación hacia la dirección del jugador
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        // Suaviza la rotación hacia el jugador usando Quaternion.Lerp
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // Si el jugador está dentro del rango de ataque, cambia al estado de ataque
        if (Vector3.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
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

    }
}
