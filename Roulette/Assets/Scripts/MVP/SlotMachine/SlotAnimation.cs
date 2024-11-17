using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotAnimation : MonoBehaviour
{
    [SerializeField] private Image imageSlot;
    [SerializeField] private Sprite spriteFirst;
    [SerializeField] private Sprite spriteSecond;

    [SerializeField] private float speedChange;

    private void Awake()
    {
        StartCoroutine(SwitchSprite_Coroutine());
    }

    private IEnumerator SwitchSprite_Coroutine()
    {
        while (true)
        {
            imageSlot.sprite = (imageSlot.sprite == spriteFirst ? spriteSecond : spriteFirst);

            yield return new WaitForSeconds(speedChange);
        }
    }
}
