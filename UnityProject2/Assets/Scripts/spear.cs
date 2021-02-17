using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear : MonoBehaviour
{

    public float speed = 15f;
    public Rigidbody2D rb;
    public int damage = 40;

    public AudioClip getHit;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null)
        {
            AudioSource.PlayClipAtPoint (getHit, transform.position);

            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }


}
