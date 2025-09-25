using UnityEngine;
using System.Linq;
using System.Collections.Generic;


public class InputHandler : MonoBehaviour
{
    public bool _isReplaying;
    public bool _isRecording;

    private float _recordingTime;
    private float _replayTime;
    private PlayerMovement _playerMovement;

    private Invoker _invoker;

    private Command _turnLeft;
    private Command _turnRight;

    void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _invoker = gameObject.AddComponent<Invoker>();

        _turnLeft = new TurnLeft(_playerMovement);
        _turnRight = new TurnRight(_playerMovement);
    }

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.A))
        {
            _invoker.invoke(_turnLeft);
            if (_isRecording)
            {
                _invoker.addCommand(_turnLeft);
            }

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _invoker.invoke(_turnRight);
            if (_isRecording)
            {
                _invoker.addCommand(_turnRight);
            }

        }

    }

        void OnGUI()
    {
        if (GUILayout.Button("Start Recording"))
        {
            StartRecord();
        }

        if (GUILayout.Button("Stop Recording"))
        {
            StopRecord();
        }

        if (!_isRecording)
        {
            if (GUILayout.Button("Replay"))
            {
                Replay();
            }
        }
    }


    public void StartRecord()
    {
        _invoker.setRecording(true);
        _isRecording = true;
        Debug.Log("Recording now");
    }

    public void StopRecord()
    {
        Debug.Log("Stopped recording");
        _isRecording = false;
        _invoker.setRecording(false);
    }

    public void Replay()
    {
        _playerMovement.ResetPosition();
        _isRecording = false;
        _isReplaying = true;
        _invoker.Replay();
    }
}
