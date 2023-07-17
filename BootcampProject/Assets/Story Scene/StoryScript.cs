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
            text.text = "Her þey o gün baþladý. O zamana kadar robotlarla uyum içinde yaþardýk ama afetlerden sonra her þey deðiþti metal þehirde yaþayanlar iþlerinden uzaklaþtýrýldý...izole edildi...ve bir gün geride kimse kalmadý. Herkesi merkeze götürdüler... Artýk hayatýmý geri istiyorum";
        }
        else if (x == 1)
        {
            text.text= "Hayýr yapma!! Daha kötü bir hal almasýna sebep olucaksýn";
        }
        else if (x == 2)
        {
            text.text= "Kimse artýk beni durduramaz. Ýntikam zamaný!!"; 
        } 
        else if(x == 3)
        {
            text.text= "Hayýrrr DURR !!!";
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
