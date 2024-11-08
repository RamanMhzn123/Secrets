using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Bullet
{
    /// <summary>
    /// Disable Bullet when collides or after some time
    /// </summary>
    public class Bullet : MonoBehaviour
    {
        public float bulletSpeed = 10f;           
        public float bulletLifetime = 2f;         

        private Rigidbody2D _bulletRb;

        private void OnEnable()
        {
            // Reset the lifetime timer when the bullet is enabled
            Invoke(nameof(Deactivate), bulletLifetime);
            _bulletRb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // Move the bullet forward in its current direction
            _bulletRb.velocity = transform.up * bulletSpeed;  // Moves the bullet along the local "up" axis
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Deactivate();
        }

        private void Deactivate()
        {
            CancelInvoke();
            BulletPool.Instance.ReturnBullet(gameObject);
        }

        private void OnDisable()
        {
            CancelInvoke();  // Clear invoke when bullet is disabled
        }
    }
}