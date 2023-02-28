using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Animator weaponAnimator;


    void Start()
    {
        weaponAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerAttack()
    {
        weaponAnimator.SetTrigger("Attack");
        weaponAnimator.GetComponent<Collider2D>().enabled = true;
    }

    public void DisableCol()
    {
        weaponAnimator.GetComponent<Collider2D>().enabled = false;
    }

}
