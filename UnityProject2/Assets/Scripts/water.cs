﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("soft icey boi");
        if(collision.gameObject.CompareTag("Player")){
            movement x = collision.gameObject.GetComponent<movement>();
            x.runSpeed = 2.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        Debug.Log("leave soft icey boi");
        if(collision.gameObject.CompareTag("Player")){
            movement x = collision.gameObject.GetComponent<movement>();
            x.runSpeed = 5f;
        }
    }
}
