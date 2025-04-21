using System;
using DefaultNamespace;
using UnityEngine;

public class Banana : MonoBehaviour
{
    private const float MaxVerticalSpeed = 5f;
    private Rigidbody2D _rb2d;
    public GameObject FinishGameMenuUI;
    public static event Action OnGameOver;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.AddForce(new Vector2(0f, MaxVerticalSpeed / 2), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb2d.linearVelocityY > MaxVerticalSpeed)
        {
            _rb2d.linearVelocityY = MaxVerticalSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            transform.position += new Vector3(0f, 2f, 0f);
            _rb2d.linearVelocity = new Vector2(0f, MaxVerticalSpeed / 3);
            _rb2d.angularVelocity = 0f;
            other.gameObject.GetComponent<Collider2D>().enabled = true;
        } else if (other.gameObject.CompareTag("Finish Line"))
        {
            GlobalStateManager.Instance.isGameOver = true;
            OnGameOver?.Invoke();
            Time.timeScale = 0f;
        }
    }
}
