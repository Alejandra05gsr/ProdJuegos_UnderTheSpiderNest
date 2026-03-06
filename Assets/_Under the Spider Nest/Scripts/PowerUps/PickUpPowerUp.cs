using UnityEngine;

public class PickUpPowerUp : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject defaultWeapon;
    public bool isBazooka, isFT, isShield;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        powerUp.gameObject.SetActive(true);
        powerUp.GetComponent<PowerUps>().ActivatePowerUp();

        if (isBazooka)
        {
            defaultWeapon.GetComponent<DefaultWeapon>().LlamarReload();
        }
        //else if (isFT)
        //{

        //}
        //else if (isFT)
        //{

        //}

        defaultWeapon.GetComponent<DefaultWeapon>().DesactivateDefaultWeapon();

        Destroy(gameObject);
    }


}


