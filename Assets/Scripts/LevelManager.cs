using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int blockCount;

    public void BlockCreated()
    {
        blockCount++;
    }
    public void BlockDestroyed()
    {
        blockCount--;
        if (blockCount <= 0)
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 1);
        }
    }
}
