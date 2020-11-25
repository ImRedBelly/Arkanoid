using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevel(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
