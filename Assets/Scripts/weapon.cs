using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class weapon : MonoBehaviour {

    public Transform firepoint;
    public Transform firepoint_shell;
    public GameObject bulletPrefab;
    public GameObject shellPrefab;
    private bool reloading = false;
    public Text bullets_text;
    public static int bullets = 15;
    public static bool get_box_10 = false; /* drop box with bullets checker*/
    public static bool explosion_bullet = false;

    void Start()
    {
        bullets_text.text = bullets.ToString();
    }

    /* looking for shot or getting bullet box */
    void Update() {
        if (Input.GetButtonDown("Fire1") && !reloading && bullets != 0)
        {
            Shoot();
            reloading = true;
            StartCoroutine(waiter());
        }
        if (get_box_10)
        {
            bullets = bullets + 10;
            UpdateBullets();
            get_box_10 = false;
        }
            
    }

    /* reloading */
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        reloading = false;
    }

    /* shooting */
    void Shoot()
    {
        var bullet_clone = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        var shell_clone = Instantiate(shellPrefab, firepoint_shell.position, firepoint_shell.rotation);
        Destroy(shell_clone, 1);
        Destroy(bullet_clone, 2);

        if (!explosion_bullet)
        {
            bullets = bullets - 1;
            UpdateBullets();
        }
        
    }

    /* draw new amount of bullets */
    private void UpdateBullets()
    {
        bullets_text.text = bullets.ToString();
        if (bullets <= 5)
            bullets_text.color = Color.red;
        else
            bullets_text.color = Color.white;
    }

}