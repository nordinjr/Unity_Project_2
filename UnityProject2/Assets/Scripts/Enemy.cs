﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public List<GameObject> locs;

    private Queue<GameObject> qlocs;

    public GameObject deathEffect;
    public int health = 100;

    public float duration = 3f;

    public AudioClip die;

    // Start is called before the first frame update
    void Start()
    {
        qlocs = new Queue<GameObject>();
        foreach (GameObject go in locs)
        {
            qlocs.Enqueue(go);
        }

        NextUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextUp()
    {
        GameObject pong = qlocs.Dequeue();

        //LERP
        StartCoroutine(LerpPosition(pong.transform.position));

        qlocs.Enqueue(pong);
    }

   

    IEnumerator LerpPosition(Vector3 targetPosition)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        NextUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint (die, transform.position);
    }
}
