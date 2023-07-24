using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform EnemyBulletParent;
    
    private float minSpawnDelay = 0.5f;
    private float maxSpawnDelay = 2.0f;

    private void Start()
    {
        float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        InvokeRepeating("SpawnBullet", randomDelay, randomDelay);
    }

    private void SpawnBullet()
    {
        if (EnemyController._instance.enemies.Count != 0)
        {
            int enemyNum = Random.Range(0, EnemyController._instance.enemies.Count);

            Instantiate(bulletPrefab, EnemyController._instance.enemies[enemyNum].position, Quaternion.identity, EnemyBulletParent);
        }
        else
        {
            CancelInvoke("SpawnBullet");
            UIManager._instance.WinLoss("WIN");
        }
    }

}
