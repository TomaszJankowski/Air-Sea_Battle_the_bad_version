using UnityEngine;

public class EnemySpecial : EnemyBasic {
    public AudioClip playerKillSound;
    public float sensitivity;
    GameObject[] targets;
    int indexs;
    GameObject target;
    SpriteRenderer flip;

    public override void Awake()
    {
        base.Awake();
        flip = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreLayerCollision(0,9,true);
    }

    public void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Player");
        target = targets[indexs];
        indexs = Random.Range(0, targets.Length);
        Debug.Log(target);
    }

    public override void Update()
    {
        if(spawnPoint != null && target != null)
        {
            if (moving)
            { 
                if (spawnPoint.leftSpawn)
                {
                    FollowFromLeft();
                    
                }
                else
                {
                    FollowFromRight();
                }

                Invoke("Dead", 6f);
            }
        }
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);

        if (col.gameObject.tag == "Player")
        {
            source.PlayOneShot(playerKillSound);
            Debug.Log("Hit");
            moving = false;
            anim.SetActive(true);
            Destroy(col.gameObject);
            Invoke("StopGame", 0.3f);
        }
    }


    void FollowFromLeft()
    {
        Vector3 relativepos = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(relativepos.y, relativepos.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, sensitivity);
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }
    void FollowFromRight()
    {
        Vector3 relativepos = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(-relativepos.y,-relativepos.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, sensitivity);
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
        flip.flipX = true;
    }

    void StopGame()
    {
        Time.timeScale = 0f;
    }
}
