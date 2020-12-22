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

public class Generators : MonoBehaviour
{
    [Header("Texts")]
    public Text[] costTexts = new Text[8];
    public Text[] statTexts = new Text[8];
    public Button[] buyerButtons = new Button[8];
    [Header("Cost Storage")]
    public BigDouble[] genCosts = new BigDouble[8];
    private BigDouble costMult = 1.15;
    private BigDouble[] genBaseCosts = new BigDouble[] { 10, 100, 1e3, 1e4, 1e5, 1e6, 1e7, 1e8 };

    public void UpdateStatTexts(string id)
    {
        var data = GameManager.Instance.data;
        for(int i = 0; i < 8; i++)
        {
            switch(id)
            {
                case "Hydrogen":
                    statTexts[i].text = $"Gen-0{i + 1} Level:x{Methods.NotationMethod(data.hydrogenLevels[i], "F0")}({Methods.NotationMethod(data.hydrogenAmounts[i], "F2")})";
                    break;
                case "Helium":
                    statTexts[i].text = $"Gen-0{i + 1} Level:x{Methods.NotationMethod(data.heliumLevels[i], "F0")}({Methods.NotationMethod(data.heliumAmounts[i], "F2")})";
                    break;
                case "Lithium":
                    statTexts[i].text = $"Gen-0{i + 1} Level:x{Methods.NotationMethod(data.lithiumLevels[i], "F0")}({Methods.NotationMethod(data.lithiumAmounts[i], "F2")})";
                    break;
                case "Beryllium":
                    statTexts[i].text = $"Gen-0{i + 1} Level:x{Methods.NotationMethod(data.berylliumLevels[i], "F0")}({Methods.NotationMethod(data.berylliumAmounts[i], "F2")})";
                    break;
                case "Boron":
                    statTexts[i].text = $"Gen-0{i + 1} Level:x{Methods.NotationMethod(data.boronLevels[i], "F0")}({Methods.NotationMethod(data.boronAmounts[i], "F2")})";
                    break;
                case "Carbon":
                    statTexts[i].text = $"Gen-0{i + 1} Level:x{Methods.NotationMethod(data.carbonLevels[i], "F0")}({Methods.NotationMethod(data.carbonAmounts[i], "F2")})";
                    break;
            }
        }
    }

    public void UpdateCostTexts(string id)
    {
        
        for (int i = 0; i < 8; i++)
        {
            switch (id)
            {
                case "Hydrogen":
                    costTexts[i].text = $"Cost:{Methods.NotationMethod(genCosts[i],"F2")} Hydrogen";
                    break;
                case "Helium":
                    costTexts[i].text = $"Cost:{Methods.NotationMethod(genCosts[i], "F2")} Helium";
                    break;
                case "Lithium":
                    costTexts[i].text = $"Cost:{Methods.NotationMethod(genCosts[i], "F2")} Lithium";
                    break;
                case "Beryllium":
                    costTexts[i].text = $"Cost:{Methods.NotationMethod(genCosts[i], "F2")} Beryllium";
                    break;
                case "Boron":
                    costTexts[i].text = $"Cost:{Methods.NotationMethod(genCosts[i], "F2")} Boron";
                    break;
                case "Carbon":
                    costTexts[i].text = $"Cost:{Methods.NotationMethod(genCosts[i], "F2")} Carbon";
                    break;
            }
        }
    }

    public void UpdateCosts(string id)
    {
        var data = GameManager.Instance.data;
        var challenge = ChallengeManager.Instance;
        for(int i = 0; i < 8; i++)
        {
            switch(id)
            {
                case "Hydrogen":
                    genCosts[i] = genBaseCosts[i] * Pow(costMult, data.hydrogenLevels[i]);
                    break;
                case "Helium":
                    genCosts[i] = !challenge.isActive[1] && !challenge.isActive[6] ? genBaseCosts[i] * Pow(costMult, data.heliumLevels[i]) : genBaseCosts[i] * Pow(challenge.challengeModifier(1), data.heliumLevels[i]);
                    break;
                case "Lithium":
                    genCosts[i] = genBaseCosts[i] * Pow(costMult, data.lithiumLevels[i]);
                    break;
                case "Beryllium":
                    genCosts[i] = !challenge.isActive[3] && !challenge.isActive[6] ? genBaseCosts[i] * Pow(costMult, data.berylliumLevels[i]) : genBaseCosts[i] * Pow(challenge.challengeModifier(3), data.heliumLevels[i]); ;
                    break;
                case "Boron":
                    genCosts[i] = genBaseCosts[i] * Pow(costMult, data.boronLevels[i]);
                    break;
                case "Carbon":
                    genCosts[i] = genBaseCosts[i] * Pow(costMult, data.carbonLevels[i]);
                    break;
            }
        }
    }
}
