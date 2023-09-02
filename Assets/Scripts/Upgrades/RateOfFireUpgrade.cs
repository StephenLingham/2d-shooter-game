public class RateOfFireUpgrade : UpgradeBase
{
    protected override void UpgradeEffect()
    {
        GlobalState.RateOfFire -= 0.5f;
    }
}
