using UnityEngine;

public class PickUpPowerUp : MonoBehaviour
{
    public PowerUps powerUp; // arrastras el del Player
    public MachineGun machineGun;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        powerUp.gameObject.SetActive(true);
        machineGun.gameObject.SetActive(false);

        powerUp.ActivatePowerUp();

        Destroy(gameObject);
    }
}


