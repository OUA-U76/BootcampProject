using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NEWTIMER : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI textT;
    public float timerValue = 3600;
    public Image dfc;
    public TextMeshProUGUI dfcText;
    [SerializeField] Image bg;
    public GameObject warningPanel;
    public float secondTimeRemaining = 3;
    public GameObject boss;

    private void Start()
    {
        boss.SetActive(false);
    }
    private void Update()
    {
        float time = timerValue + Time.time;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        dfcText.text = "I'm watching you";
        dfcText.color = Color.grey;
        dfc.color = Color.black;
        bg.color = Color.black;


        if (warningPanel != null)
        {
            warningPanel.SetActive(true);
            
            if (secondTimeRemaining > 0)
            {
                secondTimeRemaining -= Time.deltaTime;
            }
            else
            {
                Destroy(warningPanel);
                boss.SetActive(true);
            }
        }
        if (boss == null)
        {
            SceneManager.LoadScene(5);
        }

        textT.text = textTime;
        slider.value = time;

    }


}
