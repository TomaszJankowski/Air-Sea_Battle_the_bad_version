using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public bool leftSpawn;
    public float timeToSpawn;
    float timer;
    public GameObject[] enemyList;

    void Update()
    {
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
        Destroy(enemy, 5f);
    }
}
