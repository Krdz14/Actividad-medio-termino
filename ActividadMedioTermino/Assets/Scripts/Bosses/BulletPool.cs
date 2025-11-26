using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    private static BulletPool _instance;
    public static BulletPool Instance
    {
        get 
        {
            if (_instance == null)
                Debug.LogError("Bullet instance missing.");
            
            return _instance;
        }

    }

    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _initializePoolSize = 10;
    private List<Bullet> _bulletPool = new List<Bullet>();

    private void Awake()
    {
        //SETIP SINGLETON
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        //SETUP POOL
        AddBulletsToPool(_initializePoolSize);
    }

    private void AddBulletsToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab);
            bullet.gameObject.SetActive(false);
            _bulletPool.Add(bullet);
            bullet.transform.parent = transform;
        }
    }

    public Bullet RequestBullet()
    {
        for (int i = 0; i < _bulletPool.Count; i++)
        {
            if (!_bulletPool[i].gameObject.activeSelf)
            {
                _bulletPool[i].gameObject.SetActive(true);
                return _bulletPool[i];
            }
        }
        AddBulletsToPool(1);
        _bulletPool[_bulletPool.Count - 1].gameObject.SetActive(true);
        return _bulletPool[_bulletPool.Count - 1];
    }

    public void ReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

}
