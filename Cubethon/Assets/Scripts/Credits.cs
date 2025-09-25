using UnityEngine.SceneManagement;
using UnityEngine;

public class Credits : MonoBehaviour
{
   public void Restart()
   {
        SceneManager.LoadScene(0);
        Debug.Log("RestartButtonPressed");
   }

}
