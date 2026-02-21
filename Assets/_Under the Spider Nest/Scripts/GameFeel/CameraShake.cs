using Unity.Mathematics;
using UnityEngine;
using Unity.Cinemachine;
using System.Collections;
using System.Collections.Generic;

public class CameraShake : MonoBehaviour
{
    public CinemachineBasicMultiChannelPerlin noise;
    private float defaultAmplitude = 5;
    private float defaultFrequency = 2;
    private float defaultDuration = 0.3f;
    private Coroutine shakeRoutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StopShake();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShakeCamera(defaultAmplitude, defaultFrequency, defaultDuration);
        }
    }

    public void ShakeCamera(float shootAmplitude, float shootFrequency, float shootDuration)
    {
        if (noise == null)
        {
            Debug.LogWarning("CinemachineBasicMultiChannelPerlin component is not assigned.");
            return;
        }

        if (shakeRoutine != null)
        {
            StopCoroutine(shakeRoutine);
        }
        shakeRoutine = StartCoroutine(ShakeRoutine(shootAmplitude, shootFrequency, shootDuration));

    }

    private void StopShake()
    {
        if (noise == null)
        {
            return;
        }

        noise.AmplitudeGain = 0;
        noise.FrequencyGain = 0;
    }

    IEnumerator ShakeRoutine(float amplitude, float frequency, float duration)
    {
        noise.AmplitudeGain = amplitude;
        noise.FrequencyGain = frequency;
        yield return new WaitForSeconds(duration);
        StopShake();
    }

}
