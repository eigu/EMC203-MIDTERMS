using UnityEngine;

public class Obstacle : Entity
{
    [SerializeField] private float speed;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
