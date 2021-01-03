/*
Copyright (c) 2020 MrBacon470

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using BreakInfinity;
using static BreakInfinity.BigDouble;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    
    public PlayerData data;
    [Header("Objects")]
    public GameObject fuseButton;
    public GameObject alphaPopUp;

    [Header("Canvases")]
    public Canvas[] tierCanvas = new Canvas[5];
    public Canvas CompoundCanvas;
    public Canvas ShopCanvas;
    public Canvas FusionCanvas;
    public Canvas startCanvas;
    public Canvas settingsCanvas;
    [Header("timers")]
    public float saveTimer;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        Application.targetFrameRate = 60;
        Application.runInBackground = true;
        data = SaveSystem.Instance.SaveExists("PlayerData") ? SaveSystem.LoadPlayer<PlayerData>("PlayerData") : new PlayerData();
        DisableAll();
        startCanvas.gameObject.SetActive(true);
        alphaPopUp.gameObject.SetActive(true);

    }

    public void Update()
    {

        saveTimer += Time.deltaTime;

        if (!(saveTimer >= 15)) return;
        Save();
        saveTimer = 0;
    }

    public void Save()
    {
        SaveSystem.SavePlayer(data, "PlayerData");
    }
    /*
    public ElementModel GetElement(ElementType element)
    {
        return data.ElementTotals.SingleOrDefault(x => x.ElementType == element);
    }

    public ChallengeModel GetChallenge(ChallengeTypes challenge)
    {
        return data.completions.SingleOrDefault(x => x.ChallengeTypes == challenge);
    }

    public ChallengeModel GetActiveChallenge()
    {
        return data.completions.SingleOrDefault(x => x.isActive == true);
    }

    public List<ElementModel> GetAllUnlockedElements()
    {
        return data.ElementTotals.Where(x => x.IsUnlocked == true).ToList();
    }
    */

    public void CloseGame()
    {
        Save();
        Application.Quit();
    }

    public void Discord()
    {
        Application.OpenURL("https://discord.gg/PU78QYR");
    }
    public void ChangeScreenSize()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void ChangeTab(string id)
    {
        DisableAll();
        switch(id)
        {
            case "Hydrogen":
                tierCanvas[0].gameObject.SetActive(true);
                break;
            case "Helium":
                tierCanvas[1].gameObject.SetActive(true);
                break;
            case "Lithium":
                tierCanvas[2].gameObject.SetActive(true);
                break;
            case "Beryllium":
                tierCanvas[3].gameObject.SetActive(true);
                break;
            case "Boron":
                tierCanvas[4].gameObject.SetActive(true);
                break;
            case "Compound":
                CompoundCanvas.gameObject.SetActive(true);
                break;
            case "Fusion":
                FusionCanvas.gameObject.SetActive(true);
                break;
            case "Settings":
                settingsCanvas.gameObject.SetActive(true);
                break;
        }
    }

    public void DisableAll()
    {
        for(int i = 0; i < 5; i ++)
        {
            tierCanvas[i].gameObject.SetActive(false);
        }
        startCanvas.gameObject.SetActive(false);
        CompoundCanvas.gameObject.SetActive(false);
        FusionCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(false);
    }


    public void ClosePopUp()
    {
        alphaPopUp.gameObject.SetActive(false);
    }

    public void FullReset()
    {
        data = new PlayerData();
    }

    public BigDouble elementBoost(int id)
    {
        BigDouble temp = 1;
        temp += Sqrt(data.elementTotals[id + 1]);
        return temp;
    }
}