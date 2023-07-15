using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_InputField nameInput;
    private string _name;
    [SerializeField] private Button _okButton;
    public int score;
    

    private void Start()
    {
        _okButton.onClick.AddListener(SetName);
    }
    
    void SetName()
    {
        _name = nameInput.text;
        PlayerPrefs.SetString("Name", _name);
        Debug.Log("Name set to: " + _name);
        SceneManager.LoadScene("model");
    }

    void SetScore(int newScore)
    {
        score = newScore;
    }
    void CheckHighScore()
    {
        scoreText.text = "Score: " + score;
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            SendScore(score);
            Debug.Log("New High Score!");
            
        }
        else
        {
            SendScore(PlayerPrefs.GetInt("HighScore"));
            Debug.Log("Not a new high score");
        }
    }
    void SendScore(int highScore)
    {
        HighScores.UploadScore(PlayerPrefs.GetString("Name"), highScore);
        Debug.Log("Score sent to leaderboard");
    }
}
