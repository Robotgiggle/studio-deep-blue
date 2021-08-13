using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{

    // public variables
    public float moveSpeed = 3.0f;
    public float gravity = 9.81f;
    public float boostRate = 25;
    public float nextSpeedBoost;
    float _vy;
    public float jumpForce = 200000;

    public GameObject trailEffect;
    private CharacterController myController;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    Transform _transform;
    Rigidbody _rigidbody;
    public bool isGrounded = false;
    public bool canJump = false;
    int _playerLayer;


    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null) // if Rigidbody is missing
            Debug.LogError("Rigidbody2D component missing from this gameobject");
        _playerLayer = this.gameObject.layer;

    }

    // Use this for initialization
    void Start()
    {
        // store a reference to the CharacterController component on this gameObject
        // it is much more efficient to use GetComponent() once in Start and store
        // the result rather than continually use etComponent() in the Update function
        myController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {   if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Quit");
            Application.Quit();
        }

        isGrounded = Physics.Linecast(_transform.position, groundCheck.position, whatIsGround);
        if (isGrounded)
        {
            canJump = true;
        }

        _vy = _rigidbody.velocity.y;

        if (Input.GetButtonDown("Jump") && _vy == 0f && canJump)
        {
            DoJump();
            //_vy = _vy + 5f;
            //canJump = false;
        }

        if (Time.time > nextSpeedBoost && (Input.GetButtonDown("Fire3")))
        {
            nextSpeedBoost = Time.time + boostRate;
            moveSpeed = 8f;
            StartCoroutine(SpeedBoostEnd());
        }

        if (moveSpeed >= 8f)
        {
            Instantiate(trailEffect, transform.position, transform.rotation);
        }

        void DoJump()
        {
            // reset current vertical motion to 0 prior to jump
            //_vy = 0f;
            // add a force in the up direction
            _rigidbody.AddForce(new Vector3(0, jumpForce));
            canJump = false;
            // play the jump sound
            // PlaySound(jumpSFX);
        }

        // Determine how much should move in the z-direction
        Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;

        // Determine how much should move in the x-direction
        Vector3 movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;
         
        // Convert combined Vector3 from local space to world space based on the position of the current gameobject (player)
        Vector3 movement = transform.TransformDirection(movementZ + movementX);

        // Apply gravity (so the object will fall if not grounded)
        movement.y -= gravity * Time.deltaTime;

        // Debug.Log ("Movement Vector = " + movement);

        // Actually move the character controller in the movement direction
        myController.Move(movement);
    }

    IEnumerator SpeedBoostEnd()
    {
        yield return new WaitForSeconds(3f);

        moveSpeed = 3f;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EBullet")
        {

        }
    }
}
