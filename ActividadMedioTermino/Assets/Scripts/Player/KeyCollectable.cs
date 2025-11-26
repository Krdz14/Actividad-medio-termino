using UnityEngine;

public class KeyCollectable : MonoBehaviour
{
    [SerializeField] private float keyValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Key>().AddKey(keyValue);
            gameObject.SetActive(false);
        }
    }


}
