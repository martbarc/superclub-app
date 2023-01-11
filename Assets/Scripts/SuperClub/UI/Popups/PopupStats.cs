using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UltimateClean;

public class PopupStats : MonoBehaviour
{
    [SerializeField] Team team;

    public Image progressBar;
    public TextMeshProUGUI text;

    public float duration = 1;

    private void Awake()
    {
        if (duration > 0)
        {
            StartCoroutine(Animate());
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private IEnumerator Animate()
    {
        while (true)
        {
            var time = 0.0f;
            while (progressBar.fillAmount < 1.0f)
            {
                time += Time.deltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.0f, 1.0f, time / duration);
                yield return null;
            }

            time = 0.0f;
            while (progressBar.fillAmount > 0.0f)
            {
                time += Time.deltaTime;
                progressBar.fillAmount = Mathf.InverseLerp(1.0f, 0.0f, time / duration);
                yield return null;
            }
        }
    }

}
