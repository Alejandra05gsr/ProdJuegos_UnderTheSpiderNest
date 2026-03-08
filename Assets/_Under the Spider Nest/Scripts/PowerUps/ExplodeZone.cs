using UnityEngine;

public class ExplodeZone : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //activar el mesh renderer del explosion zone para mostrar la zona de explosion
            this.GetComponent<MeshRenderer>().enabled = true;
            other.gameObject.GetComponent<EnemyHP>().Dying();
            Debug.Log("ExplodeZone hit an enemy!");
        }

        //destruir la zona de explosion después de
        Destroy(gameObject, 0.5f);
    }

}
