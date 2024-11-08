using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance; // Singleton for easy access
    public GameObject bulletPrefab; // Bullet prefab to instantiate
    public int poolSize = 20; // Number of bullets to keep in the pool

    private List<GameObject> bulletPool; // List to hold pooled bullets

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        InitializePool();
    }

    // Initialize the pool
    private void InitializePool()
    {
        bulletPool = new List<GameObject>();

        for (var i = 0; i < poolSize; i++)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false); // Deactivate the bullet initially
            bulletPool.Add(bullet);
        }
    }

    // Method to get a bullet from the pool
    public GameObject GetBullet()
    {
        foreach (var bullet in bulletPool)
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }

        // If all bullets are active, add a new one (optional)
        var newBullet = Instantiate(bulletPrefab);
        newBullet.SetActive(true);
        bulletPool.Add(newBullet);

        return newBullet;
    }

    // Return bullet to pool
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}