using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text bestScoretext;
    
    void Start()
    {
        int besScore = PlayerPrefs.GetInt(GameManager.keyBestScore);  // TODO загружать
        bestScoretext.text = "BEST RECORD " + besScore;
    }
}
