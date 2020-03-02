using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public CircleCollider2D myCollider;
    public Animator animator;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D col)
    {
        ;
    }

    IEnumerator Die()
    {
        animator.SetBool("dead", true);
        yield return new WaitForSeconds(0.65f);
        Destroy(this.gameObject);
    }

    public void Killed()
    {
        myCollider.enabled = false;
        StartCoroutine(Die());
    }
}
