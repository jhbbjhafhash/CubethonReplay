using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;

    public float sidewaysForce = 20f;
    public enum Direction
    {
        Left,
        Right
    }

    private InputHandler _inputHandler;
    private bool _isRecording;
    private bool _isReplaying;
    private bool _left;
    private bool _right;

    public void Turn(Direction direction)
    {
        if (direction == Direction.Left)
        {
            _left = true;
        }
        else
        {
            _left = false;
        }

        if (direction == Direction.Right)
        {
            _right = true;
        }
        else
        {
            _right = false;
        }
    }

    void FixedUpdate()
    {
        _isRecording = gameObject.GetComponent<InputHandler>()._isRecording;
        _isReplaying = gameObject.GetComponent<InputHandler>()._isReplaying;

        if (_left == true)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            Debug.Log("left");
        }
        else
        { 
            rb.angularVelocity = Vector3.zero;
        }

        if (_right == true)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            Debug.Log("right");
        }
        else
        { 
            rb.angularVelocity = Vector3.zero;
        }

        if (_isRecording == true || _isReplaying == true)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        rb.velocity = Vector3.zero;
    }
}
