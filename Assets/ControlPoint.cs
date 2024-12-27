using System;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float x, y = 0f;
    public Rigidbody _rb;
    public float _speed = 5f;
    public float _power = 30f;
    public LineRenderer _line;

    // Update is called once per frame

    private void Start()
    {
    }

    void Update()
    {
        transform.position = _rb.position;

        if (Input.GetMouseButton(0))
        {
            _line.gameObject.SetActive(true);
            x += Input.GetAxis("Mouse X") * _speed;
            y += Input.GetAxis("Mouse Y") * _speed;
            transform.rotation = Quaternion.Euler(-y, x, 0);
            _line.SetPosition(0, transform.position);
            _line.SetPosition(1, transform.position + transform.forward * 4f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _line.gameObject.SetActive(false);
        }
    }
}
