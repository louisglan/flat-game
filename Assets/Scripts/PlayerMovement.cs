using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveHorizontal;
    private readonly float moveSpeed = 5f;

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new(moveHorizontal, 0, 0);
        transform.Translate(moveSpeed * Time.deltaTime * movement);
    }
}
