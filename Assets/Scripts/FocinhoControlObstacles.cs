using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocinhoControlObstacles : MonoBehaviour
{
    public GameObject player;

    MoveToRef script;
    Animator anim;

    void Start()
    {
        script = player.GetComponent<MoveToRef>();
        anim = player.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacles")) {
            script.encostado = true;
            anim.SetInteger("state", 3);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacles")) {
            script.encostado = false;
            anim.SetInteger("state", 1);
        }
    }
}
