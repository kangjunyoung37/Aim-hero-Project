public enum WeaponName { HandGun = 0 }
[System.Serializable]
public struct WeaponSetting
{
    public WeaponName weaponname;
    public int currentAmmo;
    public int maxAmmo;
    public float attackRate;
    public float attackDistance;
    public bool isAutomaticAttack;
}