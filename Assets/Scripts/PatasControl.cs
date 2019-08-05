using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatasControl : MonoBehaviour
{
    public GameObject player;

    Animator anim;

    void Start()
    {
        anim = player.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platforms")) {
            anim.SetInteger("state", 1);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platforms")) {
            anim.SetInteger("state", 2);
        }
    }

}
