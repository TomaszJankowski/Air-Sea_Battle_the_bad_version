using UnityEngine;
using UnityEngine.UI;

public class EnemyBasic : MonoBehaviour {
    public int points;
    public float speed;
    public ScoreManager score;
    public GameObject anim;
    public SpawnEnemy spawnPoint;
    public AudioClip SExplosion;
    [HideInInspector]
    public bool roteted = false, moving = true;
    [HideInInspector]
    public AudioSource source;

    public virtual void Awake()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        source = GetComponent<AudioSource>();
    }

   public virtual void Update ()
    {
        if (spawnPoint != null)
        {
            if (moving)
            {
                if (spawnPoint.leftSpawn)
                {
                    transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
                }
                else
                {
                    transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
                    if (!roteted)
                    {
                        Rotate();
                    }
                }
            }
        }
    }

    public void Rotate()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.y = transform.eulerAngles.y - 180;
        transform.rotation = Quaternion.Euler(rot);
        roteted = true;
    }

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            moving = false;
            if (col.gameObject.GetComponent<Bullet>().playerOne == true)
            {
                score.playerFirstScore = score.playerFirstScore + points;
            }
            else
                score.playerSecondScore = score.playerSecondScore + points;

            source.PlayOneShot(SExplosion);
            anim.SetActive(true);
            Invoke("Dead", 0.3f);
            Destroy(col.gameObject);
        }
    }

   public void Dead()
    {
        Destroy(gameObject);
    }
}
