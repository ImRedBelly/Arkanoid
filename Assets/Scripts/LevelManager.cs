using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<Transform> levels;
    Transform lastLevel;

    public int currentLevel;

    public int blockCount;

    public void Awake()
    {
        CreateLevel(currentLevel);
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
            
            Destroy(lastLevel.gameObject); //уничтожает прошлый уровень
            CreateLevel(currentLevel);
        }
    }
    public void CreateLevel(int index)
    {
        if(currentLevel < levels.Count)
        {
            currentLevel = index;
            lastLevel = Instantiate(levels[currentLevel]);
            currentLevel++;
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
