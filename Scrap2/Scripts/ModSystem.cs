using UnityEngine;
using System.Collections.Generic;

public class ModSystem : MonoBehaviour
{
    // VARIABLES.
    public int fireRate, reloadSpeed, magSize, recoilRate, spread; // Gun Variables
    public Transform slot1, slot2, slot3, slot4, slot5;
    public int activeMods;

    public Mods mod1, mod2, mod3, mod4, mod5;

    public NegativeBoons negativeBoons;

    public List<GameObject> totalModsList;
    public List<GameObject> activeModsList;

    // FUNCTIONS.
    public void Update()
    {
        activeMods = activeModsList.Count;
        if(Input.GetKeyDown(KeyCode.Space) && negativeBoons.boonStart == true)    //test
        {
            GameObject modd = totalModsList[Random.Range(0, 5)];
            ModCheck(modd.GetComponent<Mods>());
        }
    }

    public void ModCheck(Mods mod)    // Check if mod is installed & installs/removes mods.
    {
        GameObject activeMod1, activeMod2, activeMod3, activeMod4, activeMod5;
        switch (mod.modType)
        {
            case 1: if (mod1 == null) { InstallMod(mod); mod1 = mod; activeMod1 = Instantiate(mod1.gameObject, slot1); } else { RemoveMod(mod1); Destroy(activeMod1); InstallMod(mod); mod1 = mod; activeMod1 = Instantiate(mod1.gameObject, slot1); } break;
            case 2: if (mod2 == null) { InstallMod(mod); mod2 = mod; activeMod2 = Instantiate(mod2.gameObject, slot2); } else { RemoveMod(mod2); Destroy(activeMod2); InstallMod(mod); mod2 = mod; activeMod2 = Instantiate(mod2.gameObject, slot2); } break;
            case 3: if (mod3 == null) { InstallMod(mod); mod3 = mod; activeMod3 = Instantiate(mod3.gameObject, slot3); } else { RemoveMod(mod3); Destroy(activeMod3); InstallMod(mod); mod3 = mod; activeMod3 = Instantiate(mod3.gameObject, slot3); } break;
            case 4: if (mod4 == null) { InstallMod(mod); mod4 = mod; activeMod4 = Instantiate(mod4.gameObject, slot4); } else { RemoveMod(mod4); Destroy(activeMod4); InstallMod(mod); mod4 = mod; activeMod4 = Instantiate(mod4.gameObject, slot4); } break;
            case 5: if (mod5 == null) { InstallMod(mod); mod5 = mod; activeMod5 = Instantiate(mod5.gameObject, slot5); } else { RemoveMod(mod5); Destroy(activeMod5); InstallMod(mod); mod5 = mod; activeMod5 = Instantiate(mod5.gameObject, slot5); } break;
        }
    }

    public void InstallMod(Mods mod)    // Install stats set by mod.
    {
        activeModsList.Add(mod.gameObject);
        fireRate += mod.newFireRate;
        reloadSpeed += mod.newReloadSpeed;
        magSize += mod.newMagSize;
        recoilRate += mod.newRecoilRate;
        spread += mod.newSpread;
        ValClamp();
    }

    public void RemoveMod(Mods mod)    // Remove stats set by mod.
    {
        activeModsList.Remove(mod.gameObject);
        fireRate -= mod.newFireRate;
        reloadSpeed -= mod.newReloadSpeed;
        magSize -= mod.newMagSize;
        recoilRate -= mod.newRecoilRate;
        spread -= mod.newSpread;
        ValClamp();
    }

    public void ValClamp()    // Clamp variables.
    {
        fireRate = Mathf.Clamp(fireRate, 1, 1000);
        reloadSpeed = Mathf.Clamp(reloadSpeed, 1, 1000);
        magSize = Mathf.Clamp(magSize, 1, 1000);
        recoilRate = Mathf.Clamp(recoilRate, 1, 1000);
        spread = Mathf.Clamp(spread, 1, 1000);
    }
}