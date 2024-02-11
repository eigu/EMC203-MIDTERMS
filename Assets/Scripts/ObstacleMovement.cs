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
    [SerializeField] MovementPattern movementPattern;

    [SerializeField] private float speed;
    [SerializeField] private float range;

    private float movementTimer;

    private void Start()
    {
        RandomizeMovement();
    }

    private void Update()
    {
        movementTimer += Time.deltaTime;

        switch (movementPattern)
        {
            case MovementPattern.FastAppraoching:
                IMovable.Move(transform, Vector3.left, speed);
                break;
            case MovementPattern.Vertical:
                IMovable.MoveVertical(transform, range, movementTimer); ;
                break;
            case MovementPattern.Spherical:
                IMovable.MoveInCircle(transform, range,movementTimer);
                break;
        }
    }

    private void RandomizeMovement()
    {
        int randomIndex = UnityEngine.Random.Range(0, Enum.GetNames(typeof(MovementPattern)).Length);
        movementPattern = (MovementPattern)randomIndex;

        speed = UnityEngine.Random.Range(10f, 50f);
        range = UnityEngine.Random.Range(10f, 50f);
    }
}
