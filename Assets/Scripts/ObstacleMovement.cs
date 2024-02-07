using System;
using UnityEngine;

public enum MovementPattern
{
    FastAppraoching,
    Vertical,
    Spherical
}

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] MovementPattern movementPattern;

    private void Start()
    {
        RandomizeMovementPattern();
    }

    private void LateUpdate()
    {
        switch (movementPattern)
        {
            case MovementPattern.FastAppraoching:
                IMovable.Move(transform, Vector3.left, speed);
                break;
            case MovementPattern.Vertical:
                IMovable.MoveVertical(transform, speed); ;
                break;
            case MovementPattern.Spherical:
                IMovable.MoveInCircle(transform, speed);
                break;
        }
    }

    private void RandomizeMovementPattern()
    {
        int randomIndex = UnityEngine.Random.Range(0, Enum.GetNames(typeof(MovementPattern)).Length);
        movementPattern = (MovementPattern)randomIndex;
    }
}
