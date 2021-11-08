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
    public int bullets = 15;

    private void Start()
    {
        bullets_text.text = bullets.ToString();
    }

    void Update () {
	    if (Input.GetButtonDown("Fire1") && !reloading && bullets != 0)
        {
            Shoot();
            reloading = true;
            StartCoroutine(waiter());
        }
	}

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        reloading = false;
    }

    void Shoot()
    {
        var bullet_clone = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        var shell_clone = Instantiate(shellPrefab, firepoint_shell.position, firepoint_shell.rotation);
        Destroy(shell_clone, 1);
        Destroy(bullet_clone, 2);

        bullets = bullets - 1;
        bullets_text.text = bullets.ToString();
        if (bullets <= 5)
            bullets_text.color = Color.red;
        else
            bullets_text.color = Color.white;
    }

}
