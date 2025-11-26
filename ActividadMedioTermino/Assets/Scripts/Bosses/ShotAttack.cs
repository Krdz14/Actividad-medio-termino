using UnityEngine;

public static class ShotAttack 
{
    public static void SimppleShot(Vector2 origin, Vector2 velocity)
    {
        Bullet bullet = BulletPool.Instance.RequestBullet();
        bullet.transform.position = origin;
        bullet.Velocity = velocity;
    }

    public static void RadialShot (Vector2 origin, Vector2 aimDirection, RadialShotSettings settings)
    {
        float angleBetweenBullets = 360f / settings.NumberOfBullets;

        if (settings.AngleOffset != 0f || settings.PhaseOffset != 0f)
            aimDirection = aimDirection.Rotate(settings.AngleOffset + (settings.PhaseOffset * angleBetweenBullets));

        for (int i = 0; i < settings.NumberOfBullets; i++ )
        {
            float bulletDirectionAngle = angleBetweenBullets * i;
            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);
            SimppleShot(origin, bulletDirection * settings.BulletSpeed);
        }
    }

    public static void FlowerShot(Vector2 center, float size, int petals, int bulletCount, float bulletSpeed)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float t = i * Mathf.PI * 2 / bulletCount;

            // Ecuación polar: r = sin(n * t)
            float r = Mathf.Sin(petals * t);
            float x = r * Mathf.Cos(t);
            float y = r * Mathf.Sin(t);

            Vector2 offset = new Vector2(x, y) * size;
            Vector2 position = center + offset;

            Bullet bullet = BulletPool.Instance.RequestBullet();
            bullet.transform.position = position;

            // Balas se mueven radialmente hacia afuera
            Vector2 direction = offset.normalized;
            bullet.Velocity = direction * bulletSpeed;
        }
    }

    
    public static void HeartShot(Vector2 center, float size, int bulletCount, float bulletSpeed)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float t = i * Mathf.PI * 2 / bulletCount;

            
            float x = 16 * Mathf.Pow(Mathf.Sin(t), 3);
            float y = 13 * Mathf.Cos(t) - 5 * Mathf.Cos(2 * t) - 2 * Mathf.Cos(3 * t) - Mathf.Cos(4 * t);

            Vector2 offset = new Vector2(x, y) * size * 0.05f; // Ajusta el tamaño
            Vector2 position = center + offset;

            Bullet bullet = BulletPool.Instance.RequestBullet();
            bullet.transform.position = position;

            Vector2 direction = (offset).normalized;
            bullet.Velocity = direction * bulletSpeed;
        }
    }

}

