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

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class FusionController : MonoBehaviour
{
    public static FusionController Instance;

    public Generators[] Generators = new Generators[6];
    private string[] elementNames = new string[] { "Hydrogen", "Helium", "Lithium", "Beryllium", "Boron", "Carbon" };

    public Text massText;
    public Text boostText;
    public Text massToGetText;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        massToGetText.text = $"Fuse +{Methods.NotationMethod(fuseReward(), "F2")} AMU";
    }

    public void Fuse()
    {
        var data = GameManager.Instance.data;

        data.atomicMass += fuseReward();
        massText.text = $"{Methods.NotationMethod(data.atomicMass, "F2")} AMU";
        boostText.text = $"{Methods.NotationMethod(10 * Sqrt(data.atomicMass), "F2")}x Boost";

        for (int i = 0; i < 8; i++)
        {
            data.hydrogenLevels[i] = 0;
            data.hydrogenAmounts[i] = 0;

            data.heliumLevels[i] = 0;
            data.heliumAmounts[i] = 0;

            data.lithiumLevels[i] = 0;
            data.lithiumAmounts[i] = 0;

            data.berylliumLevels[i] = 0;
            data.berylliumAmounts[i] = 0;

            data.boronLevels[i] = 0;
            data.boronAmounts[i] = 0;

            data.carbonLevels[i] = 0;
            data.carbonAmounts[i] = 0;
        }

        data.isFusionUnlocked = false;
        for (int i = 0; i < 5; i++)
        {
            data.isUnlocked[i] = false;
            data.isAutoUnlocked[i] = false;
        }

        for (int i = 0; i < data.elementTotals.Length - 1; i++)
            data.elementTotals[i + 1] = 0;
        data.elementTotals[0] = 10;
        for(int i = 0; i < 6; i++)
        {
            Generators[i].UpdateCosts(elementNames[i]);
            Generators[i].UpdateCostTexts(elementNames[i]);
        }
        GameManager.Instance.ChangeTab("Hydrogen");
    }

    private BigDouble fuseReward()
    {
        var data = GameManager.Instance.data;

        BigDouble temp = 0;
        temp += 1.01 * data.elementTotals[0];
        temp += 4.00 * data.elementTotals[1];
        temp += 6.94 * data.elementTotals[2];
        temp += 9.00 * data.elementTotals[3];
        temp += 10.00 * data.elementTotals[4];
        temp += 12.00 * data.elementTotals[5];
        return temp;
    }
}
