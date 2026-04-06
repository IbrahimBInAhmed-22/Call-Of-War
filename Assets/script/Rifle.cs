using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{


    public Text Ammo;
    public Text Magz;

    public character_mov player;
    public GameObject MuzzleSpark;
    public float giveDamageof = 10f;
    public float shootingRange = 100f;
    public Camera camera;
    public GameObject ImpactEffect;
    public GameObject goreEffect;

    private int maximumAmmunition = 40;
    private int mag = 12;
    private int presentAmmunition;
    public float reloadingTime = 1.3f;
    private bool setReloading = false;
    public Animator animator;


    [Header("Sounds And UI Of Player")]
    [SerializeField] public GameObject AmmmOutUi;
    [SerializeField] public GameObject MagUi;
    [SerializeField] private int TimeTOShowUI = 1;

    public AudioClip shootingSound;
    public AudioClip reloadingSound;
    
    public AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        Ammo.text = "Ammo: " + presentAmmunition;
        Magz.text = "Mag: " + mag;
        MuzzleSpark.SetActive(false);
    }
    private void Awake()
    {
        presentAmmunition = maximumAmmunition;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (setReloading)
            return;
        if (presentAmmunition <= 0)
        {
            StartCoroutine(Reload());
                return;
        }

        if (Input.GetMouseButton(0)) // 0 is the left mouse button
        {
            animator.SetBool("Fire", true);
            animator.SetBool("Idle", false);
            shoot();
        }
        else if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("IdleAim", true);
            animator.SetBool("FireWalk", true);
            animator.SetBool("Walk", true);
            animator.SetBool("Reloading", false);

        }
        else if (Input.GetMouseButton(0) && Input.GetMouseButton(1) )
        {
            animator.SetBool("Idle", false);
            animator.SetBool("IdleAim", true);
            animator.SetBool("FireWalk", true);
            animator.SetBool("Walk", true);
            animator.SetBool("Reloading", false);
        }
        else
        {
            animator.SetBool("Fire", false);
            animator.SetBool("Idle", true);
            animator.SetBool("FireWalk", false);
            animator.SetBool("Reloading", false);

        }
    }
    void shoot()
    {
        if(mag==0)
        {
         StartCoroutine(ShowAmmoOut());
            return;
        }
        presentAmmunition--;
        if(presentAmmunition == 0)
        {
            mag--;
        }
        Ammo.text = "Ammo: " + presentAmmunition;
        Magz.text = "Mag: " + mag;
        int prevMag = mag;

        MuzzleSpark.SetActive(true);
        Invoke("DeactivateObject", 0.3f);

        audiosource.PlayOneShot(shootingSound);
        RaycastHit hitInfo;
        if(Physics.Raycast(camera.transform.position,camera.transform.forward, out hitInfo, shootingRange))
        {

            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.enemyHitDamage(giveDamageof);
                GameObject impact60 = Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(impact60, 5f);
            }
            else {
                GameObject impact = Instantiate(ImpactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(impact, 5f); }
            //Debug.Log(hitInfo.transform.name);
        }
        if (mag > prevMag)
        {
            StartCoroutine(ShowMag());
        }

    }
    IEnumerator Reload()
    {
        player.player_speed = 0f;
        player.player_sprint = 0f;
        setReloading = true;
        Debug.Log("Reloading...");
        animator.SetBool("Reloading", true);
        audiosource.PlayOneShot(reloadingSound);
        yield return new WaitForSeconds(reloadingTime);
        animator.SetBool("Reloading", false);
        presentAmmunition = maximumAmmunition;
        player.player_speed = 1.9f;
        player.player_sprint = 10.2f;
        setReloading = false;
        Ammo.text = "Ammo: " + presentAmmunition;
        Magz.text = "Mag: " + mag;
    }
    IEnumerator ShowAmmoOut()
    {
        AmmmOutUi.SetActive(true);
        yield return new WaitForSeconds(TimeTOShowUI);
        AmmmOutUi.SetActive(false);
    }
    IEnumerator ShowMag()
    {
        MagUi.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        MagUi.SetActive(false);
    }
    public void increaseMag()
    {
        mag+=4;
    }
    void DeactivateObject()
    {
        // Deactivate the object after 0.1 seconds
        MuzzleSpark.SetActive(false);
    }
}
