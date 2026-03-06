using UnityEngine;

public class DefaultWeapon : MonoBehaviour
{
    public GameObject bazookaPrefab;
    public GameObject firetPrefab;
    public GameObject metralletaPrefab;
    public GameObject metralleta_img;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckWeapon();
    }

    void CheckWeapon() //Se activa la metralleta si no hay ni bazooka ni fuego
    {
        if (!bazookaPrefab.activeInHierarchy && !firetPrefab.activeInHierarchy)
        {
            ActivateDefaultWeapon();
        }
    }

    public void DesactivateDefaultWeapon() //Desactivo metralleta
    {
        metralletaPrefab.SetActive(false);
        metralleta_img.SetActive(false);
    }

    public void ActivateDefaultWeapon() //Desactivo metralleta
    {
        metralletaPrefab.SetActive(true);
        metralleta_img.SetActive(true);
    }

    public void LlamarReload()
    {
        bazookaPrefab.GetComponent<Bazooka>().Reload();
    }

}
