using System.Collections;
using UnityEngine;

public abstract class PowerUps : MonoBehaviour
{
    public int timeActive = 5; 
    public GameObject prefabPowerUp;

    protected bool isActive = false; 

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
        Debug.Log("Power-up activated: " + gameObject.name);
        
        StartCoroutine(DurationPowerUp());
    }

    IEnumerator DurationPowerUp()
    {
        yield return new WaitForSeconds(timeActive);
        DeactivatePowerUp();
    }

    protected virtual void DeactivatePowerUp()
    {
        isActive = false;
        Debug.Log("Power-up deactivated: " + gameObject.name);

        prefabPowerUp.SetActive(false);

    }


}
