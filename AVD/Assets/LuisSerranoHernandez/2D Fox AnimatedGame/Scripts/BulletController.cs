using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public CircleCollider2D myCollider;
    public PlayerControl2D player;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall")) Destroy(this.gameObject);
        if (col.CompareTag("Cherry"))
        {
            player.IncreaseCherrys();
            col.GetComponent<PickableItem>().Shooted();
            Destroy(this.gameObject);
        }
        if (col.CompareTag("Gem"))
        {
            player.IncreaseGems();
            col.GetComponent<PickableItem>().Shooted();
            Destroy(this.gameObject);
        }
        if (col.CompareTag("Enemy"))
        {
            myCollider.enabled = false;
            col.GetComponent<EnemyController>().Killed();
            Destroy(this.gameObject);
        }

    }
}
