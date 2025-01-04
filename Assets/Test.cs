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
    private float _targetRotation = 0.0f;
    private float _rotationVelocity;
    private float _verticalVelocity;
    public float _power2 = 50f;
    
    
    [Range(0.0f, 0.3f)]
    public float RotationSmoothTime = 0.12f;


        
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
            //Rigidbody_AddForce2();
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
         Vector3 m_Input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //_rigidbody.linearVelocity = m_Input * _speed;
        if (Input.GetKey(KeyCode.A))
        {
            m_Input = _cam.transform.right * -1 * _power2;
            _rigidbody.linearVelocity = m_Input;
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Input = _cam.transform.right * _power2; 
            _rigidbody.linearVelocity = m_Input;
        }
        if (Input.GetKey(KeyCode.W))
        {
            m_Input = _cam.transform.forward * _power2;        
            _rigidbody.linearVelocity = m_Input;
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_Input = _cam.transform.forward * -1 * _power2;           
            _rigidbody.linearVelocity = m_Input;
        }
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
        Vector3 m_Input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (Input.GetKey(KeyCode.A)) m_Input = _cam.transform.right * -1 * _power2;
        if (Input.GetKey(KeyCode.D)) m_Input = _cam.transform.right * _power2;
        if (Input.GetKey(KeyCode.W)) m_Input = _cam.transform.forward * _power2;
        if (Input.GetKey(KeyCode.S)) m_Input = _cam.transform.forward * -1 * _power2;
        m_Input.y = 0; ;
        _rigidbody.AddForce(m_Input.normalized * _power2 * Time.deltaTime, _forceMode);
    }
    

    private void CharacterController_Move()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move(inputDirection.normalized * (_speed * Time.deltaTime));
    }
}
