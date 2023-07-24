using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    public List<Transform> enemies;
    
    public float moveDistance = 6f;
    public float moveDuration = 10f;

    private float originalX;
    private bool moveRight = true;
    private Tweener tweener;

    public static EnemyController _instance;

    private void Awake()
    {
        if (_instance == null) _instance = this;
    }

    private void Start()
    {
        originalX = transform.position.x;
        MoveObject();
    }

    private void MoveObject()
    {
        float targetX = moveRight ? originalX + moveDistance : originalX - moveDistance;
        tweener = transform.DOMoveX(targetX, moveDuration).SetEase(Ease.Linear).OnComplete(ChangeDirection);    //used DoTween -> Tweener to Move and OnComplete event to change direction
    }

    private void ChangeDirection()
    {
        moveRight = !moveRight;
        MoveObject();
    }

    public void StopMovement()
    {
        if (tweener != null)
        {
            tweener.Kill();
            tweener = null;
        }
    }
}
