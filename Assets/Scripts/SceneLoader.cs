using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public LevelManager levelManager;
    public void ChoiseLevel(int index)
    {
        levelManager.currentLevel = index;
        SceneManager.LoadScene(1);
        //levelManager.Awake();
    }
    public void LoadLevel(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
