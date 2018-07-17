using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public float speed;
    [HideInInspector]
    public float rightleft;
    [HideInInspector]
    public Rigidbody2D rb;

	public void Start () {
       rb = GetComponent<Rigidbody2D>();
       Physics2D.IgnoreLayerCollision(8,8, true);
    }

    public virtual void FixedUpdate()
    {
        rightleft = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(rightleft,0f) * speed * Time.deltaTime;
    }
}
