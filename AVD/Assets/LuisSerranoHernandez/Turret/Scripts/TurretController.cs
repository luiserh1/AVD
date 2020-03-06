using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Animator[] animators;
    [SerializeField] GameObject[] cannon;
    [SerializeField] GameObject bullet;
    [SerializeField] float shoootingForce;

    private  int currentCannon;
    // Start is called before the first frame update
    void Start()
    {
        currentCannon = 0;
    }

    IEnumerator Shoot()
    {
        animators[currentCannon].SetTrigger("Fire");
        GameObject shootingCannon = cannon[currentCannon];
        GameObject shootedBullet = Instantiate(bullet,shootingCannon.transform.position,
            shootingCannon.transform.rotation);

        currentCannon++;
        if (currentCannon >= cannon.Length) currentCannon = 0;

        yield return new WaitForSeconds(0.25f);
        shootedBullet.GetComponent<Rigidbody>().AddForce(
            shootedBullet.transform.forward * shoootingForce, ForceMode.Impulse);
        Destroy(shootedBullet, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Shoot());
    }
}
