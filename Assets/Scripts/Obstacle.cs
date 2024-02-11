public class Obstacle : Entity
{
    protected override void Start()
    {
        base.Start();
        Destroy(gameObject, 5f);
    }
}
