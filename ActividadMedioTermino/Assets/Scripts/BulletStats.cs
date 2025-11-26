using UnityEngine;

public static class BulletStats
{
    public static int ActiveEnemyBullets { get; private set; } = 0;
    public static int ActivePlayerProjectiles { get; private set; } = 0;

    public static int TotalActive => ActiveEnemyBullets + ActivePlayerProjectiles;

    public static void AddEnemyBullet() => ActiveEnemyBullets++;
    public static void RemoveEnemyBullet() => ActiveEnemyBullets = Mathf.Max(0, ActiveEnemyBullets - 1);

    public static void AddPlayerProjectile() => ActivePlayerProjectiles++;
    public static void RemovePlayerProjectile() => ActivePlayerProjectiles = Mathf.Max(0, ActivePlayerProjectiles - 1);
}
