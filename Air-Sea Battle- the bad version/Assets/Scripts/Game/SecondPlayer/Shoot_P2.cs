using UnityEngine;

public class Shoot_P2 : Shooting {

    public override void Update()
    {
        if (Time.timeScale > 0)
        {
            timer = timer + Time.deltaTime;

            if (timer >= timeToFire)
            {
                if (Input.GetButton("Fire2"))
                {
                    fire = true;
                }
            }
        }
    }

    public override void Shoot()
    {
        base.Shoot();
        bulScript.playerOne = false;
    }
}
