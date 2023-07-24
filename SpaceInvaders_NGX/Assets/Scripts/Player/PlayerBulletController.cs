using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public UIManager ui_manager;

    private void Start()
    {
        ui_manager = UIManager._instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(k.Tags.ENEMY_BULLET))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == k.Layers.ENEMY)
        {
            if (collision.gameObject.CompareTag(k.Tags.SPECIAL_ENEMY))
            {
                CoinSpawner._instance.SpawnCoin(collision.transform.position);
            }
            ui_manager.score++;
            ui_manager.scoreTxt.text = "Score: " + ui_manager.score.ToString();
            ui_manager.EnableParticle(collision.transform.position);

            EnemyController._instance.enemies.Remove(collision.transform);

            if (EnemyController._instance.enemies.Count == 0)
            {
                ui_manager.WinLoss("WIN");
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag(k.Tags.WALL))
        {
            Destroy(gameObject);
        }
    }
}
