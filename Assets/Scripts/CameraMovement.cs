using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private void LateUpdate()
    {
        IMoveable.Move(transform, Vector3.right, speed);
    }
}
