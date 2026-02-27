using System.Collections;
using UnityEngine;

public abstract class PowerUps : MonoBehaviour
{
    public int timeActive = 5; 
    public GameObject prefabPowerUp;

    public GameObject imagePowerUp;

    protected bool isActive = false; 
    protected bool machineGunActive = true;

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
        imagePowerUp.SetActive(false);

        GameObject mg = GameObject.FindGameObjectWithTag("MachineGun");
        if (mg != null)
            mg.SetActive(true);
    }


}
