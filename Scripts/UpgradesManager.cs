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

public class UpgradesManager : MonoBehaviour
{
    [Header("Scripts")]
    public Generators[] generators = new Generators[6];
    [Header("UI Stuff")]
    public string[] elementNames = new string[] { "Hydrogen", "Helium", "Lithium", "Beryllium", "Boron", "Carbon" };


    public static UpgradesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            generators[i].UpdateCosts(elementNames[i]);
            generators[i].UpdateCostTexts(elementNames[i]);
            generators[i].UpdateStatTexts(elementNames[i]);
        }
    }


    private void Update()
    {
        for(int i = 0; i < 6; i++)
        {
            generators[i].UpdateStatTexts(elementNames[i]);
        }
    }

    public void BuyHydrogenGen(int upgradeID)
    {
        var data = GameManager.Instance.data;
        generators[0].UpdateCosts("Hydrogen");
        generators[0].UpdateCostTexts("Hydrogen");
        
        switch (upgradeID)
        {
            case 0:
                if (data.elementTotals[0] < generators[0].genCosts[upgradeID]) return;
                data.elementTotals[0] -= generators[0].genCosts[upgradeID];
                data.hydrogenLevels[upgradeID]++;
                break;
            case 1:
                if (data.elementTotals[0] < generators[0].genCosts[upgradeID]) return;
                data.elementTotals[0] -= generators[0].genCosts[upgradeID];
                data.hydrogenLevels[upgradeID]++;
                break;
            case 2:
                if (data.elementTotals[0] < generators[0].genCosts[upgradeID]) return;
                data.elementTotals[0] -= generators[0].genCosts[upgradeID];
                data.hydrogenLevels[upgradeID]++;
                break;
            case 3:
                if (data.elementTotals[0] < generators[0].genCosts[upgradeID]) return;
                data.elementTotals[0] -= generators[0].genCosts[upgradeID];
                data.hydrogenLevels[upgradeID]++;
                break;
            case 4:
                if (data.elementTotals[0] < generators[0].genCosts[upgradeID]) return;
                data.elementTotals[0] -= generators[0].genCosts[upgradeID];
                data.hydrogenLevels[upgradeID]++;
                break;
            case 5:
                if (data.elementTotals[0] < generators[0].genCosts[upgradeID]) return;
                data.elementTotals[0] -= generators[0].genCosts[upgradeID];
                data.hydrogenLevels[upgradeID]++;
                break;
            case 6:
                if (data.elementTotals[0] < generators[0].genCosts[upgradeID]) return;
                data.elementTotals[0] -= generators[0].genCosts[upgradeID];
                data.hydrogenLevels[upgradeID]++;
                break;
            case 7:
                if (data.elementTotals[0] < generators[0].genCosts[upgradeID]) return;
                data.elementTotals[0] -= generators[0].genCosts[upgradeID];
                data.hydrogenLevels[upgradeID]++;
                break;
        }
        generators[0].UpdateCosts("Hydrogen");
        generators[0].UpdateCostTexts("Hydrogen");
    }

    public void BuyHeliumGen(int upgradeID)
    {
        var data = GameManager.Instance.data;
        generators[1].UpdateCosts("Helium");
        generators[1].UpdateCostTexts("Helium");
        switch (upgradeID)
        {
            case 0:
                if (data.elementTotals[1] < generators[1].genCosts[upgradeID]) return;
                data.elementTotals[1] -= generators[1].genCosts[upgradeID];
                data.heliumLevels[upgradeID]++;
                break;
            case 1:
                if (data.elementTotals[1] < generators[1].genCosts[upgradeID]) return;
                data.elementTotals[1] -= generators[1].genCosts[upgradeID];
                data.heliumLevels[upgradeID]++;
                break;
            case 2:
                if (data.elementTotals[1] < generators[1].genCosts[upgradeID]) return;
                data.elementTotals[1] -= generators[1].genCosts[upgradeID];
                data.heliumLevels[upgradeID]++;
                break;
            case 3:
                if (data.elementTotals[1] < generators[1].genCosts[upgradeID]) return;
                data.elementTotals[1] -= generators[1].genCosts[upgradeID];
                data.heliumLevels[upgradeID]++;
                break;
            case 4:
                if (data.elementTotals[1] < generators[1].genCosts[upgradeID]) return;
                data.elementTotals[1] -= generators[1].genCosts[upgradeID];
                data.heliumLevels[upgradeID]++;
                break;
            case 5:
                if (data.elementTotals[1] < generators[1].genCosts[upgradeID]) return;
                data.elementTotals[1] -= generators[1].genCosts[upgradeID];
                data.heliumLevels[upgradeID]++;
                break;
            case 6:
                if (data.elementTotals[1] < generators[1].genCosts[upgradeID]) return;
                data.elementTotals[1] -= generators[1].genCosts[upgradeID];
                data.heliumLevels[upgradeID]++;
                break;
            case 7:
                if (data.elementTotals[1] < generators[1].genCosts[upgradeID]) return;
                data.elementTotals[1] -= generators[1].genCosts[upgradeID];
                data.heliumLevels[upgradeID]++;
                break;
        }
        generators[1].UpdateCosts("Helium");
        generators[1].UpdateCostTexts("Helium");
    }

    public void BuyLithiumGen(int upgradeID)
    {
        var data = GameManager.Instance.data;
        generators[2].UpdateCosts("Lithium");
        generators[2].UpdateCostTexts("Lithium");
        switch (upgradeID)
        {
            case 0:
                if (data.elementTotals[2] < generators[2].genCosts[upgradeID]) return;
                data.elementTotals[2] -= generators[2].genCosts[upgradeID];
                data.lithiumLevels[upgradeID]++;
                break;
            case 1:
                if (data.elementTotals[2] < generators[2].genCosts[upgradeID]) return;
                data.elementTotals[2] -= generators[2].genCosts[upgradeID];
                data.lithiumLevels[upgradeID]++;
                break;
            case 2:
                if (data.elementTotals[2] < generators[2].genCosts[upgradeID]) return;
                data.elementTotals[2] -= generators[2].genCosts[upgradeID];
                data.lithiumLevels[upgradeID]++;
                break;
            case 3:
                if (data.elementTotals[2] < generators[2].genCosts[upgradeID]) return;
                data.elementTotals[2] -= generators[2].genCosts[upgradeID];
                data.lithiumLevels[upgradeID]++;
                break;
            case 4:
                if (data.elementTotals[2] < generators[2].genCosts[upgradeID]) return;
                data.elementTotals[2] -= generators[2].genCosts[upgradeID];
                data.lithiumLevels[upgradeID]++;
                break;
            case 5:
                if (data.elementTotals[2] < generators[2].genCosts[upgradeID]) return;
                data.elementTotals[2] -= generators[2].genCosts[upgradeID];
                data.lithiumLevels[upgradeID]++;
                break;
            case 6:
                if (data.elementTotals[2] < generators[2].genCosts[upgradeID]) return;
                data.elementTotals[2] -= generators[2].genCosts[upgradeID];
                data.lithiumLevels[upgradeID]++;
                break;
            case 7:
                if (data.elementTotals[2] < generators[2].genCosts[upgradeID]) return;
                data.elementTotals[2] -= generators[2].genCosts[upgradeID];
                data.lithiumLevels[upgradeID]++;
                break;
        }
        generators[2].UpdateCosts("Lithium");
        generators[2].UpdateCostTexts("Lithium");
    }

    public void BuyBerylliumGen(int upgradeID)
    {
        var data = GameManager.Instance.data;
        generators[3].UpdateCosts("Beryllium");
        generators[3].UpdateCostTexts("Beryllium");
        switch (upgradeID)
        {
            case 0:
                if (data.elementTotals[3] < generators[3].genCosts[upgradeID]) return;
                data.elementTotals[3] -= generators[3].genCosts[upgradeID];
                data.berylliumLevels[upgradeID]++;
                break;
            case 1:
                if (data.elementTotals[3] < generators[3].genCosts[upgradeID]) return;
                data.elementTotals[3] -= generators[3].genCosts[upgradeID];
                data.berylliumLevels[upgradeID]++;
                break;
            case 2:
                if (data.elementTotals[3] < generators[3].genCosts[upgradeID]) return;
                data.elementTotals[3] -= generators[3].genCosts[upgradeID];
                data.berylliumLevels[upgradeID]++;
                break;
            case 3:
                if (data.elementTotals[3] < generators[3].genCosts[upgradeID]) return;
                data.elementTotals[3] -= generators[3].genCosts[upgradeID];
                data.berylliumLevels[upgradeID]++;
                break;
            case 4:
                if (data.elementTotals[3] < generators[3].genCosts[upgradeID]) return;
                data.elementTotals[3] -= generators[3].genCosts[upgradeID];
                data.berylliumLevels[upgradeID]++;
                break;
            case 5:
                if (data.elementTotals[3] < generators[3].genCosts[upgradeID]) return;
                data.elementTotals[3] -= generators[3].genCosts[upgradeID];
                data.berylliumLevels[upgradeID]++;
                break;
            case 6:
                if (data.elementTotals[3] < generators[3].genCosts[upgradeID]) return;
                data.elementTotals[3] -= generators[3].genCosts[upgradeID];
                data.berylliumLevels[upgradeID]++;
                break;
            case 7:
                if (data.elementTotals[3] < generators[3].genCosts[upgradeID]) return;
                data.elementTotals[3] -= generators[3].genCosts[upgradeID];
                data.berylliumLevels[upgradeID]++;
                break;
        }
        generators[3].UpdateCosts("Beryllium");
        generators[3].UpdateCostTexts("Beryllium");
    }

    public void BuyBoronGen(int upgradeID)
    {
        var data = GameManager.Instance.data;
        generators[4].UpdateCosts("Boron");
        generators[4].UpdateCostTexts("Boron");
        switch (upgradeID)
        {
            case 0:
                if (data.elementTotals[4] < generators[4].genCosts[upgradeID]) return;
                data.elementTotals[4] -= generators[4].genCosts[upgradeID];
                data.boronLevels[upgradeID]++;
                break;
            case 1:
                if (data.elementTotals[4] < generators[4].genCosts[upgradeID]) return;
                data.elementTotals[4] -= generators[4].genCosts[upgradeID];
                data.boronLevels[upgradeID]++;
                break;
            case 2:
                if (data.elementTotals[4] < generators[4].genCosts[upgradeID]) return;
                data.elementTotals[4] -= generators[4].genCosts[upgradeID];
                data.boronLevels[upgradeID]++;
                break;
            case 3:
                if (data.elementTotals[4] < generators[4].genCosts[upgradeID]) return;
                data.elementTotals[4] -= generators[4].genCosts[upgradeID];
                data.boronLevels[upgradeID]++;
                break;
            case 4:
                if (data.elementTotals[4] < generators[4].genCosts[upgradeID]) return;
                data.elementTotals[4] -= generators[4].genCosts[upgradeID];
                data.boronLevels[upgradeID]++;
                break;
            case 5:
                if (data.elementTotals[4] < generators[4].genCosts[upgradeID]) return;
                data.elementTotals[4] -= generators[4].genCosts[upgradeID];
                data.boronLevels[upgradeID]++;
                break;
            case 6:
                if (data.elementTotals[4] < generators[4].genCosts[upgradeID]) return;
                data.elementTotals[4] -= generators[4].genCosts[upgradeID];
                data.boronLevels[upgradeID]++;
                break;
            case 7:
                if (data.elementTotals[4] < generators[4].genCosts[upgradeID]) return;
                data.elementTotals[4] -= generators[4].genCosts[upgradeID];
                data.boronLevels[upgradeID]++;
                break;
        }
        generators[4].UpdateCosts("Boron");
        generators[4].UpdateCostTexts("Boron");
    }

    public void BuyCarbonGen(int upgradeID)
    {
        var data = GameManager.Instance.data;
        generators[5].UpdateCosts("Carbon");
        generators[5].UpdateCostTexts("Carbon");
        switch (upgradeID)
        {
            case 0:
                if (data.elementTotals[5] < generators[5].genCosts[upgradeID]) return;
                data.elementTotals[5] -= generators[5].genCosts[upgradeID];
                data.carbonLevels[upgradeID]++;
                break;
            case 1:
                if (data.elementTotals[5] < generators[5].genCosts[upgradeID]) return;
                data.elementTotals[5] -= generators[5].genCosts[upgradeID];
                data.carbonLevels[upgradeID]++;
                break;
            case 2:
                if (data.elementTotals[5] < generators[5].genCosts[upgradeID]) return;
                data.elementTotals[5] -= generators[5].genCosts[upgradeID];
                data.carbonLevels[upgradeID]++;
                break;
            case 3:
                if (data.elementTotals[5] < generators[5].genCosts[upgradeID]) return;
                data.elementTotals[5] -= generators[5].genCosts[upgradeID];
                data.carbonLevels[upgradeID]++;
                break;
            case 4:
                if (data.elementTotals[5] < generators[5].genCosts[upgradeID]) return;
                data.elementTotals[5] -= generators[5].genCosts[upgradeID];
                data.carbonLevels[upgradeID]++;
                break;
            case 5:
                if (data.elementTotals[5] < generators[5].genCosts[upgradeID]) return;
                data.elementTotals[5] -= generators[5].genCosts[upgradeID];
                data.carbonLevels[upgradeID]++;
                break;
            case 6:
                if (data.elementTotals[5] < generators[5].genCosts[upgradeID]) return;
                data.elementTotals[5] -= generators[5].genCosts[upgradeID];
                data.carbonLevels[upgradeID]++;
                break;
            case 7:
                if (data.elementTotals[5] < generators[5].genCosts[upgradeID]) return;
                data.elementTotals[5] -= generators[5].genCosts[upgradeID];
                data.carbonLevels[upgradeID]++;
                break;
        }
        generators[5].UpdateCosts("Carbon");
        generators[5].UpdateCostTexts("Carbon");
    }
}
