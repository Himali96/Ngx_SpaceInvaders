using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(k.Tags.PLAYER_BULLET))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag(k.Tags.PLAYER))
        {
            UIManager._instance.WinLoss("LOSS");

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag(k.Tags.WALL))
        {
            Destroy(gameObject);
        }
    }
}
