using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // public varaibles
    public float moveSpeed = 3.0f;
    public float gravity = 9.81f;
    public float boostRate = 25f;
    public float nextSpeedBoost;

    // Velocity y
    float _vy;
    public float jumpForce = 20;

    public GameObject trailEffect;
    private CharacterController myController;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    Transform _transform;
    Rigidbody _rigidbody;
    public bool isGrounded = false;
    public bool canJump = false;
    int _playerLayer;

    //SFX
    AudioSource _audio;
    public AudioClip jumpSFX;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        myController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /**if(Input.GetButtonDown(""))
        {

        }*/

        isGrounded = Physics.Linecast(_transform.position, groundCheck.position, whatIsGround);
        if(isGrounded)
        {
            canJump = true;
        }

        _vy = _rigidbody.velocity.y;

        if(Input.GetButtonDown("Jump") && _vy == 0f && canJump)
        {
            DoJump();
        }

        if(Time.time > nextSpeedBoost && (Input.GetButtonDown("SpeedBoost")))
        {
            nextSpeedBoost = Time.time + boostRate;
            moveSpeed = 7f;
            StartCoroutine(SpeedBoostEnd());
        }
        if(moveSpeed >=7f)
        {
            Instantiate(trailEffect, transform.position, transform.rotation);
        }

        // Determine how much should move in the z-direction
        Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;

        // Determine how much should move in the x-direction
        Vector3 movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;

        // Convert combined Vector3 from local space to world space based on the position of the current gamobject (player)
        Vector3 movement = transform.TransformDirection(movementZ + movementX);

        // Apply gravity (so the object will fall if not grounded))
        movementZ.y -= gravity * Time.deltaTime;

        // Actually move the character controller in the movement direction
        myController.Move(movement);
    }

    IEnumerator SpeedBoostEnd()
    {
        yield return new WaitForSeconds(3f);
        moveSpeed = 3f;
    }

    // make the player jump
    void DoJump()
    {
        // reset current vertical motion to 0 prior to jump
        _vy = 0f;
        // add a force in the up direction
        _rigidbody.AddForce(new Vector2(0, jumpForce));
        // play the jump sound
        PlaySound(jumpSFX);
    }

    void PlaySound(AudioClip clip)
    {
        _audio.PlayOneShot(clip);
    }
}
