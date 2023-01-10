using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 20;

    GroundDetector ground;
    int jumps;
    public int jumps_max = 3;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
        ground = GetComponent<GroundDetector>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if(ground.grounded)
        {
            jumps = jumps_max;
        }

        if(Input.GetButtonDown("Jump") && jumps > 0)
        {
            rb.AddForce(new Vector2(0, force));
            jumps--;    
        }
    }
}
