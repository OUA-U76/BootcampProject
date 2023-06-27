using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
[Header ("SERIALIZED FIELDS")]
[SerializeField] Button PauseButton;
[SerializeField] Button ResumeButton;
[SerializeField] GameObject PausePanel;

bool isPaused = false;

private void Start() 
{
    PauseButton.onClick.AddListener(PauseGame);
    ResumeButton.onClick.AddListener(ResumeGame);
}
private void Update() 
{
    if(Input.GetKeyDown(KeyCode.Escape))
    {
        if(isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
}

public void PauseGame()
{
    isPaused = true;
    Time.timeScale = 0;
    PausePanel.SetActive(true);
    PauseButton.gameObject.SetActive(false);
}
public void ResumeGame()
{
    isPaused = false;
    Time.timeScale = 1;
    PausePanel.SetActive(false);
    PauseButton.gameObject.SetActive(true);
}
}
