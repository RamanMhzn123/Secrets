using System;
using UnityEngine;

namespace Game.Scripts.Character
{
    public class PlayerController : MonoBehaviour
    {
        private float _speed; // Player movement speed
        [SerializeField] private string collidableObjectTag = "Collidable";

        private void Awake()
        {
            _speed = 5;
        }

        private void Update()
        {
            if(Input.GetKey(KeyCode.W)) { // Controls movements in all four directions
                transform.Translate(Vector2.up * TestVert(Vector2.up));
            }
            if(Input.GetKey(KeyCode.A)) {
                transform.Translate(Vector2.left * TestHor(Vector2.left));
            }
            if(Input.GetKey(KeyCode.S)) {
                transform.Translate(Vector2.down * TestVert(Vector2.down));
            } 
            if(Input.GetKey(KeyCode.D)) {
                transform.Translate(Vector2.right * TestHor(Vector2.right));
            }
        }

        private float TestHor(Vector2 dir) 
        {
            Vector2 origin = transform.position;
            float offset;
            if (dir.Equals(Vector2.left)) {
                offset = -0.125f; // Offset for left side of character
            } else {
                offset = 0.125f; // Offset for right side of character
            }
            origin.x += offset;
            RaycastHit2D raycast = Physics2D.Raycast(origin, dir, _speed * Time.deltaTime);

            if (!raycast.collider || !raycast.collider.gameObject.CompareTag(collidableObjectTag))
                return _speed * Time.deltaTime;
            
            // If raycast hits something tagged "Collidable"
            float distance = Math.Abs(raycast.point.x - origin.x);
            return distance;

        }

        private float TestVert(Vector2 dir) 
        {
            Vector2 origin = transform.position;
            float offset;
            if (dir.Equals(Vector2.up)) {
                offset = .1f; // Offset for top side of character
            } else {
                offset = -0.5f; // Offset for bottom side of character
            }
            origin.y += offset;
            RaycastHit2D raycast = Physics2D.Raycast(origin, dir, _speed * Time.deltaTime);

            if (!raycast.collider || !raycast.collider.gameObject.CompareTag(collidableObjectTag))
                return _speed * Time.deltaTime;
            
            // If raycast hits something tagged "Collidable"
            float distance = Math.Abs(raycast.point.y - origin.y);
            return distance;

        }
    }
}