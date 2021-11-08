using UnityEngine;

public class Bullets : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;

	void Start () {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "duck(Clone)")
        {
            Destroy(gameObject, 0.03f);
            other.attachedRigidbody.AddTorque(100);
            other.attachedRigidbody.gravityScale = 2;
            Destroy(other.gameObject, 1);
            Respawn.ducks_killed = Respawn.ducks_killed + 1;
        }
    }

}
