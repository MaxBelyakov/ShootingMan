using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public Transform Respawn_place;
    public GameObject duckPrefab;


    void Start()
    {
        NewRespawn();
    }

    void NewRespawn()
    {
        Respawn_place.position = new Vector3(Respawn_place.position.x, Random.Range(-2.5f, 2.5f), Respawn_place.position.z);
        var duck_clone = Instantiate(duckPrefab, Respawn_place.position, Respawn_place.rotation);
        StartCoroutine(waiter());
        StartCoroutine(duck_die(duck_clone));
    }

    /* Wait for new respawn random time */
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        NewRespawn();
    }

    /* Destroy not killed object */
    IEnumerator duck_die(GameObject duck_clone)
    {
        yield return new WaitForSeconds(15);
        Destroy(duck_clone);
    }
}
