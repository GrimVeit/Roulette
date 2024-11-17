using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Joker : MonoBehaviour
{
    [SerializeField] private Image imageJoker;
    [SerializeField] private Sprite spriteFirstFrame;
    [SerializeField] private Sprite spriteSecondFrame;

    private IEnumerator switchSprite_Coroutine;

    public void ActivateAnimation(float duration, float speedChange)
    {
        if (switchSprite_Coroutine != null)
            Coroutines.Stop(switchSprite_Coroutine);

        switchSprite_Coroutine = SwitchSprite_Coroutine(duration, speedChange);
        Coroutines.Start(switchSprite_Coroutine);
    }

    private IEnumerator SwitchSprite_Coroutine(float duration, float speedChange)
    {
        float currentDuration = 0f;

        while (currentDuration < duration)
        {
            imageJoker.sprite = (imageJoker.sprite == spriteFirstFrame ? spriteSecondFrame : spriteFirstFrame);

            yield return new WaitForSeconds(speedChange);

            currentDuration += speedChange;
        }

        imageJoker.sprite = spriteFirstFrame;
    }
}
