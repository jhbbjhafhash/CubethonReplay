using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Invoker : MonoBehaviour
{
    private bool _isReplaying;
    private bool _isRecording = false;
    
    private float _recordingTime;
    private float _replayTime;

    private SortedList<float, Command> _recordedCommands =
        new SortedList<float, Command>();

    public Invoker()
    {

    }

    public void addCommand(Command command)
    {
        _recordedCommands.Add(_recordingTime, command); 
    }

    public void invoke(Command command)
    {
        command.execute();
    }

    public void Replay()
    {
        _replayTime = 0.0f;
        _isReplaying = true;
        
        if (_recordedCommands.Count <= 0)
            Debug.LogError("No commands to replay!");
    }

    public void setRecording(bool status)
    {
        _isRecording = status;

        Debug.Log("Recordign status: " + status);
    }


    void FixedUpdate()
    {
        if (_isRecording)
        {
            _recordingTime += Time.fixedDeltaTime;
            Debug.Log(_recordingTime);
        }

        if (_isReplaying)
        {

            _replayTime += Time.fixedDeltaTime;

            if (_recordedCommands.Any())
            {
                if (Mathf.Approximately(_replayTime, _recordedCommands.Keys[0]))
                {

                    Debug.Log("Replay Time: " + _replayTime);
                    Debug.Log("Replay Command: " + _recordedCommands.Values[0]);

                    _recordedCommands.Values[0].execute();

                    _recordedCommands.RemoveAt(0);
                }
            }
            else
            {
                _isReplaying = false;
            }
        }
    }
}