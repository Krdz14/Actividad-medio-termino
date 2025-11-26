using UnityEngine;
using TMPro;

public class BulletUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;

    void Update()
    {
        counterText.text =
            $"Jugador: {BulletStats.ActivePlayerProjectiles}\n" +
            $"Enemigo: {BulletStats.ActiveEnemyBullets}\n" +
            $"Total: {BulletStats.TotalActive}";
    }
}
