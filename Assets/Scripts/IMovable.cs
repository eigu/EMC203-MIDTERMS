using UnityEngine;
using UnityEngine.UIElements;

public interface IMovable
{
    public static void Move(Transform obj, Vector3 direction, float speed)
    {
        obj.transform.Translate(direction * speed * Time.deltaTime);
    }

    public static void MoveVertical(Transform obj, float speed)
    {
        Vector3 initialPosition = obj.transform.position;

        float y = Mathf.Sin(Time.time * speed);

        Vector3 offset = new Vector3(0, y, 0);
        obj.transform.position = initialPosition + offset;
    }

    public static void MoveInCircle(Transform obj, float speed)
    {
        Vector3 center = obj.transform.position;

        float x = Mathf.Cos(Time.time * speed);
        float y = Mathf.Sin(Time.time * speed);

        Vector3 offset = new Vector3(x, y, 0f);
        obj.transform.position = center + offset;
    }
}