public class ProjectileSpeedUpgrade : UpgradeBase
{
    protected override void UpgradeEffect()
    {
        GlobalState.ProjectileSpeed += 5f;
    }
}
