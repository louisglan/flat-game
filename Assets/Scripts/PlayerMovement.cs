using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private readonly float _moveSpeed = 5f;

    void Update()
    {
        var moveHorizontal = Input.GetAxisRaw("Horizontal");
        var movement = new Vector3(moveHorizontal, 0, 0);
        if (!IsLeavingBounds(movement))
        {
            transform.Translate(_moveSpeed * Time.deltaTime * movement);
        }
    }

    private bool IsLeavingBounds(Vector3 movement)
    {
        float halfScreenWidth = 10.2f;
        return transform.position.x < -halfScreenWidth && movement.x < 0
               || transform.position.x > halfScreenWidth && movement.x > 0;
    }
}