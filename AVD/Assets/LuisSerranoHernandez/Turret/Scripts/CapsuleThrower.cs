using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleThrower : MonoBehaviour
{
    public GameObject turretSpawner;
    [Range(0, 1000)] [SerializeField] float throwingForce = 750f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.05f);
        GameObject capsule = Instantiate(turretSpawner, gameObject.transform.position,
            gameObject.transform.rotation);
        capsule.GetComponent<Rigidbody>().AddForce(
            (Vector3.forward) * -throwingForce, ForceMode.Impulse);
        capsule.GetComponent<TurretSpawnerController>().setSpawninngOrientation(gameObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(Shoot());
        }
    }
}
