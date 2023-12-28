using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float runSpeed;

    private Rigidbody2D rig;

    private float initialSpeed;

    public bool isRunning { get; private set; }
    
    public bool isRolling { get; private set; }

    public Vector2 Direction { get; private set; }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    void Update()
    {
        OnInput();

        OnRun();

        OnRolling();
    }

    void FixedUpdate()
    {
        OnMove();
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + Direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
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

    void OnInput()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnRolling()
    {
        if(Input.GetMouseButtonDown(1)) 
        {
            speed = runSpeed;
            isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            speed = initialSpeed;
            isRolling = false;
        }
    }
}
