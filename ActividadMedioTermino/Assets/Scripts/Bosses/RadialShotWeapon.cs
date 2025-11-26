using UnityEngine;
using System.Collections;

public enum ShotType
{
    Radial,
    Heart,
    Flower
}

public class RadialShotWeapon : MonoBehaviour
{
    [SerializeField] private RadialShotPattern _shotPattern;
    [SerializeField] private ShotType shotType = ShotType.Radial;
    private bool _onShootPattern = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_onShootPattern)
            return;
        StartCoroutine(ExecuteRadialShotPattern(_shotPattern));
        
    }

    /*private IEnumerator ExecuteRadialShotPattern(RadialShotPattern pattern)
    {
        _onShootPattern = true;
        int lap = 0;
        Vector2 aimDirection = transform.up;
        Vector2 center = transform.position;

        yield return new WaitForSeconds(pattern.StartWait);

        while (lap < pattern.Repetitions)
        {
            for (int i = 0; i < pattern.PatternSettings.Length; i++ )
            {
                ShotAttack.RadialShot(center, aimDirection, pattern.PatternSettings[i]);
                yield return new WaitForSeconds(pattern.PatternSettings[i].CooldownAfterShot); 

            }
            lap++;

        }

        yield return new WaitForSeconds(pattern.EndWait);

        _onShootPattern = false;

    }*/

    private IEnumerator ExecuteRadialShotPattern(RadialShotPattern pattern)
    {
        _onShootPattern = true;
        Vector2 center = transform.position;
        Vector2 aimDirection = transform.up;

        yield return new WaitForSeconds(pattern.StartWait);

        for (int lap = 0; lap < pattern.Repetitions; lap++)
        {
            foreach (var settings in pattern.PatternSettings)
            {
                switch (shotType)
                {
                    case ShotType.Radial:
                        ShotAttack.RadialShot(center, aimDirection, settings);
                        break;

                    case ShotType.Heart:
                        ShotAttack.HeartShot(center, 1f, 80, 5f);
                        break;

                    case ShotType.Flower:
                        ShotAttack.FlowerShot(center, 1.5f, 6, 120, 3f);
                        break;
                }

                yield return new WaitForSeconds(settings.CooldownAfterShot);
            }
        }

        yield return new WaitForSeconds(pattern.EndWait);
        _onShootPattern = false;
    }
}
