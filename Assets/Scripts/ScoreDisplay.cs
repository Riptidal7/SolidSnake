using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI RoundScoreText;
    public TextMeshProUGUI HighScoreText;
    public ScoreKeeper scoreKeeper;
    
    
    public void UpdateScoreResultsText()
    {
        RoundScoreText.text = ($"Score This Round: {scoreKeeper.score:D3}");
        HighScoreText.text = ($"High Score: {PlayerPrefs.GetInt("HighScore"):D3}");
        scoreKeeper.score = 0;
        scoreKeeper.UpdateScoreText();
    }
}
