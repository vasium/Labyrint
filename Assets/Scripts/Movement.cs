using UnityEngine;

namespace CompleteProject
{
    public class Movement : MonoBehaviour
    {
        public float playerSpeed = 10f;

        Vector3 movement;
        Animator animator;
        Rigidbody playerRigidbody;


        void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
        }


        void FixedUpdate()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Move(horizontal, vertical);

            Animating(horizontal, vertical);
        }


        void Move(float horizontal, float vertical)
        {
            movement.Set(horizontal, 0f, vertical);
            movement = movement.normalized * playerSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(transform.position + movement);
        }


        void Update()
        {
            Turning();
        }


        void Turning()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                transform.rotation = Quaternion.Euler(0, 180, 0);
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                transform.rotation = Quaternion.Euler(0, 270, 0);
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                transform.rotation = Quaternion.Euler(0, 90, 0);
        }


        void Animating(float horizontal, float vertical)
        {
            bool walking = horizontal != 0f || vertical != 0f;
            animator.SetBool("IsWalking", walking);
        }
    }
}