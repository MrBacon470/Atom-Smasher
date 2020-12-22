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
    public GameObject[] elementButtons = new GameObject[5];
    [Header("Canvases")]
    public Canvas[] elementCanvas = new Canvas[6];
    public Canvas challengesCanvas;
    public Canvas fusionCanvas;
    public Canvas startCanvas;
    public Canvas settingsCanvas;
    [Header("timers")]
    public float saveTimer;
    [Header("Bools")]
    public bool[] isSelected = new bool[6];

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        Application.targetFrameRate = 60;
        data = SaveSystem.Instance.SaveExists("PlayerData") ? SaveSystem.LoadPlayer<PlayerData>("PlayerData") : new PlayerData();
        isSelected[0] = true;
        for(int i = 0; i < 5; i++)
            isSelected[i + 0] = false;
        DisableAll();
        startCanvas.gameObject.SetActive(true);
        alphaPopUp.gameObject.SetActive(true);

        for(int i = 0; i < 5; i++)
        {
            if (data.isUnlocked[i])
                elementButtons[i].gameObject.SetActive(true);
            else
                elementButtons[i].gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        var challenge = ChallengeManager.Instance;
        
        
        
        if(!challenge.isActive[0] && !challenge.isActive[6] && !challenge.isActive[5])
            data.elementTotals[0] += (data.hydrogenLevels[0] + data.hydrogenAmounts[0]) * Time.deltaTime;
        else
            data.elementTotals[0] += ((data.hydrogenLevels[0] / challenge.challengeModifier(0)) + (data.hydrogenAmounts[0] / challenge.challengeModifier(0))) * Time.deltaTime;
        for (int i = 0; i < 8; i++)
        {
            data.hydrogenAmounts[i] += i >= 7 ? (data.heliumLevels[0] + data.heliumAmounts[0]) * Time.deltaTime : (data.hydrogenLevels[i + 1] + data.hydrogenAmounts[i + 1]) * Time.deltaTime;
            if(challenge.isActive[2] || challenge.isActive[6])
                data.heliumAmounts[i] += i >= 7 ? ((data.lithiumLevels[0] + data.lithiumAmounts[0]) / challenge.challengeModifier(2)) * Time.deltaTime : (data.heliumLevels[i + 1] + data.heliumAmounts[i + 1]) * Time.deltaTime;
            else
                data.heliumAmounts[i] += i >= 7 ? ((data.lithiumLevels[0] + data.lithiumAmounts[0])) * Time.deltaTime : (data.heliumLevels[i + 1] + data.heliumAmounts[i + 1]) * Time.deltaTime;
            data.lithiumAmounts[i] += i >= 7 ? (data.berylliumLevels[0] + data.berylliumAmounts[0]) * Time.deltaTime : (data.lithiumLevels[i + 1] + data.lithiumAmounts[i + 1]) * Time.deltaTime;
            data.berylliumAmounts[i] += i >= 7 ? (data.boronLevels[0] + data.boronAmounts[0]) * Time.deltaTime : (data.berylliumLevels[i + 1] + data.berylliumAmounts[i + 1]) * Time.deltaTime;
            data.boronAmounts[i] += i >= 7 ? (data.carbonLevels[0] + data.carbonAmounts[0]) * Time.deltaTime : (data.boronLevels[i + 1] + data.boronAmounts[i + 1]) * Time.deltaTime;
            data.carbonAmounts[i] += i >= 7 ? 0 : (data.carbonLevels[i + 1] + data.carbonAmounts[i + 1]) * Time.deltaTime;
        }

        if (data.elementTotals[5] > 1e42)
            data.isFusionUnlocked = true;

        if (data.isFusionUnlocked)
            fuseButton.gameObject.SetActive(true);
        else
            fuseButton.gameObject.SetActive(false);

        for (int i = 0; i < 5; i++)
        {
            if (data.isUnlocked[i])
                elementButtons[i].gameObject.SetActive(true);
            else
                elementButtons[i].gameObject.SetActive(false);
        }

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

    public void ChangeTab(string id)
    {
        DisableAll();
        switch(id)
        {
            case "Hydrogen":
                DeselectAll();
                isSelected[0] = true;
                elementCanvas[0].gameObject.SetActive(true);
                break;
            case "Helium":
                DeselectAll();
                isSelected[1] = true;
                elementCanvas[1].gameObject.SetActive(true);
                break;
            case "Lithium":
                DeselectAll();
                isSelected[2] = true;
                elementCanvas[2].gameObject.SetActive(true);
                break;
            case "Beryllium":
                DeselectAll();
                isSelected[3] = true;
                elementCanvas[3].gameObject.SetActive(true);
                break;
            case "Boron":
                DeselectAll();
                isSelected[4] = true;
                elementCanvas[4].gameObject.SetActive(true);
                break;
            case "Carbon":
                DeselectAll();
                isSelected[5] = true;
                elementCanvas[5].gameObject.SetActive(true);
                break;
            case "Challenges":
                challengesCanvas.gameObject.SetActive(true);
                break;
            case "Fusion":
                fusionCanvas.gameObject.SetActive(true);
                break;
            case "Settings":
                settingsCanvas.gameObject.SetActive(true);
                break;
        }
    }

    public void DisableAll()
    {
        for(int i = 0; i < 6; i ++)
        {
            elementCanvas[i].gameObject.SetActive(false);
        }
        startCanvas.gameObject.SetActive(false);
        challengesCanvas.gameObject.SetActive(false);
        fusionCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(false);
    }

    public void DeselectAll()
    {
        for(int i = 0; i < 6; i++)
            isSelected[i] = false;
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