using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class ChestOpeninng : MonoBehaviour
{
    public Collider myCollider;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colision");
            //c.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<PlayableDirector>().enabled = true;
            myCollider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
