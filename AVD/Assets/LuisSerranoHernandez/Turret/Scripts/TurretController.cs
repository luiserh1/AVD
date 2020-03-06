using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Animator[] animators;
    [SerializeField] GameObject[] cannon;
    [SerializeField] GameObject bullet;
    [Range(0, 100)] [SerializeField] float shoootingForce;
    [Range(0, 30)] [SerializeField] float shoootingFrequency;
    float deltaTime;

    private  int currentCannon;
    // Start is called before the first frame update
    void Start()
    {
        deltaTime = 0f;
        currentCannon = 0;
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

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime > 1.0f / shoootingFrequency)
        {
            StartCoroutine(Shoot());
            deltaTime = 0f;
        }
    }
}
