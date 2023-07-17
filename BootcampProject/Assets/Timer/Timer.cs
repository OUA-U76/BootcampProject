using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject boss;
    public GameObject warningPanel;


    //Materyal
    public Material[] material;
    private Renderer[] rend=new Renderer[5];

    public GameObject[] changMaterial;
    //

    public float secondTimeRemaining = 3;
    public GameObject areuSure;
    public bool areuSureBool;
    public GameObject losePanel;
    void Start()
    {
        losePanel.SetActive(false);
        areuSure.SetActive(false);
        warningPanel.SetActive(false);
        boss.SetActive(false);
        slider.maxValue = 600;
        slider.value = 0;
        bg.color = Color.blue;

        areuSureBool = false;

        enemyTimer = 1;
        //Materyal
        rend[0] = changMaterial[0].GetComponent<Renderer>();
        rend[1] = changMaterial[1].GetComponent<Renderer>();
        rend[2] = changMaterial[2].GetComponent<Renderer>();
        rend[3] = changMaterial[3].GetComponent<Renderer>();
        rend[4] = changMaterial[4].GetComponent<Renderer>();
        //

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
            dfc.color = Color.green;
            emoji.sprite = emojies[0];
            bg.color = Color.blue;
            enemyTimer = 60f;

            //
            rend[0].material = material[0];
            rend[1].material = material[0];
            rend[2].material = material[0];
            rend[3].material = material[0];
            rend[4].material = material[0];
        }
        else if (time <= 300 && time > 150)
        {
            dfcText.text = "Medium";
            dfcText.color = Color.yellow;
            dfc.color = Color.yellow;
            emoji.sprite = emojies[1];
            enemyTimer = 55f;

            //
            rend[0].material = material[0];
            rend[1].material = material[0];
            rend[2].material = material[0];
            rend[3].material = material[0];
            rend[4].material = material[0];
        }
        else if (time <= 450 && time > 300)
        {
            dfcText.text = "Hard";
            dfcText.color = Color.red;
            dfc.color = Color.red;
            emoji.sprite = emojies[2];
            enemyTimer = 50f;

            //
            rend[0].material = material[1];
            rend[1].material = material[1];
            rend[2].material = material[1];
            rend[3].material = material[1];
            rend[4].material = material[1];
        }
        else if (time <= 600 && time > 450)
        {
            dfcText.text = "Very Hard";
            dfcText.color = Color.red;
            dfc.color = Color.red;
            emoji.sprite = emojies[3];
            bg.color = Color.grey;
            enemyTimer = 45f;

            //
            rend[0].material = material[1];
            rend[1].material = material[1];
            rend[2].material = material[1];
            rend[3].material = material[1];
            rend[4].material = material[1];
        }
        else if (time > 600)
        {

            SceneManager.LoadScene(3);
        }

        textT.text = textTime;
        slider.value = time;
        
    }

}
