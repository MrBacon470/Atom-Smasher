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

public class PrestigeManager : MonoBehaviour
{
    [Header("UI Stuff")]
    public Text[] prestigeTexts = new Text[5];
    public Text[] autoPrestigeTexts = new Text[5];
    private string[] elementNames = new string[] { "Hydrogen", "Helium", "Lithium", "Beryllium", "Boron", "Carbon" };
    private BigDouble[] prestigeBaseReq = new BigDouble[] { 1e10, 1e12, 1e14, 1e16, 1e18 };
    private BigDouble[] autoCosts = new BigDouble[] { 1e12, 1e14, 1e16, 1e18, 1e20 };
    private BigDouble[] prestigeRewards = new BigDouble[5];

    public static PrestigeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        var data = GameManager.Instance.data;
        CalculateReward();
    }

    private void Update()
    {
        var data = GameManager.Instance.data;
        CalculateReward();
        for(int i = 0; i < 5; i++)
        {
            prestigeTexts[i].text = data.elementTotals[i] < prestigeBaseReq[i] ? $"Not Enough {elementNames[i]}" : $"Prestige +{Methods.NotationMethod(prestigeRewards[i], "F2")} {elementNames[i + 1]}";
            autoPrestigeTexts[i].text = !data.isAutoUnlocked[i] ? $"Auto Prestige Locked\nCost: {Methods.NotationMethod(autoCosts[i], "F0")} {elementNames[i]}" : $"Auto Prestiger Active +{Methods.NotationMethod(prestigeRewards[i], "F2")} {elementNames[i + 1]}/s";
            if (data.isAutoUnlocked[i])
                data.elementTotals[i + 1] += prestigeRewards[i];
        }
    }

    public void Prestige(int id)
    {
        var data = GameManager.Instance.data;
        switch(id)
        {
            case 0:
                if (data.elementTotals[id] < prestigeBaseReq[id]) return;
                if (data.isAutoUnlocked[id]) return;
                data.elementTotals[id + 1] += prestigeRewards[id];
                data.isUnlocked[id] = true;
                for(int i = 0; i < 8; i++)
                {
                    data.hydrogenAmounts[i] = 0;
                    data.hydrogenLevels[i] = 0;
                }
                data.elementTotals[id] = 10;
                break;
            case 1:
                if (data.elementTotals[id] < prestigeBaseReq[id]) return;
                if (data.isAutoUnlocked[id]) return;
                data.elementTotals[id + 1] += prestigeRewards[id];
                data.isUnlocked[id] = true;
                for (int i = 0; i < 8; i++)
                {
                    data.heliumAmounts[i] = 0;
                    data.heliumLevels[i] = 0;
                }
                data.elementTotals[id] = 0;
                break;
            case 2:
                if (data.elementTotals[id] < prestigeBaseReq[id]) return;
                if (data.isAutoUnlocked[id]) return;
                data.elementTotals[id + 1] += prestigeRewards[id];
                data.isUnlocked[id] = true;
                for (int i = 0; i < 8; i++)
                {
                    data.lithiumAmounts[i] = 0;
                    data.lithiumLevels[i] = 0;
                }
                data.elementTotals[id] = 0;
                break;
            case 3:
                if (data.elementTotals[id] < prestigeBaseReq[id]) return;
                if (data.isAutoUnlocked[id]) return;
                data.elementTotals[id + 1] += prestigeRewards[id];
                data.isUnlocked[id] = true;
                for (int i = 0; i < 8; i++)
                {
                    data.berylliumAmounts[i] = 0;
                    data.berylliumLevels[i] = 0;
                }
                data.elementTotals[id] = 0;
                break;
            case 4:
                if (data.elementTotals[id] < prestigeBaseReq[id]) return;
                if (data.isAutoUnlocked[id]) return;
                data.elementTotals[id + 1] += prestigeRewards[id];
                data.isUnlocked[id] = true;
                for (int i = 0; i < 8; i++)
                {
                    data.boronAmounts[i] = 0;
                    data.boronLevels[i] = 0;
                }
                data.elementTotals[id] = 0;
                break;
        }
    }

    public void UnlockAuto(int id)
    {
        var data = GameManager.Instance.data;

        if (data.elementTotals[id] < autoCosts[id]) return;
        if (data.isAutoUnlocked[id]) return;
        data.isAutoUnlocked[id] = true;
        data.elementTotals[id] -= autoCosts[id];
    }

    private void CalculateReward()
    {
        var data = GameManager.Instance.data;
        for(int i = 0; i < 5; i++)
        {
            prestigeRewards[i] = 10 + 100000 * Sqrt(data.elementTotals[i] / prestigeBaseReq[i]);
        }
    }
}
