using UnityEngine;

public class PickUpPowerUp : MonoBehaviour
{
    public PowerUps powerUp; 
    public MachineGun machineGun;
    public GameObject metralleta_img;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        powerUp.gameObject.SetActive(true);
        machineGun.gameObject.SetActive(false);
        metralleta_img.SetActive(false);

        powerUp.ActivatePowerUp();

        Destroy(gameObject);
    }
}


