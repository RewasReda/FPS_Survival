using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponAim
{
    NONE,
    SELF_AIM,
    AIM
}
public enum WeaponFireType
{
    SINGLE,
    MULTIIPLE
}
public enum WeaponBulletType
{
    BULLET,
    ARROW,
    SPEAR,
    NONE
}

public class WeaponsHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public WeaponAim weapon_Aim;

    [SerializeField]
    private GameObject muzzleFalsh;

    [SerializeField]
    private AudioSource shootSound;
    [SerializeField]
    private AudioSource reload_Sound;

    public WeaponFireType fireType;
    public WeaponBulletType bulletType;
    public GameObject attact_Point;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ShootAnimation()
    {
        anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }
    public void Aim(bool canAim)
    {
        anim.SetBool(AnimationTags.AIM_PARAMETER, canAim);
    }
    void Turn_On_MuzzleFlash()
    {
        muzzleFalsh.SetActive(true);
    }
    void Turn_Off_MuzzleFlash()
    {
        muzzleFalsh.SetActive(false);
    }

    void Play_ShootSound()
    {
        shootSound.Play();
    }
    void Play_ReloadSound()
    {
        reload_Sound.Play();
    }


    void Turn_On_AttackPoint()
    {
        attact_Point.SetActive(true);
    }
    void Turn_Off_AttackPoint()
    {
        attact_Point.SetActive(false);
    }
}
