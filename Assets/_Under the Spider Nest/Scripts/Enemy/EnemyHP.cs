using DG.Tweening;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public const int TRANSPARENT_LAYER = 1;
    public const float VANISH_TIME = 1;

    //public Material material;
    public Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dying()
    {
        animator.SetBool("Die", true);
        this.gameObject.GetComponent<EnemyMovement>().DesactiveEnemy();
        Invoke(nameof(Desvanecer), 2f);
    }

    void Desvanecer()
    {
        //material.DOFade(0, VANISH_TIME).SetDelay(VANISH_TIME);
        gameObject.SetActive(false);
        GameManager.instance.EnemyDefeated();
    }


}
