using System.Collections; 

using System.Collections.Generic; 

using UnityEngine;
using UnityEngine.UI;

public class PlayerControl2D : MonoBehaviour 

{
    public Text cherryScore;
    public Text gemScore;
    public CharacterController2D controller; 
    public Animator animator; 
    public float runSpeed = 40f; 
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public float Gravity2D = -30f;
    public GameObject bulletSpawner;
    public GameObject bullet;
    public float bulletSpeed;

    private void Start() 

    { 
       Physics2D.gravity = new Vector2(0,Gravity2D); 
    } 

    void Update() 
    { 
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; 
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 
        if (Input.GetButtonDown("Jump") & !jump) 
        {
            jump = true; 
            animator.SetBool("IsJumping", true); 
        } 
        if (Input.GetButtonDown("Crouch")) 
        {
            crouch = true; 
        } 
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    } 

    public void OnLanding() 
    {
        animator.SetBool("IsJumping", false); 
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching); 
    }

    void FixedUpdate()
    {
        // Move our character 
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void IncreaseGems()
    {
        string sScore = gemScore.text;
        int score = int.Parse(sScore);
        gemScore.text = "" + (score + 1);
    }

    public void IncreaseCherrys()
    {
        string sScore = cherryScore.text;
        int score = int.Parse(sScore);
        cherryScore.text = "" + (score + 2);
    }


    IEnumerator Shoot()
    {
        GameObject shootedBullet = null;
        int bullets = int.Parse(cherryScore.text);
        if (bullets > 0)
        {
            cherryScore.text = "" + --bullets;
            shootedBullet = Instantiate(bullet, bulletSpawner.transform.position,
            bulletSpawner.transform.rotation);

            shootedBullet.GetComponent<BulletController>().player = this;
            shootedBullet.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(gameObject.transform.localScale.x, 0f) * bulletSpeed
                , ForceMode2D.Impulse);
        }
        else
        {
            Debug.Log("¡Sin balas!");
        }

        yield return new WaitForSeconds(2.5f);
        if (shootedBullet != null) Destroy(shootedBullet);
    }
} 