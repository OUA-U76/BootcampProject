using JetBrains.Annotations;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    int x = 0;
    public void Skip()
    {
        SceneManager.LoadScene(2);
    }
    private void Update()
    {
        if (x == 0)
        {
            text.text = "Her �ey o g�n ba�lad�. O zamana kadar robotlarla uyum i�inde ya�ard�k ama afetlerden sonra her �ey de�i�ti metal �ehirde ya�ayanlar i�lerinden uzakla�t�r�ld�...izole edildi...ve bir g�n geride kimse kalmad�. Herkesi merkeze g�t�rd�ler... Art�k hayat�m� geri istiyorum";
        }
        else if (x == 1)
        {
            text.text= "Hay�r yapma!! Daha k�t� bir hal almas�na sebep olucaks�n";
        }
        else if (x == 2)
        {
            text.text= "Kimse art�k beni durduramaz. �ntikam zaman�!!"; 
        } 
        else if(x == 3)
        {
            text.text= "Hay�rrr DURR !!!";
        }
        else if (x == 4)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void hehe()
    {
        x++;
    }

    
}
