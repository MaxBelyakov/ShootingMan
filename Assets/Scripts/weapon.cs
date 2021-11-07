using System.Collections;
using UnityEngine;

public class weapon : MonoBehaviour {

    public Transform firepoint;
    public Transform firepoint_shell;
    public GameObject bulletPrefab;
    public GameObject shellPrefab;
    private bool reloading = false;

    void Update () {
	    if (Input.GetButtonDown("Fire1") && !reloading)
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
    }

}
