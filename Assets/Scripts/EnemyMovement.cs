using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        Transform player;
        PlayerHealth playerHealth;
        EnemyHealth enemyHealth;
        UnityEngine.AI.NavMeshAgent navAgent;


        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
            navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }


        void Update()
        {
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                navAgent.SetDestination(player.position);
            }
            else
            {
                navAgent.enabled = false;
            }
        }
    }
}