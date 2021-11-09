using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;
    public GameObject ExplosionPrefab;

    /* bullet moving */
    void Start () {
        rb.velocity = transform.right * speed;
    }

    /* looking for explosion bullet */
    void Update()
    {
        if (weapon.explosion_bullet)
        {
            StartCoroutine(Explosion());
            weapon.explosion_bullet = false;
        }
    }

    /* Explosion in bullet position */
    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(0.1f);
        var explosion_object = Instantiate(ExplosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        Destroy(explosion_object, 1);
    }

    /* Duck kill by bullet */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "duck(Clone)" && !weapon.explosion_bullet)
        {
            Destroy(gameObject, 0.03f);
            other.attachedRigidbody.AddTorque(100);
            other.attachedRigidbody.gravityScale = 2;
            Destroy(other.gameObject, 1);
            Respawn.ducks_killed = Respawn.ducks_killed + 1;
        }
    }
}
