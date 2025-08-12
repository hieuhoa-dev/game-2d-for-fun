using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 5f;

    private Vector3 startPos;
    private bool movingRight = true;

    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= rightBound)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftBound)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void MoveToPlayer()
    {
        // Tính khoảng cách giữa enemy và người chơi
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Nếu người chơi trong bán kính 5f, enemy sẽ di chuyển theo
        if (distanceToPlayer <= distance * 2)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        // Di chuyển enemy theo người chơi
        //Vector2 direction = (player.transform.position - transform.position).normalized;
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime *2f );
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime * 2f);
        }    
    }
}
