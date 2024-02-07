using UnityEngine;

public interface IMoveable
{
    public static void Move(Transform obj, Vector3 direction, float speed)
    {
        obj.transform.Translate(direction * speed * Time.deltaTime);
    }
}
