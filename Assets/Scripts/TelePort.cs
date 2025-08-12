using UnityEngine;

public class TelePort : MonoBehaviour
{
    [SerializeField] Transform PointB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("cham");
            collision.transform.position = PointB.transform.position;
        }
    }
}
