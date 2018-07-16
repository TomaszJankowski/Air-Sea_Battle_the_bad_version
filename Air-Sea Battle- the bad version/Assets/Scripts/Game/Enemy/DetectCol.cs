using UnityEngine;

public class DetectCol : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(col.collider, GetComponent<Collider2D>());
        }
    }
}
