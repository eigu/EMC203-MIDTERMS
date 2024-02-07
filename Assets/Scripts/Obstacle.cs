using UnityEngine;

public class Obstacle : Entity
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        Destroy(gameObject, 5f);
    }
}
