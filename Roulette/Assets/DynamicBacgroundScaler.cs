using UnityEngine;

public class DynamicBacgroundScaler : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;

    private int isPortrait = -1;

    private void Update()
    {
        UpdateBackgroundSize();

        //Debug.Log(Screen.width + "//" + Screen.height);
    }

    private void UpdateBackgroundSize()
    {
        int currentIsPortrait = Screen.height >= Screen.width ? 1 : 0;

        if(currentIsPortrait != isPortrait)
        {
            isPortrait = currentIsPortrait;
            Change();
        }
    }

    private void Change()
    {
        if (isPortrait == 1)
        {
            rectTransform.offsetMin = new Vector2(-700, rectTransform.offsetMin.y);
            rectTransform.offsetMax = new Vector2(700, rectTransform.offsetMax.y);
        }
        else if(isPortrait == 0)
        {
            rectTransform.offsetMin = new Vector2(0, rectTransform.offsetMin.y);
            rectTransform.offsetMax = new Vector2(0, rectTransform.offsetMax.y);
        }
    }
}
