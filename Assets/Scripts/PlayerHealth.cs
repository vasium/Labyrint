using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class PlayerHealth : MonoBehaviour
    {
        public int currentHealth;
        public int startingHealth = 200;
        public float flashSpeed = 5f;
        public AudioClip doorOpenClip;
        public AudioClip playerHurtClip;
        public Slider healthSlider;
        public Image damageImage;
        public AudioClip deathClip;
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

        Animator anim;
        AudioSource playerAudio;
        Movement playerMovement;
        PlayerShooting playerShooting;
        bool isDead;
        bool damaged;


        void Awake()
        {
            anim = GetComponent<Animator>();
            playerAudio = GetComponent<AudioSource>();
            playerMovement = GetComponent<Movement>();
            playerShooting = GetComponentInChildren<PlayerShooting>();

            currentHealth = startingHealth;
        }


        void Update()
        {
            if (damaged)
            {
                damageImage.color = flashColour;
            }
            else
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }

            if (CoinScript.coinsCollected == 30)
            {
                playerAudio.clip = doorOpenClip;
                playerAudio.Play();

                CoinScript.coinsCollected = 0;

            }

            damaged = false;


        }


        public void TakeDamage(int amount)
        {
            damaged = true;

            currentHealth -= amount;

            healthSlider.value = currentHealth;

            playerAudio.clip = playerHurtClip;
            playerAudio.Play();

            if (currentHealth <= 0 && !isDead)
            {
                Death();
            }
        }


        void Death()
        {
            isDead = true;

            playerShooting.DisableEffects();

            anim.SetTrigger("Die");

            playerAudio.clip = deathClip;
            playerAudio.Play();

            playerMovement.enabled = false;
            playerShooting.enabled = false;
        }


        public void RestartLevel()
        {
            CoinScript.coinsCollected = 0;
            SceneManager.LoadScene(0);
        }
    }
}