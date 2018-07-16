using UnityEngine;

public class Shooting : MonoBehaviour {
 
    public float timeToFire, timeToDestroyBullet;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public AudioClip shootingSound;

    AudioSource source;

    [HideInInspector]
    public float timer;
    [HideInInspector]
    public Bullet bulScript;
    [HideInInspector]
    public GameObject bullet;
    [HideInInspector]
    public bool fire;
    



	public void Start () {
        firePoint = GetComponent<Transform>();
        source = GetComponent<AudioSource>();
	}

    public virtual void Update()
    {
        if (Time.timeScale > 0)
        {
            timer = timer + Time.deltaTime;

            if (timer >= timeToFire)
            {
                if (Input.GetButton("Fire1"))
                {
                    fire = true;
                }
            }
        }

    }

    public void FixedUpdate() {
       
        if(fire)
        {
            Shoot();
            timer = 0f;
            fire = false;
        }

	}

    public virtual void Shoot()
    {
        /*Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
        */
        
        bullet = Instantiate(bulletPrefab);
        bulScript = bullet.GetComponent<Bullet>();
        bullet.transform.position = bulletSpawn.position;
        Vector3 rot = bullet.transform.rotation.eulerAngles;
        rot.z = transform.eulerAngles.z-90;
        bullet.transform.rotation = Quaternion.Euler(rot);
        source.PlayOneShot(shootingSound);
        Debug.Log(rot);
        bulScript.playerOne = true;
        Destroy(bullet, timeToDestroyBullet);
    }


}
