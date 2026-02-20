using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public MachineGun machineGun;
    public Weapons flamethrower;
    public Weapons bazooka;

    Weapons currentWeapon;

  
    void Start()
    {
        ActivateMachineGun();
    }

    public void ActivateMachineGun()
    {
        currentWeapon = machineGun;

        flamethrower.gameObject.SetActive(false);
        bazooka.gameObject.SetActive(false);
    }

    public void ActivateOtherWeapon(Weapons weapon)
    {
        currentWeapon = weapon;

        weapon.gameObject.SetActive(true);
    }

    public bool IsMachineGunActive()
    {
        return currentWeapon == machineGun;
    }
}
