using System.Threading;
using UnityEngine;

public class SmoothMovement : IMovementStrategy
{
    public void Move(Transform transform, Player player)
    {
        float moveInX = Input.GetAxis("Horizontal") * player.Velocity * Time.deltaTime;
        transform.Translate(moveInX, 0, 0);
    }
}