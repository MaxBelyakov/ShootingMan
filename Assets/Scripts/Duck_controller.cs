using System.Collections.Generic;
using UnityEngine;

public class Duck_controller : MonoBehaviour {

    public Rigidbody2D rb_duck;

    void Start()
    {
        float speed = Random.Range(2f, 3f); 
        rb_duck.velocity = transform.right * speed;   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Died_zone")
        {
            Destroy(rb_duck.gameObject);
            Respawn.ducks_lose = Respawn.ducks_lose + 1;
        }
        
    }
}
