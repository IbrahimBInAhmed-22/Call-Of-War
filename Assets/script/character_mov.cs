using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class character_mov : MonoBehaviour
{

    public Text Health;
    public Text Health1;
    public Text enemies;
    public Button Restart;

    public AudioClip playerHurtSound;
    public AudioSource audiosource;

    [Header("Player Health Things")]
    private float playerHealth = 120f;
    private float presentHealth = 0;
    //player movement
    public float player_speed = 4f;
    public float player_sprint = 6.8f;
    // player animator and gravity
    public CharacterController cc;
    public float gravity = -9.81f;
    public Animator animator;
    // player Script Camera
    public Transform playerCamera;

    public float turnCalmTime = 0.1f;
    public float turnCalmVelocity;
 


    // surface variables for jump

    public float jumpRange = 1f;
    Vector3 velocity;
    public Transform surfaceCheck;
   
    bool onSurface;
    public float surfaceDistance = 0.4f;
    public LayerMask surfaceMask;
    public int remainingEnemies=0;



    // Start is called before the first frame update
    void Start()
    {

        
        presentHealth = playerHealth;

        remainingEnemies += GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemies.text = "ENEMIES LEFT: " + remainingEnemies;

    }

    // Update is called once per frame
    void Update()
    {



        if (remainingEnemies <= 0)
        {
            SceneManager.LoadScene("Win");

        }


        Health.text = "Health:  " + presentHealth;
        Health1.text = "Health:  " + presentHealth;
        enemies.text = "ENEMIES LEFT: " + remainingEnemies;
        onSurface =Physics.CheckSphere(surfaceCheck.position,surfaceDistance,surfaceMask);
        if(onSurface&&velocity.y<0)
        {
            velocity.y = -2f;
        }
        move();
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
        jump();
        sprint();
    }
    void move()
    {
        float horizontal_axis = Input.GetAxisRaw("Horizontal");
        float vertical_axis = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal_axis, 0, vertical_axis).normalized;

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Running", false);
            animator.SetBool("Idle", false);
            animator.SetTrigger("Jump");
            animator.SetBool("WalkAim", false);
            animator.SetBool("IdleAim", false);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 mdirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            cc.Move(mdirection.normalized * player_speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetTrigger("Jump");
            animator.SetBool("Walk", false);
            animator.SetBool("Running", false);
            animator.SetBool("WalkAim", false);

            Vector3 forwardDirection = playerCamera.transform.forward;
            forwardDirection.y = 0;

            float targetAngle = Mathf.Atan2(forwardDirection.x, forwardDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }




    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onSurface)
        {
            animator.SetBool("jump", false);
            animator.SetTrigger("Jump");
            //transform.Translate(0, 2, 0);

            velocity.y = Mathf.Sqrt(jumpRange * -2 * gravity);
        }
        else
            animator.ResetTrigger("Jump");

    }
    void sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            float horizontal_axis = Input.GetAxisRaw("Horizontal");
            float vertical_axis = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal_axis, 0, vertical_axis).normalized;

            if (direction.magnitude >= 0.1f)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Running", true);
                animator.SetBool("Idle", false);
                animator.SetTrigger("Jump");
                animator.SetBool("WalkAim", false);
                animator.SetBool("IdleAIm", false);
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime);
                transform.rotation = Quaternion.Euler(0, angle, 0);
                Vector3 mdirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                cc.Move(mdirection.normalized * player_sprint * Time.deltaTime);
            }
            else
            {
                animator.SetBool("Idle", false);
    
                animator.SetBool("Walk", false);
               
            }
        }
    }
    public void playerHitDamage(float takeDamage)
    {
        presentHealth-=takeDamage;
        audiosource.PlayOneShot(playerHurtSound);
        if (presentHealth <= 0)
        {
            playerDie();
        }
    }
    public void playerScoreE()
    {
        remainingEnemies--;
    }
    private void playerDie()
    {
        Cursor.lockState = CursorLockMode.None;
        Object.Destroy(gameObject, 2.0f);
        SceneManager.LoadScene("gameOver");
    }
   

 

}
