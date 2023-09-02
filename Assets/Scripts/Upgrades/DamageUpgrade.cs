public class DamageUpgrade : UpgradeBase
{
    protected override void UpgradeEffect()
    {
        GlobalState.ProjectileDamage++;
    }
}
