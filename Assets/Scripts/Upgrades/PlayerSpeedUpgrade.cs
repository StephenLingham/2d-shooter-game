public class PlayerSpeedUpgrade : UpgradeBase
{
    protected override void UpgradeEffect()
    {
        GlobalState.PlayerSpeed += 2f;
    }
}
