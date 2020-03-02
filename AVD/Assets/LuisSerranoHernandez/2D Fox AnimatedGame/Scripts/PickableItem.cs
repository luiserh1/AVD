using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickableItem : MonoBehaviour
{
    public BoxCollider2D myCollider;
    public Animator animator;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Cherry"))
                col.GetComponent<PlayerControl2D>().IncreaseCherrys();
            if (gameObject.CompareTag("Gem"))
                col.GetComponent<PlayerControl2D>().IncreaseGems();
            myCollider.enabled = false;
            StartCoroutine(PickUp());
        }
    }

    IEnumerator PickUp()
    {
        animator.SetBool("pickedUp", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    public void Shooted()
    {
        myCollider.enabled = false;
        StartCoroutine(PickUp());
    }
}
