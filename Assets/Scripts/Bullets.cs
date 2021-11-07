using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        other.attachedRigidbody.AddTorque(100);
        other.attachedRigidbody.gravityScale = 2;
        Destroy(other.gameObject, 1);
    }

}
