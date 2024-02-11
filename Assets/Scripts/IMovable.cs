using UnityEngine;

public interface IMovable
{
    public static void Move(Transform obj, Vector3 direction, float speed)
    {
        obj.transform.Translate(direction * speed * Time.deltaTime);
    }

    public static void MoveVertical(Transform obj, float range, float verticalSpeed)
    {
        float newY = Mathf.Cos(verticalSpeed) * range * Time.deltaTime;

        obj.transform.position += Vector3.up * newY;
    }

    public static void MoveInCircle(Transform obj, float range, float circularSpeed)
    {
        float newX = Mathf.Sin(circularSpeed) * range * Time.deltaTime;
        float newY = Mathf.Cos(circularSpeed) * range * Time.deltaTime;

        obj.transform.position += new Vector3(newX, newY, 0f);
    }
}