using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocinhoControl : MonoBehaviour
{
    public GameObject player;

    MoveToRef script;

    void Start()
    {
        script = player.GetComponent<MoveToRef>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platforms")) {
            Debug.Log("Entrou");
            script.encostado = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platforms")) {
            Debug.Log("Saiu");
            script.encostado = false;
        }
    }
}
