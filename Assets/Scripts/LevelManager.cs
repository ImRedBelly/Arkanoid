using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int blockCount;
    void Start()
    {
        //Block[] allBlock = FindObjectsOfType<Block>();
        //blockCount = allBlock.Length;
    }
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
