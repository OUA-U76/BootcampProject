using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI textT;
    public float timerValue=0;
    public Image dfc;
    public TextMeshProUGUI dfcText;
    [SerializeField] Image emoji;
    [SerializeField] Sprite[] emojies;
    [SerializeField] Image bg;
    
    public float enemyTimer;
    void Start()
    {
        slider.maxValue = 600;
        slider.value = 0;
        bg.color = Color.blue;
    }

    void Update()
    {
        float time =timerValue+Time.time;
        int minutes=Mathf.FloorToInt(time/60);
        int seconds=Mathf.FloorToInt(time-minutes*60);
        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        if (time <= 150)
        {
            dfcText.text = "Easy";
            dfcText.color = Color.green;
            dfc.color=Color.green;
            emoji.sprite = emojies[0];
            bg.color = Color.blue;
            enemyTimer = 7f;
        }
        else if (time <= 300 && time > 150)
        {
            dfcText.text = "Medium";
            dfcText.color = Color.yellow;
            dfc.color = Color.yellow;
            emoji.sprite = emojies[1];
            enemyTimer = 6f;
        }
        else if (time <= 450 && time > 300)
        {
            dfcText.text = "Hard";
            dfcText.color = Color.red;
            dfc.color = Color.red;
            emoji.sprite = emojies[2];
            enemyTimer = 5f;
        }
        else if (time <= 600 && time > 450)
        {
            dfcText.text = "Very Hard";
            dfcText.color = Color.red;
            dfc.color = Color.red;
            emoji.sprite = emojies[3];
            bg.color = Color.red;
            enemyTimer = 4f;
        }
        else if (time > 600)
        {
            dfcText.text = "I'm watching you";
            dfcText.color = Color.grey;
            dfc.color = Color.black;
            emoji.sprite = emojies[4];
            bg.color = Color.black;
            enemyTimer = 2f;
        }
        textT.text = textTime;
        slider.value = time;
        Debug.Log(time);
    }
}
