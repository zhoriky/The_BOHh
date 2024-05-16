using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] FirstPersonMovement _controller;
    public float speed = 5;
    [SerializeField] AudioSource _audioSourcewalk;
    [SerializeField] AudioSource _audioSourcerun;
    [Header("Running")]
    public bool canRun = true;
    public float player;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    bool run;
    bool walk;
    
    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();


    
    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
        AudioListener.volume = 1f;
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }
      

        // Get targetVelocity from input.
            Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }
    private void Update()
    {
        
        
        



       

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.LeftShift))

        {
            if (walk == false)
            {
                walk = true;
                _audioSourcewalk.Play();

            }

        }
        else if (walk)
        {
            walk = false;
            _audioSourcewalk.Stop();

        }



        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift))
        {
            if (run == false)
            {
                run = true;
                _audioSourcerun.Play();
                
                
            }

        }
        else if (run != false)
        {
            run = false;
            _audioSourcerun.Stop();
        }
    }
}