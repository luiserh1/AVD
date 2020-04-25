using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawnerControllerFP : MonoBehaviour
{
    public GameObject turret;
    public Animator myAnimator;
    Quaternion spawnOrientation;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 8) // Level layer
        {
            StartCoroutine(SpawnTurret());
        }
    }

    IEnumerator SpawnTurret()
    {
        Debug.Log("Voy a crear una torreta");
        yield return new WaitForSeconds(0.2f);
        Instantiate(turret,
            gameObject.transform.position,
            spawnOrientation);
        Destroy(gameObject);
    }

    public void setSpawninngOrientation(Quaternion t)
    {
        this.spawnOrientation = t;
    }
}
