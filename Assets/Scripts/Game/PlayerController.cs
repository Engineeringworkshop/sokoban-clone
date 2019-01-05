using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector2 speed = new Vector2(1,0);
    //private Rigidbody2D rb2d;

    private Animator animator;
   
    void Start()
    {
        //rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
     
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
             
        Vector3 movement = new Vector3(
            speed.x * moveHorizontal, 
            speed.y * moveVertical,
            0);

        movement *= Time.deltaTime;

        this.transform.Translate(movement);
    }
}
