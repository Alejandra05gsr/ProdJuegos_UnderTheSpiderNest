using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialFade : MonoBehaviour
{
    public float fadeDuration = 2f;
    private Material[] materials;

    void Start()
    {
        // 1️ Buscar TODOS los Renderers en hijos
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        // 2️ Guardar todos los materiales en una lista
        List<Material> mats = new List<Material>();
        Debug.Log("Renderers encontrados: " + renderers.Length);

        foreach (Renderer r in renderers)
        {
            mats.AddRange(r.materials); // importante usar .materials
        }

        materials = mats.ToArray();
    }

    public void StartFade()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Debug.Log("Empezando fade");
        float time = 0f;

        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, time / fadeDuration);

            foreach (Material m in materials)
            {
                Color c = m.color;
                m.color = new Color(c.r, c.g, c.b, alpha);
            }

            time += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false); // opcional
    }
}
