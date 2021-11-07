using System.Collections.Generic;
using UnityEngine;

public class Duck_controller : MonoBehaviour {

    public Rigidbody2D rb_duck;

    void Start()
    {
        rb_duck.velocity = transform.right * 2f;
    }

}
