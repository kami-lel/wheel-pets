using UnityEngine;

public class JumpController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int jumpPower;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }
    }
}
