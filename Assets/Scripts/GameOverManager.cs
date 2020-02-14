using UnityEngine;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;

        Animator animator;


        void Awake()
        {
            animator = GetComponent<Animator>();
        }


        void Update()
        {
            if (playerHealth.currentHealth <= 0)
            {
                animator.SetTrigger("GameOver");
            }

            if (BedScript.reachedEnd == true)
            {
                animator.SetTrigger("WinScreen");
            }
        }


        public void RestartLevelOne()
        {
            BedScript.reachedEnd = false;
            CoinScript.coinsCollected = 0;
            SceneManager.LoadScene(0);
        }
    }
}