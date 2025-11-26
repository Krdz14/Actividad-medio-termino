using UnityEngine;
using UnityEngine.UI;

public class KeyCollectBar : MonoBehaviour
{
    [SerializeField] private Key playerKey;
    [SerializeField] private Image totalKeybar;
    [SerializeField] private Image currentKeybar;

    private void Start()
    {
        totalKeybar.fillAmount = 1;
    }

    private void Update()
    {
        currentKeybar.fillAmount = playerKey.currentKeys;

    }
}

