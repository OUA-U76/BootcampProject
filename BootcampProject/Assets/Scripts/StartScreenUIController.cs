using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenUIController : MonoBehaviour
{

[SerializeField] Button OptionsButton;
[SerializeField] Button OkButton;
[SerializeField] Animator OptionsAnimator;
bool OptionsOpen = false;

private void Start() 
{
    OptionsButton.onClick.AddListener(OptionsButtonBehaviour);
    OkButton.onClick.AddListener(CloseOptions);
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
}
