using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private readonly float _moveSpeed = 5f;
    public string InputNameHorizontalKeyboard { private get; set; }
    public string InputNameHorizontalController { private get; set; }

    void Update()
    {
        var moveHorizontalKeyboard = Input.GetAxis(InputNameHorizontalKeyboard);
        var moveHorizontalController = Input.GetAxis(InputNameHorizontalController);
        var movement = new Vector3(moveHorizontalController != 0 ? moveHorizontalController : moveHorizontalKeyboard, 0, 0);
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