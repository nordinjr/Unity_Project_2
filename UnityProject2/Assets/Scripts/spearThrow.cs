using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearThrow : MonoBehaviour
{
    public Transform spearPos;
    public GameObject spearPrefab;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Throw();
        }
    }

    void Throw()
    {
        Instantiate(spearPrefab, spearPos.position, spearPos.rotation);
       
    }
}
