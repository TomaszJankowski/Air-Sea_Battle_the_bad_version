using UnityEngine;

public class DetectCol : MonoBehaviour
{
    public bool left;
    Vector3 pos = new Vector3(1f,0.5f,1f);
    Vector3 posleft = new Vector3(0f, 0.5f, 1f);

    private void Update()
    {
        if(!left)
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        else
            transform.position = Camera.main.ViewportToWorldPoint(posleft);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(col.collider, GetComponent<Collider2D>());
        }
    }
}
