// using UnityEngine;
//
// public class PlayerDirection : MonoBehaviour
// {
//     private PlayerMovement playerMovement;
//
//     private void Awake()
//     {
//         playerMovement = GetComponent<PlayerMovement>();
//     }
//
//     private void Update()
//     {
//         FaceDirection();
//     }
//
//     private void FaceDirection()
//     {
//         if (playerMovement.lastDirection == Vector2.up)
//             transform.rotation = Quaternion.Euler(0, 0, 0);
//         else if (playerMovement.lastDirection == Vector2.down)
//             transform.rotation = Quaternion.Euler(0, 0, 180);
//         else if (playerMovement.lastDirection == Vector2.left)
//             transform.rotation = Quaternion.Euler(0, 0, 90);
//         else if (playerMovement.lastDirection == Vector2.right)
//             transform.rotation = Quaternion.Euler(0, 0, -90);
//     }
// }