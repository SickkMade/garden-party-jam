using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5;

    [SerializeField] InputReader inputReader;
    private Rigidbody rb;
    private Vector2 playerMovement = new();

    void Start()
    {
        if(inputReader != null){
            inputReader.moveEvent += OnMove;
        }

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // rb.AddForce(movementSpeed * Time.deltaTime * playerMovement, ForceMode.Impulse);
        rb.linearVelocity = new Vector2 (movementSpeed * Time.fixedDeltaTime * playerMovement.x, rb.linearVelocity.y);
    }

    private void OnMove(Vector2 movement){
        playerMovement = movement;
    }
}
