using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Vector2 Direction { get; private set; }

    private Rigidbody2D rig;


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + Direction * speed * Time.fixedDeltaTime);
    }
}
