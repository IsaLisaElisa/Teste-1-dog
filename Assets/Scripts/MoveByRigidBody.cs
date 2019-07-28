using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByRigidBody : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    private float SpeedFactor = 10f;
    
    private Rigidbody2D Rb;

    private Animator dogAnimator; 

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dogAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Rb.velocity = new Vector3(horizontalInput, verticalInput, 0f) * SpeedFactor;
        Animating (horizontalInput, verticalInput);
    }

void Animating(float horizontalInput, float verticalInput) {
    bool walking = horizontalInput != 0f;
    anim.SetInteger("state", 2);
    LevelManager.instance.SetTapeSpeed(-3);
    if (horizontalInput == 0f) {
        anim.SetInteger("state", 1);
        LevelManager.instance.SetTapeSpeed(0); 
    }
    if (verticalInput != 0f) {
        anim.SetInteger("state", 3);
    }
}

}
