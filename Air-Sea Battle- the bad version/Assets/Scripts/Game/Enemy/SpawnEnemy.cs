using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public bool leftSpawn;
    public float timeToSpawn;
    float timer;
    public GameObject[] enemyList;
    Vector3 position;
    Vector3 pos;

    private void Start()
    {
        if (leftSpawn)
        {
            position.y = transform.position.y;
            position.x = -Camera.main.orthographicSize - 2f;
            position.z = 0f;
        }
        else
        {
            position.y = transform.position.y;
            position.x = Camera.main.orthographicSize + 2f;
            position.z = 0f;
        }
    }

    void Update()
    {
        pos.x = position.x * Camera.main.aspect;
        transform.position = new Vector3(pos.x,position.y,position.z);

        timer = timer + Time.deltaTime;

        if (timer >= timeToSpawn)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        GameObject enemy = Instantiate(enemyList[Random.Range(0, enemyList.Length)]);
        enemy.transform.position = transform.position;
        enemy.GetComponent<EnemyBasic>().spawnPoint = this;
    }
}
