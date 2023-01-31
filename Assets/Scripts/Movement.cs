using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float rocketRotSpeed = 100.0f;
    [SerializeField] float rocketThrustSpeed = 1500.0f;
    [SerializeField] AudioClip engineThruster;
    Rigidbody body;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       body = GetComponent<Rigidbody>(); 
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() 
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(engineThruster);
            }
            body.AddRelativeForce(Vector3.up * rocketThrustSpeed * Time.deltaTime);
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rocketRotSpeed);
        }
        else if(Input.GetKey(KeyCode.A))
        {
           ApplyRotation(rocketRotSpeed); 
        }
    }

    void ApplyRotation(float rotation)
    {
        body.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        body.freezeRotation = false;
    }
}
