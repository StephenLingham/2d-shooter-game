public static class GlobalState
{
    public static float PlayerSpeed { get; set; } = 5f;
    public static float ProjectileSpeed { get; set; } = 10f;
    public static float ProjectileDamage { get; set; } = 1f;
    /// <summary>
    /// Time between shots in seconds
    /// </summary>
    public static float RateOfFire { get; set; } = 1f;
    /// <summary>
    /// The number of enemies the projectile can pierce through i.e. the number of enemies the projetile can hit before it disappears
    /// </summary>
    public static int ProjectilePiercing { get; set; } = 2;
}
