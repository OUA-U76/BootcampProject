using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenUIController : MonoBehaviour
{

[SerializeField] Button OptionsButton;
[SerializeField] Button OkButton;
[SerializeField] Button QuitButton;
[SerializeField] Button StartButton;   
[SerializeField] Animator OptionsAnimator;
bool OptionsOpen = false;

private void Start() 
{
    OptionsButton.onClick.AddListener(OptionsButtonBehaviour);
    OkButton.onClick.AddListener(CloseOptions);
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
        OpenOptions();
    }
}

void OpenOptions()
{
    OptionsOpen = true;
    OptionsAnimator.SetBool("isOpen", true);
}
void CloseOptions()
{
    OptionsOpen = false;
    OptionsAnimator.SetBool("isOpen", false);
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
