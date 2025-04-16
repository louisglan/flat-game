using System;
using UnityEngine;

public class Banana : MonoBehaviour
{
    private const float MaxSpeed = 10f;
    private Rigidbody2D _rb2d;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.AddForce(new Vector2(0f, MaxSpeed / 3), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.Magnitude(_rb2d.linearVelocity);
        if (speed > MaxSpeed)
        {
            _rb2d.linearVelocity = _rb2d.linearVelocity.normalized * MaxSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            transform.position += new Vector3(0f, 2f, 0f);
            _rb2d.linearVelocity = new Vector2(0f, MaxSpeed / 3);
            _rb2d.angularVelocity = 0f;
            other.gameObject.GetComponent<Collider2D>().enabled = true;
        } else if (other.gameObject.CompareTag("Finish Line"))
        {
            Time.timeScale = 0f;
        }
    }
}
