using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject[] images;

    private void Start()
    {
        for(int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        for(int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        for(int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }
    }
}