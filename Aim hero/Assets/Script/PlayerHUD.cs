using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHUD : MonoBehaviour
{
    [Header("Component")]
    [SerializeField]
    private WeaponHandGun weapon;
    [Header("Weapon Base")]
    [SerializeField]
    private TextMeshProUGUI textWeaponName;
    [SerializeField]
    private Image imageWeaponIcon;
    [SerializeField]
    private Sprite[] spriteWeaponIcon;

    [Header("Ammo")]
    [SerializeField]
    private TextMeshProUGUI textAmmo;

    private void Awake()
    {
        SetupWeapon();
        weapon.onAmmoEvent.AddListener(UpdateAmmoHUB);
    }
    private void SetupWeapon()
    {
        textWeaponName.text = weapon.WeaponName.ToString();
        imageWeaponIcon.sprite = spriteWeaponIcon[(int)weapon.WeaponName];
    }
    private void UpdateAmmoHUB(int currentAmmo, int maxAmmo)
    {
        textAmmo.text = $"<size=40>{currentAmmo}/</size>{maxAmmo}";
    }

}
