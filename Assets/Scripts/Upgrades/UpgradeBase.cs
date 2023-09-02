using UnityEngine;

public abstract class UpgradeBase : MonoBehaviour
{
    private Collider2D _playerCollider;
    private Collider2D _upgradeCollider;

    public void Start()
    {
        _playerCollider = GameObject
            .FindGameObjectWithTag("Player")
            .GetComponent<Collider2D>();

        _upgradeCollider = GetComponent<Collider2D>();
    }

    public void Update()
    {
        if (_upgradeCollider.bounds.Intersects(_playerCollider.bounds))
        {
            UpgradeEffect();

            Destroy(gameObject);
        }
    }

    protected abstract void UpgradeEffect();
}
