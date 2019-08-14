using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatasControl : MonoBehaviour
{
    MoveToRef script;
    public GameObject player;

    Animator anim;

    void Start()
    {
        script = player.GetComponent<MoveToRef>();
        anim = player.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platforms") || other.gameObject.layer == LayerMask.NameToLayer("Obstacles")) {
            script.noChao = true;
            anim.SetInteger("state", 1);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platforms") || other.gameObject.layer == LayerMask.NameToLayer("Obstacles")) {
            script.noChao = false;
            anim.SetInteger("state", 2);
        }
    }
}
