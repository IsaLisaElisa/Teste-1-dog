using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRef : MonoBehaviour
{
    public Transform refPoint;
    public float lerpRate = 4f;
    public float force = 10f;

    public bool encostado = false;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!encostado) {
            Vector3 initialPosition = transform.position;
            Vector3 finalPosition = new Vector3(refPoint.position.x, initialPosition.y, initialPosition.z);
            transform.position = Vector3.Lerp(initialPosition, finalPosition, lerpRate * Time.deltaTime);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Impulse(force);
        }
    }

    void Impulse(float force) {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
       
    }
}
