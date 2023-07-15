using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class StartScreenUIController : MonoBehaviour
{

[SerializeField] Button OptionsButton;
[SerializeField] Button OkButton;
[SerializeField] Button OkLeaderBoardButton;
[SerializeField] Button QuitButton;
[SerializeField] Button StartButton;   
[SerializeField] Button leaderBoardButton;
[SerializeField] Animator OptionsAnimator;
[SerializeField] Animator LeaderBoardAnimator;
bool OptionsOpen = false;
bool LeaderBoardOpen = false;

private void Start() 
{
    OptionsButton.onClick.AddListener(OptionsButtonBehaviour);
    leaderBoardButton.onClick.AddListener(LeaderBoardButtonBehaviour);
    OkButton.onClick.AddListener(CloseOptions);
    OkLeaderBoardButton.onClick.AddListener(CloseLeaderBoard);
    QuitButton.onClick.AddListener(QuitGame);
    StartButton.onClick.AddListener(StartGame);
}

void OptionsButtonBehaviour(){
    if(OptionsOpen)
    {
        CloseOptions();
    }
    else
    {
        if (LeaderBoardOpen)
        {
            CloseLeaderBoard();
            OpenOptions();
        }
        else
        {
            OpenOptions();
        }
    }
}

void LeaderBoardButtonBehaviour(){
    if(LeaderBoardOpen)
    {
        CloseLeaderBoard();
    }
    else
    {
        if (OptionsOpen)
        {
            CloseOptions();
            OpenLeaderBoard();
        }
        else
        {
            OpenLeaderBoard();
        }
    }
}

void OpenOptions()
{
    OptionsOpen = true;
    OptionsAnimator.SetBool("isOpen", true);
}

void OpenLeaderBoard()
{
    LeaderBoardOpen = true;
    LeaderBoardAnimator.SetBool("isOpen", true);
}
void CloseOptions()
{
    OptionsOpen = false;
    OptionsAnimator.SetBool("isOpen", false);
}

void CloseLeaderBoard()
{
    LeaderBoardOpen = false;
    LeaderBoardAnimator.SetBool("isOpen", false);
}
void QuitGame()
{
    Application.Quit();
}
void StartGame()
{
    SceneManager.LoadScene("Scene0");
}
}
