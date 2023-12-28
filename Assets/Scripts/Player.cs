using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float runSpeed;

    private Rigidbody2D rig;

    private float initialSpeed;

    public bool isRunning { get; private set; }

    public Vector2 Direction { get; private set; }



    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update()
    {
        OnInput();

        OnRun();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void OnMove()
    {
        rig.MovePosition(rig.position + Direction * speed * Time.fixedDeltaTime);
    }

    private void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            isRunning = false;
        }
    }

    private void OnInput()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
