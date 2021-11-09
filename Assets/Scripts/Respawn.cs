using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {

    public Transform Respawn_place;
    public GameObject duckPrefab;
    public GameObject dronePrefab;
    public GameObject boxPrefab;
    public int Lvl = 1;
    public int Lvl_ducks = 3;
    public int ducks_counter; /* how many ducks wait for respawn this level */
    public static int ducks_killed = 0;
    public static int ducks_lose = 0;
    public Text Lvl_text;
    public Text Lvl_stats;
    public static bool bullets_drop = false; /* show is the bullet box in the game or not */

    void Start()
    {
        Lvl_text.gameObject.SetActive(false);
        Lvl_stats.gameObject.SetActive(false);

        ducks_counter = Lvl_ducks;
        NewRespawn();
    }

    void Update()
    {
        /* check all ducks are finished */
        if (ducks_killed + ducks_lose == Lvl_ducks)
        {
            Lvl_text.text = "Level " + Lvl.ToString() + " complete";
            Lvl_stats.text = "Ducks killed: " + ducks_killed.ToString() + "/" + Lvl_ducks.ToString();

            Lvl = Lvl + 1;
            ducks_killed = 0;
            ducks_lose = 0;
            Lvl_ducks = Lvl_ducks + Random.Range(1, 5); /* increase amount of ducks next level */

            StartCoroutine(EndLevel());
        }
    }

    /* Create new duck */
    void NewRespawn()
    {
        if (ducks_counter != 0)
        {
            Respawn_place.position = new Vector3(Respawn_place.position.x, Random.Range(-2.5f, 2.5f), Respawn_place.position.z);
            Instantiate(duckPrefab, Respawn_place.position, Respawn_place.rotation);
            StartCoroutine(waiter());
            ducks_counter = ducks_counter - 1;
        }
            
    }

    /* Wait for new respawn random time */
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));

        /* check for bullets, drop box if it needs */ 
        if ((weapon.bullets <= 5) && !bullets_drop)
            StartCoroutine(Bullets_drop());
        else
            NewRespawn();
    }

    /* Wait for new level */
    IEnumerator EndLevel()
    {
        Lvl_text.gameObject.SetActive(true);
        Lvl_stats.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        Start();
    }

    /* Drop the box in drone random position */
    IEnumerator Bullets_drop()
    {
        Respawn_place.position = new Vector3(Respawn_place.position.x, 2.5f, Respawn_place.position.z);
        var drone_clone = Instantiate(dronePrefab, Respawn_place.position, Respawn_place.rotation);
        bullets_drop = true;
        yield return new WaitForSeconds(Random.Range(1, 5));
        
        Instantiate(boxPrefab, drone_clone.transform.position, Respawn_place.rotation);
        NewRespawn();
    }

}