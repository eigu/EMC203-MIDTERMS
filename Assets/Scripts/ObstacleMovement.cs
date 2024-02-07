using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private void LateUpdate()
    {
        IMoveable.Move(transform, Vector3.left, speed);
    }
}
