using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeBoons : MonoBehaviour
{
    // VARIABLES.
    int chance;
    int minChance, maxChance;

    int boonChance;
    public bool boonStart { get; set; }
    
    public ModSystem modSystem;

    int activeMods;
    int reloadTime; //test
    int fireRate; //test
    bool canShoot; //test
    bool isReloading; //test

    // FUNCTIONS.
    void Start()
    {
        //bool canShoot = Gun.canShoot;         placeholder name
        //bool isReloading = Gun.isReloading;       placeholder name
        boonStart = true;   
        minChance = 0;
        reloadTime = 1; //test
    }

    void Update() // Boon chance per bullet.
    {
        if (Input.GetKeyDown(KeyCode.Space)) //test (per bullet)
        {
            //int fireRate = Gun.fireRate;
            //int reloadTime = Gun.reloadTime;
            activeMods = modSystem.activeMods;
            maxChance = activeMods * 2;
            chance = Random.Range(0, 100);
            if (chance >= minChance && chance <= maxChance)
            {
                BoonActive();
            }
        }
    }

    public void BoonActive()    // Boon system.
    {
        if (boonStart == true)
        {
            // Default chances.
            int[] chanceStuff = { 0, 25, 50, 75, 100 };
            // Chances the default chances for all the mods.
            if (activeMods != 0)
            {
                for (int i = 0; i < activeMods; i++)
                {
                    chanceStuff = ChangeChance(modSystem.activeModsList[i], chanceStuff);
                }
            }
            // Pick Boon.
            boonChance = Random.Range(0, chanceStuff[chanceStuff.Length - 1]);
            if (boonChance >= chanceStuff[0] && boonChance <= chanceStuff[1])
            {
                int oldFireRate = fireRate;
                StartCoroutine(Sputter(oldFireRate));
            }
            else if (boonChance >= chanceStuff[1] && boonChance <= chanceStuff[2])
            {
                StartCoroutine(Reload());
            }
            else if (boonChance >= chanceStuff[2] && boonChance <= chanceStuff[3])
            {
                StartCoroutine(DropMag());
            }
            else if (boonChance >= chanceStuff[3] && boonChance <= chanceStuff[4])
            {
                StartCoroutine(Jam());
            }
        }
    }
    public int[] ChangeChance(GameObject modType, int[] chanceStuff) // Change specific Boon chances.
    {
        for (int x = 0; x < modType.GetComponent<Mods>().boonTypes.Length; x++)
        {
            for (int i = modType.GetComponent<Mods>().modType; i < chanceStuff.Length; i++)
            {
                chanceStuff[i] = chanceStuff[i] + modType.GetComponent<Mods>().boonsChance[x];
            }
            boonChance += modType.GetComponent<Mods>().boonsChance[x];
        }
        return (chanceStuff);
    }

    IEnumerator Sputter(int oldFireRate, int counter = 0)  // Barrel Sputter Boon.
    {
        Debug.Log("Sputter boon"); //test
        boonStart = false;
        float waitTime = 5;
        do
        {
            yield return new WaitForSecondsRealtime(2f);
            if (counter < waitTime)
            {
                //Gun.fireRate = Random.Range(1, 1000);
                fireRate = Random.Range(1, 1000); //test
            }
            else if (counter == waitTime)
            {
                //Gun.fireRate = oldFireRate; 
                fireRate = oldFireRate; //test
            }
            counter += 1;
        }
        while (counter <= waitTime);
        boonStart = true;
    }
    IEnumerator Reload()   // Stock Reload Boon.
    {
        Debug.Log("Reload boon"); //test
        boonStart = false;
        //Gun.Reload();
        yield return new WaitForSeconds(reloadTime * 2); //test
        boonStart = true;
    }
    IEnumerator DropMag()  // Magazine DropMag Boon.
    {
        Debug.Log("DropMag boon"); //test
        canShoot = false;
        boonStart = false;
        // Drop magazine & reload.
        yield return new WaitForSeconds(reloadTime * 2); //test
        canShoot = true;
        boonStart = true;
    }
    IEnumerator Jam()   // Trigger Jam Boon.
    {
        Debug.Log("Jam boon"); //test
        canShoot = false;
        boonStart = false;
        yield return new WaitForSeconds(2);
        canShoot = true;
        boonStart = true;
    }
}