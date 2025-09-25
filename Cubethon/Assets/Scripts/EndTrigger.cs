using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public InputHandler _inputHandler;

   void OnTriggerEnter ()
   {
      _inputHandler.StopRecord();
      _inputHandler.Replay();
   }
}
