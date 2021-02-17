using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D body;
    


    private float vertical;
    private float horizontal;
   

    private float moveLimiter = 0.7f;

    public float runSpeed = 5f;
    public bool lookingright = true;
    public bool lookingup = true;

    private bool sliding;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
    }

    private void FixedUpdate()
    {
        if(!sliding){
            if(horizontal != 0 && vertical != 0){
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }
            body.velocity = new Vector2(horizontal*runSpeed, vertical*runSpeed);
        }

        if (horizontal > 0 && !lookingright)
        {
            Flip();
        }
        else if (horizontal < 0 && lookingright)
        {
            Flip();
        }

        /*if (vertical > 0 && !lookingup)
        {
            Flip();
        }
        else if (vertical < 0 && lookingup)
        {
            Flip();
        }
        */
    }

    public void slide(bool sliding){
        this.sliding = sliding;
    }

    private void Flip()
    {
        lookingright = !lookingright;
        transform.Rotate(0f, 180f, 0f);

    }

}
