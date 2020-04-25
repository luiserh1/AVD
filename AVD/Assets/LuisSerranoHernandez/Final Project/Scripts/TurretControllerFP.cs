using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControllerFP : MonoBehaviour
{
    public Animator myAnimator;
    public Animator[] animators;
    [SerializeField] GameObject[] cannon;
    [SerializeField] GameObject bullet;
    [Range(0, 100)] [SerializeField] float shoootingForce;
    [Range(0, 30)] [SerializeField] float shoootingFrequency;
    public float livingTime;
    public bool standing;
    float deltaTime;

    private  int currentCannon;
    // Start is called before the first frame update
    void Start()
    {
        deltaTime = 0f;
        currentCannon = 0;
        StartCoroutine(Die());
    }

    IEnumerator Shoot()
    {
        animators[currentCannon].SetTrigger("Fire");
        GameObject shootingCannon = cannon[currentCannon];
        currentCannon++;
        if (currentCannon >= cannon.Length) currentCannon = 0;

        yield return new WaitForSeconds(0.05f);
        Instantiate(bullet, shootingCannon.transform.position,
            shootingCannon.transform.rotation).GetComponent<TurretBulletController>().SetFireForce(shoootingForce);
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(livingTime);
        myAnimator.SetTrigger("die");
        StopAllCoroutines();
    }


    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if (standing && deltaTime > 1.0f / shoootingFrequency)
        {
            StartCoroutine(Shoot());
            deltaTime = 0f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Muérome");
            myAnimator.SetTrigger("die");
            StopAllCoroutines();
        }
        /*if (Input.GetKeyDown(KeyCode.UpArrow)) shootingAngle += 0.05f;
        if (Input.GetKeyDown(KeyCode.DownArrow)) shootingAngle -= 0.05f;
        if (shootingAngle < -1) shootingAngle = -1;
        if (shootingAngle > 1) shootingAngle = 1;*/

    }
}
