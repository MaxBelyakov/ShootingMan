using System.Collections.Generic;
using UnityEngine;

public class Duck_controller : MonoBehaviour {

    public Rigidbody2D rb_duck;

    /* Duck moving */
    void Start()
    {
        float speed = Random.Range(2f, 3f); 
        rb_duck.velocity = transform.right * speed;   
    }

    /* Duck lose */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Died_zone")
        {
            Destroy(rb_duck.gameObject);
            if (gameObject.name == "duck(Clone)")
                Respawn.ducks_lose = Respawn.ducks_lose + 1;
        }
        
    }

    /* Ducks explosion by bullet */
    private void OnParticleCollision(GameObject other)
    {
        Destroy(rb_duck.gameObject);
        if (gameObject.name == "duck(Clone)")
            Respawn.ducks_killed = Respawn.ducks_killed + 1;
    }
}