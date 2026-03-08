using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialFade : MonoBehaviour
{
    public float fadeDuration = 1.5f;

    Renderer[] renderers;

    void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    public void StartFade()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float time = 0;

        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, time / fadeDuration);

            foreach (Renderer r in renderers)
            {
                foreach (Material m in r.materials)
                {
                    Color c = m.color;
                    m.color = new Color(c.r, c.g, c.b, alpha);
                }
            }

            time += Time.deltaTime;
            yield return null;
        }

        foreach (Renderer r in renderers)
        {
            foreach (Material m in r.materials)
            {
                Color c = m.color;
                m.color = new Color(c.r, c.g, c.b, 0f);
            }
        }
    }
}
