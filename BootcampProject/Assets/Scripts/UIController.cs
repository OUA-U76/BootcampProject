using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
[FormerlySerializedAs("ResumeButton")]
[Header ("SERIALIZED FIELDS")]
[SerializeField] private Button resumeButton;
[SerializeField] private GameObject pausePanel;

private bool _isPaused = false;

private void Start() 
{
    resumeButton.onClick.AddListener(ResumeGame);
}
private void Update() 
{
    if(Input.GetKeyDown(KeyCode.Escape))
    {
        if(_isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
}

private void PauseGame()
{
    _isPaused = true;
    Time.timeScale = 0;
    pausePanel.SetActive(true);
}
public void ResumeGame()
{
    _isPaused = false;
    Time.timeScale = 1;
    pausePanel.SetActive(false);
}
}
