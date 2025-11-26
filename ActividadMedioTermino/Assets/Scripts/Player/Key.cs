using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private float keysToFind;
    public float currentKeys {get ; private set;}

    private void Awake()
    {
        currentKeys = 0;
    }

    public void AddKey(float value)
    {
        currentKeys = Mathf.Clamp(currentKeys + value, 0, keysToFind);
    }
}
