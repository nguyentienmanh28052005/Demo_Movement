using System;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    //[SerializeField] private GameObject _bullet;

    private float _speed = 10f;
    private Rigidbody _rigidbody;
    private CharacterController _characterController;
    private float _power = 30f;
    public GameObject _cam;
    public LineRenderer _line;

        
    [Header("Force Mode")] 
    public bool Force;
    public bool Acceleration;
    public bool Impulse;
    public bool VelocityChange; 
    ForceMode _forceMode;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            //Transform_Translate();
            //Transform_Position();
            Rigidbody_velocity();
            //Rigidbody_Moveposition();
            Rigidbody_AddForce();
            //CharacterController_Move();
    }

    private void FixedUpdate()
    {
        if (Force) _forceMode = ForceMode.Force;
        else if (Acceleration) _forceMode = ForceMode.Acceleration;
        else if (Impulse) _forceMode = ForceMode.Impulse;
        else _forceMode = ForceMode.VelocityChange;
    }

    private void Transform_Position()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(horizontalInput * _speed * Time.deltaTime, 0, verticalInput * _speed * Time.deltaTime);
    }

    private void Transform_Translate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(horizontalInput * _speed * Time.deltaTime, 0, verticalInput * _speed * Time.deltaTime);
    }

    private void Rigidbody_velocity()
    {
        // Vector3 m_Input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        // _rigidbody.linearVelocity = m_Input * _speed;
        
        if (Input.GetMouseButtonUp(0))
        {
            _rigidbody.linearVelocity = _cam.transform.forward * _power;
        }
    }

    private void Rigidbody_Moveposition()
    {
        Vector3 m_Input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _rigidbody.MovePosition(transform.position + m_Input * Time.fixedDeltaTime * _speed);
    }   

    private void Rigidbody_AddForce()
    {
        // if(Input.GetMouseButtonUp(0))
        // {
        //     Vector3 force = new Vector3(0, 0, 100f); 
        //     _rigidbody.AddForce(_cam.transform.forward, _forceMode);
        // }
        Vector3 m_Input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _rigidbody.AddForce(_cam.transform.position + m_Input * 1000f * Time.deltaTime);
    }

    private void CharacterController_Move()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _characterController.Move(move * Time.deltaTime * _speed);
    }

    private void Fire()
    {
        //Instantiate(_bullet);
    }
}
