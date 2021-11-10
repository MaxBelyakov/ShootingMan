using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_box : MonoBehaviour {

    /* Take a bullet box */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "bullets_box")
            {
                weapon.get_box_10 = true;
                Respawn.bullets_drop = false;
            }
            else if (gameObject.tag == "explosion_box")
                weapon.explosion_bullet = true;

            Destroy(gameObject);
        }
    }
}