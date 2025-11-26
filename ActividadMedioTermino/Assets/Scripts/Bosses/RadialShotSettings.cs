using UnityEngine;

[System.Serializable]
public class RadialShotSettings 
{
    [Header("Base Settings")]
    public int NumberOfBullets = 5;
    public float BulletSpeed = 10f;
    public float CooldownAfterShot = 0.5f;

    [Header("Offset")]
    [Range(-1f, 1f)] public float PhaseOffset = 0f;
    [Range(-180f, 180f)] public float AngleOffset = 0f;


}
