using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Tower Defense/TowerData")]
public class TowerData : ScriptableObject
{
    public string towerName;
    public int energyCost;
    public int damage;
    public int attackRangeInTiles;
    public Sprite icon;
    public GameObject towerPrefab;

    // public int entropyLevel;  // Entropy defines tower's effectiveness/efficiency. Offensive enemy units can attack towers to raise their entropy.
    //     High entropy means the tower will be weaker, and if a tower reaches maximum entropy, it will be vulnerable to taking damage directly.
    //     Towers regenerate health on their own based on their entropy level at the end of the wave. Low entropy means towers will regenerate a lot of damage quickly. High entropy means towers will regenerate a lot more slowly throughout the wave. Entropy resets at the start of each wave, and only affects the tower for the next immediate wave.

    // public int maxEntropy;  // Maximum entropy a tower can have. Reaching maximum entropy will have some negative effect (disabling, significantly reducing damage, etc.)

    // public string resistanceTypes;  // Some towers may be resistant to certain types of damage.

    // public int currentAmmo;  // Some towers may use finite ammo. These towers do not decay, just need to be reloaded. Aimable to any square in the grid in range, and usually has some kind of special ammo. 

    // public int specialAbility;  // Some towers may have activatable special abilities with cooldowns.

    // public string passiveAbilities;  // Some towers may have passive abilities.

    // public string damageType;  // Some towers may have different damage types that will affect enemies differently.

    // public string attackPattern;  // Towers will have different 3x3 grid attack patterns from a set of a handful of predefined patterns, based on enemy formations/types/)

    // public int xp; // how much xp does the tower have and what upgrades can it get

    // public string upgradePath;     // Tower upgrade path

    // public string ordenance;  // Temporary boosts for the wave (double XP, more loot, higher crit. strike, small buffs)

    // public string armaments;  // Gear you may have gained from the roguelike mechanics after beating a wave, which can be used to give the tower some unique upgrades/interactions (grid pattern upgrade, damage type change, combos, status effects, etc)

    // public bool multipleUnits;  // some towers may be made up of multiple smaller tower units; these units have their own unique stats, and grid layout. 

    // public string towerRole;  // Some towers may have different roles (tank, support, dps, cc, healer, unit summoner, economy/farming, etc). Certain roles have different interactions when in proximity. 

    // public string canTarget;  // Some towers may be able to target certain types of units (air units, ground units, stealth units, etc).

    // public bool elevationAdvantage;   // Towers with an elevation advantage will have more range.

    // public string skin;  // towers may have different skins.


    


}
