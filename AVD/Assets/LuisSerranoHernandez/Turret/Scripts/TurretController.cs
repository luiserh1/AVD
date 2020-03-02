using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
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
        GameObject shootingCannon = cannon[currentCannon];
        GameObject shootedBullet = Instantiate(bullet,shootingCannon.transform.position,
            shootingCannon.transform.rotation);

        shootedBullet.GetComponent<Rigidbody>().AddForce(
            shootedBullet.transform.forward * shoootingForce, ForceMode.Impulse);
 
        currentCannon++;
        if (currentCannon >= cannon.Length) currentCannon = 0;

        yield return new WaitForSeconds(3f);
        Destroy(shootedBullet);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) { 
            StartCoroutine(Shoot());
        }
    }
}
