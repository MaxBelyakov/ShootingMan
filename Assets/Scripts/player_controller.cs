using UnityEngine;

public class player_controller : MonoBehaviour {

    private Rigidbody2D rb;
    private bool FaceRight = true;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        float moveY = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        float player_z = transform.rotation.eulerAngles.z;

        /* Looking up and down */
        if ((moveY != 0) && ((player_z >= 0 && player_z <= 30) || (player_z >= 340 && player_z <= 360)))
        {
            transform.eulerAngles += new Vector3(0, 0, 2) * moveY;

            /* Back step to return in players look range */
            if ((transform.rotation.eulerAngles.z > 30) && (transform.rotation.eulerAngles.z < 340))
            {
                transform.eulerAngles += new Vector3(0, 0, -2) * moveY;
            }
        }

        /* Moving left and right, stop near the boarder*/
        if ((rb.position.x >= -9) && (rb.position.x <= 9))
        {
            rb.MovePosition(rb.position + Vector2.right * moveX * 10f * Time.deltaTime);
        }
        else if ((rb.position.x < -9) && (moveX > 0))
            rb.position += new Vector2(0.05f, 0);
        else if ((rb.position.x > 9) && (moveX < 0))
            rb.position -= new Vector2(0.05f, 0);

        /* Flip player */
        if (moveX > 0 && !FaceRight)
            flip();
        else if (moveX < 0 && FaceRight)
            flip();
    }

    void flip()
    {
        FaceRight = !FaceRight;
        Vector3 target = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(target.x, target.y + 180, target.z);
    }

}
