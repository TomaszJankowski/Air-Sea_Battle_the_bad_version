using UnityEngine;

public class Movement_P2 : Player_Movement {

    public override void FixedUpdate()
    {
       rightleft = Input.GetAxisRaw("Vertical");
       rb.velocity = new Vector2(rightleft, 0f) * speed * Time.deltaTime;
    }
}
