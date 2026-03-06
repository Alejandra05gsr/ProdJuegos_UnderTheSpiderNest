using System.Collections;
using TMPro;
using UnityEngine;

public abstract class PowerUps : MonoBehaviour
{
    public int timeActive = 5; 
    public GameObject prefabPowerUp;

    public GameObject imagePowerUp;
    public TextMeshProUGUI countText;

    protected bool isActive = false; 
    protected bool machineGunActive = true;

    public bool needsTimer;

    void Start()
    {
        
    }


    void Update()
    {
        
    }


    public virtual void ActivatePowerUp()
    {
        if (isActive) return; 
        isActive = true;

        imagePowerUp.SetActive(true);

        PowerUpTimer();
    }

    public virtual void PowerUpTimer()
    {
        if (needsTimer)
        {
            StartCoroutine(DurationPowerUp());
        }
    }

    IEnumerator DurationPowerUp()
    {
        int timeLeft = timeActive;

        while (timeLeft > 0)
        {
            if (countText != null)
                countText.text = timeLeft + "s";

            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        if (countText != null)
            countText.text = "0";

        DeactivatePowerUp();
    }

    protected virtual void DeactivatePowerUp()
    {
        isActive = false;
        Debug.Log("Power-up deactivated: " + gameObject.name);

        prefabPowerUp.SetActive(false);
        imagePowerUp.SetActive(false);
    }


}
