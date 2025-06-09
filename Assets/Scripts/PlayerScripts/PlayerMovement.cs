using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float p_rotation;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform ground_check;
    [SerializeField] private LayerMask ground_layer;
    [SerializeField] private float move_speed = 300f;
    [SerializeField] private float jump_strenght = 10f;

    void Update()
    {
        flip_sprite();

        if (Input.GetKeyDown(KeyCode.Space) && is_grounded())
        {
            jump();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = get_input() * move_speed * Time.deltaTime;
    }

    void flip_sprite()
    {
        if (rb.linearVelocityX > 1.0f || rb.linearVelocityX < -1.0f)
        {
            if (rb.linearVelocityX > 0.0f)
            {
                p_rotation = 0f;
            }
            else
            {
                p_rotation = 180f;
            }
        }
        transform.rotation = Quaternion.Euler(0f, p_rotation, 0f);
    }

    private void jump()
    {
        rb.AddForce(transform.up * jump_strenght);
    }

    private float get_input()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    private bool is_grounded()
    {
        return Physics2D.OverlapCircle(ground_check.position, 1f, ground_layer);
    }
}
