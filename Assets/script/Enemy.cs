using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Health and Damage")]
    private float EnemyHealth = 120f;
    public float PresentHealth;
    public float GiveDamage = 5f;
    private bool isDead = false;

    [Header("Enemy animation")]
    public Animator anim;
    public GameObject MuzzleSpark;  

    [Header("Enemy Things")]
    public NavMeshAgent enemyAgent;
    public Transform playerBody;
    public LayerMask playerLayer;
    public Transform LookPoint;
    public Camera shootingRaycastArea;

    public AudioClip enemyShootSound;
    public AudioSource audiosource;

    [Header("Enemy Shooting Var")]
    public float timebtwshoot;
    bool previouslyShoot;
    [Header("Enemy guarding Var")]
    public GameObject[] walkPoints;
    public int currentEnemyPosition = 0;
    public float enemySpeed;
    float walkinPointRadius = 2;
    [Header("Enemy mood/Situation")]
    public float visionRadius=10;
    public float shootingRadius=15;
    public bool playerInvisionRadius;
    public bool playerInShootingRadius; 

//    [Header("Sounds and UI")]
private void Awake()
    {
        //audiosource = GetComponent<AudioSource>();
        PresentHealth = 120f;
        playerBody = GameObject.Find("player").transform;
        enemyAgent = GetComponent<NavMeshAgent>();
        MuzzleSpark.SetActive(false);
    }
private void Update()
    {
       // Debug.Log(Vector3.Distance(playerBody.position, transform.position));
        if (Vector3.Distance(playerBody.position, transform.position) < visionRadius)
        {
            playerInvisionRadius = true;
        }
        

        if (Vector3.Distance(playerBody.position, transform.position) < shootingRadius)
        {
            playerInShootingRadius = true;
        }
        else
            playerInShootingRadius = false;
        if(!playerInvisionRadius&&!playerInShootingRadius)
        {
            Guard();
        }
        if (playerInvisionRadius && !playerInShootingRadius&&!isDead) PursuePlayer();
        if (playerInvisionRadius && playerInShootingRadius&&    !isDead) ShootPlayer();
    }

 private void Guard()
    {
        
        if (Vector3.Distance(walkPoints[currentEnemyPosition].transform.position, transform.position) < walkinPointRadius)
        {

            
            currentEnemyPosition = Random.Range(0, walkPoints.Length);
                if(currentEnemyPosition>=walkPoints.Length)
            {
                currentEnemyPosition = 0;
            }
            transform.position = Vector3.MoveTowards(transform.position, walkPoints[currentEnemyPosition].transform.position, Time.deltaTime * enemySpeed);
            //changing direction of enemy
            transform.LookAt(walkPoints[currentEnemyPosition].transform.position);
        }
        
            transform.position = Vector3.MoveTowards(transform.position, walkPoints[currentEnemyPosition].transform.position, Time.deltaTime * enemySpeed);
    }

    private void PursuePlayer()
    {
        if (enemyAgent.SetDestination(playerBody.position))
        {
            // Add animations here
            anim.SetBool("Walk", false);
            anim.SetBool("AimRun", true);
            anim.SetBool("Shoot", false);
            anim.SetBool("Die", false);
            // + vision and shooting radius
            visionRadius = 80f;
            shootingRadius = 25f;
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("AimRun", false);
            anim.SetBool("Shoot", false);
            anim.SetBool("Die", true);
        }
    }
    private void ShootPlayer()
    {
        enemyAgent.SetDestination(transform.position);
        transform.LookAt(LookPoint);

        // Check if previously shot
        if (!previouslyShoot)
        {
            MuzzleSpark.SetActive(true);  // Activate muzzle spark
            audiosource.PlayOneShot(enemyShootSound);  // Play shoot sound

            // Start Coroutine to deactivate muzzle spark after a short delay
            StartCoroutine(DeactivateMuzzleSparkAfterDelay(0.1f));

            RaycastHit hit;
            if (Physics.Raycast(shootingRaycastArea.transform.position, shootingRaycastArea.transform.forward, out hit, shootingRadius))
            {
                Debug.Log("Shooting " + hit.transform.name);

                adjust playerBody = hit.transform.GetComponent<adjust>();
                if (playerBody != null)
                {
                    playerBody.playerDamage(GiveDamage);
                }

                // Update animation states
                anim.SetBool("Walk", false);
                anim.SetBool("AimRun", false);
                anim.SetBool("Shoot", true);
                anim.SetBool("Die", false);
            }

            previouslyShoot = true;  // Mark as having shot
            Invoke(nameof(ActiveShooting), timebtwshoot);  // Reset shooting after cooldown
        }
    }
    private IEnumerator DeactivateMuzzleSparkAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        MuzzleSpark.SetActive(false);  // Deactivate muzzle spark after delay
    }

    void DeactivateObject()
    {
        // Deactivate the muzzle spark after 0.1 seconds
        MuzzleSpark.SetActive(false);
    }

    private void ActiveShooting()
    {
        // Reset the previouslyShoot flag after the cooldown
        previouslyShoot = false;
    }

    public void enemyHitDamage(float takeDamage)
    {
        PresentHealth -= takeDamage;
        playerInvisionRadius = true;
        visionRadius = 80f;
        shootingRadius = 25f;
        if (PresentHealth<=0)
        {

         
            enemyDie();
            anim.SetBool("Walk", false);
            anim.SetBool("AimRun", false);
            anim.SetBool("Shoot", false);
            anim.SetBool("Die", true);
        }
    }
    private void enemyDie()
    {
        
        // Stop all enemy activities
        enemyAgent.SetDestination(transform.position);
        enemySpeed = 0f;
        shootingRadius = 0f;
        visionRadius = 0f;
        playerInShootingRadius = false;
        playerInvisionRadius = false;

        // Trigger death animation
        anim.SetBool("Walk", false);
        anim.SetBool("AimRun", false);
        anim.SetBool("Shoot", false);
        anim.SetBool("Die", true);

        // Notify player to update score and enemy count
        GameObject playerObject = GameObject.Find("player");
        if (playerObject != null)
        {
            adjust playerBody = playerObject.GetComponent<adjust>();
            if (playerBody != null&&!isDead)
            {
                isDead = true;
                Debug.Log("Enemy died...");
                playerBody.playerScore();
            }
        }

        // Destroy the enemy object
        Destroy(gameObject, 5.0f); // Allow time for death animation
    }

}
