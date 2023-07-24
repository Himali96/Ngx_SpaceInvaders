using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform playerBulletParent;

    //ForTouchControls
    [HideInInspector] public bool isLeftButtonPressed; 
    [HideInInspector] public bool isRightButtonPressed;

    private float clampXMin = -9f;
    private float clampXMax = 9f;
    private float dirX;
    private float moveSpeed = 15f;
    
    Rigidbody2D rb;
    Vector2 pos;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_WEBGL
        float horizontalInput = Input.GetAxis("Horizontal");
        float deltaX = horizontalInput * moveSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(deltaX, 0f, 0f);
        transform.position = newPosition;
        transform.localPosition = new Vector2(Mathf.Clamp(transform.localPosition.x, clampXMin, clampXMax), transform.localPosition.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
#endif
#if UNITY_IOS || UNITY_ANDROID
        if (!UIManager._instance.isTouchControlsOn) {
            dirX = Input.acceleration.x * moveSpeed;
            transform.localPosition = new Vector2(Mathf.Clamp(transform.localPosition.x, clampXMin, clampXMax), transform.localPosition.y);

            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                Fire();
            }
        } else
        {
            if(isLeftButtonPressed) Move(-1);
            if (isRightButtonPressed) Move(1);
        }
#endif
    }

    public void Move(int mov)
    {
        transform.localPosition = new Vector2 ((Mathf.Clamp((transform.localPosition.x + (moveSpeed * mov) * Time.deltaTime), clampXMin, clampXMax)), transform.localPosition.y);
    }

    void FixedUpdate()
    {
#if (UNITY_IOS || UNITY_ANDROID)
        if (!UIManager._instance.isTouchControlsOn)
        {
            rb.velocity = new Vector2(dirX, 0f);
        }
#endif
    }

    public void Fire()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity, playerBulletParent);
    }
}
