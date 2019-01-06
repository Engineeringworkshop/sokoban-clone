using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector2 speed = new Vector2(1,0);


    private Animator animator;
   

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
