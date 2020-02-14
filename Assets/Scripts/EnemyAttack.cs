﻿using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyAttack : MonoBehaviour
    {
        public float attackDelay = 0.6f;
        public int attackDamage = 5;

        Animator animator;
        GameObject player;
        PlayerHealth playerHealth;
        EnemyHealth enemyHealth;
        bool canHarmPlayer;
        float attackTimer;


        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
            animator = GetComponent<Animator>();
        }


        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player)
            {
                canHarmPlayer = true;
            }
        }


        void OnTriggerExit(Collider other)
        {
            if (other.gameObject == player)
            {
                canHarmPlayer = false;
            }
        }


        void Update()
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackDelay && canHarmPlayer && enemyHealth.currentHealth > 0)
            {
                Attack();
            }

            if (playerHealth.currentHealth <= 0)
            {
                animator.SetTrigger("PlayerDead");
            }
        }


        void Attack()
        {
            attackTimer = 0f;

            if (playerHealth.currentHealth > 0)
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }
    }
}