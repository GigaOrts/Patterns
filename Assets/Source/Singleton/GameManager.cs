using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private void OnGUI()
    {
        if(GUILayout.Button("Next Scene"))
        {
            int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextIndex);
        }
    }
}
