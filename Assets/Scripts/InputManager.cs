using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerInput playerInput;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        Instance = this;


        playerInput = GetComponent<PlayerInput>();
    }

    public Vector2 GetMovementInput()
    {
        InputAction moveAction = playerInput.actions.FindAction("Move");

        return moveAction.ReadValue<Vector2>();
    }
}
