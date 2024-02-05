using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputManager inputManager;

    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    [SerializeField] private float speed;

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        float movementInput = inputManager.GetMovementInput().y;

        switch (movementInput)
        {
            case > 0:
                Move(pointA.position);
                break;
            case < 0:
                Move(pointB.position);
                break;
        }
    }

    private void Move(Vector3 point)
    {
        transform.position = Vector3.Lerp(transform.position, point, Time.deltaTime * speed);
    }
}
