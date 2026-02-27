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

    void CheckWeapon()
    {
        if (!bazookaPrefab.activeInHierarchy && !firetPrefab.activeInHierarchy)
        {
            metralletaPrefab.SetActive(true);
            metralleta_img.SetActive(true);
        }
    }

}
