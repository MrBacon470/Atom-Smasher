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
using System.Text;

public class ChallengeManager : MonoBehaviour
{
    public Text infoText;
    public Image infoBG;
    public Text challengeText;
    public Text challengePointsText;
    public Text cpBoostText;
    [Header("Non UI Stuff")]
    public bool[] isActive = new bool[8];
    public int challengeIndex = 0;
    public BigDouble[] challengeGoal = new BigDouble[8];
    public BigDouble[] challengeReward = new BigDouble[8];
    public BigDouble challengeGoalMult = 2;
    public BigDouble[] challengeRewardMult = new BigDouble[] { 1.15, 1.20, 1.25, 1.30, 1.35, 1.40, 1.45, 1.50 };
    public BigDouble[] challengeRewardBase = new BigDouble[] { 12, 120, 1.2e3, 1.2e4, 1.2e5, 1.2e6, 1.2e7, 1.2e8 };

    public static ChallengeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateNumbers();
        SelectChallenge(0);
    }

    private void Update()
    {
        for(int i = 0; i < 8; i++)
        {
            if(isActive[i])
            {
                TestIfCompleted(i);
            }
        }
    }

    public void SelectChallenge(int id)
    {
        var data = GameManager.Instance.data;
        UpdateNumbers();
        challengeIndex = id;
        switch (id)
        {
            case 0:
                infoText.text = $"C-01 Hydrogenated\nHydrogen Production is decreased due to Trans-Fat demands by {Methods.NotationMethod((0.01 * data.challengeCompletions[0]) + 0.01, "F2")}x\nGoal: {Methods.NotationMethod(challengeGoal[0], "F2")} " +
                    $"Hydrogen\nReward: {Methods.NotationMethod(challengeReward[0], "F2")} CP\nCompletions: {Methods.NotationMethod(data.challengeCompletions[0], "F2")}";
                infoBG.color = Methods.GetColorFromString("#737373");
                break;
            case 1:
                infoText.text = $"C-02 Helium > Hydrogen\nHelium Stockpiles have been raided to make the Hindenburg II, Upgrades are {Methods.NotationMethod(2 + (2 * data.challengeCompletions[1]), "F2")}x\nGoal: {Methods.NotationMethod(challengeGoal[1], "F2")} " +
                    $"Helium\nReward: {Methods.NotationMethod(challengeReward[1], "F2")} CP\nCompletions: {Methods.NotationMethod(data.challengeCompletions[1], "F2")}";
                infoBG.color = Methods.GetColorFromString("#9E494A");
                break;
            case 2:
                infoText.text = $"C-03 Lithium Ion Batteries\nElon Musk needs more batteries, Lithium Generators are {Methods.NotationMethod(1.1 + (1.1 * data.challengeCompletions[2]),"F2")}x Less Efficent\nGoal: {Methods.NotationMethod(challengeGoal[2], "F2")} " +
                    $"Lithium\nReward: {Methods.NotationMethod(challengeReward[2], "F2")} CP\nCompletions: {Methods.NotationMethod(data.challengeCompletions[2], "F2")}";
                infoBG.color = Methods.GetColorFromString("#A96E3C");
                break;
            case 3:
                infoText.text = $"C-04 Beryllium == Emeralds\nBeryllium Ore Stockpiles have been hit. Beryllium Costs are {Methods.NotationMethod(6 + (6 * data.challengeCompletions[3]), "F2")}x\nGoal: {Methods.NotationMethod(challengeGoal[3], "F2")} " +
                    $"Beryllium\nReward: {Methods.NotationMethod(challengeReward[3], "F2")} CP\nCompletions: {Methods.NotationMethod(data.challengeCompletions[3], "F2")}";
                infoBG.color = Methods.GetColorFromString("#C1BE3D");
                break;
            case 4:
                infoText.text = $"C-05 Poor Boron\nBoron has run out for the production of Borax. Boron production is Decreased by {Methods.NotationMethod(1.25 + (1.25 * data.challengeCompletions[4]), "F2")}x\nGoal: {Methods.NotationMethod(challengeGoal[4], "F2")} " +
                   $"Boron\nReward: {Methods.NotationMethod(challengeReward[4], "F2")} CP\nCompletions: {Methods.NotationMethod(data.challengeCompletions[4], "F2")}";
                infoBG.color = Methods.GetColorFromString("#4CA439");
                break;
            case 5:
                infoText.text = $"C-06 Carbon is the Key to Life\nHydrocarbons have taken over Carbon production lines, Fight against a steadily increasing production limit\nGoal: {Methods.NotationMethod(challengeGoal[5], "F2")} " +
                   $"Carbon\nReward: {Methods.NotationMethod(challengeReward[5], "F2")} CP\nCompletions: {Methods.NotationMethod(data.challengeCompletions[5], "F2")}";
                infoBG.color = Methods.GetColorFromString("#4289A6");
                break;
            case 6:
                infoText.text = $"C-07 Impossible Returns\nEnjoy the Negative Effects of C-01 to C-06\nGoal: {Methods.NotationMethod(challengeGoal[6], "F2")} " +
                   $"Hydrogen\nReward: {Methods.NotationMethod(challengeReward[6], "F2")} CP\nCompletions: {Methods.NotationMethod(data.challengeCompletions[6], "F2")}";
                infoBG.color = Methods.GetColorFromString("#0A6D13");
                break;
            case 7:
                infoText.text = $"C-08 Moles != Moles\nSuffer without any molar mass boosting\nGoal: {Methods.NotationMethod(challengeGoal[7], "F2")} " +
                   $"Carbon\nReward: {Methods.NotationMethod(challengeReward[7], "F2")} CP\nCompletions: {Methods.NotationMethod(data.challengeCompletions[7], "F2")}";
                infoBG.color = Methods.GetColorFromString("#360055");
                break;
        }
    }

    public void StartChallenge()
    {
        for (int i = 0; i < 8; i++)
            if (isActive[i]) return;
        UpdateNumbers();
        switch(challengeIndex)
        {
            case 0:
                isActive[challengeIndex] = true;
                challengeText.text = $"C-01 Active Goal:{Methods.NotationMethod(challengeGoal[0], "F2")} Hydrogen";
                break;
            case 1:
                isActive[challengeIndex] = true;
                challengeText.text = $"C-02 Active Goal:{Methods.NotationMethod(challengeGoal[1], "F2")} Helium";
                break;
            case 2:
                isActive[challengeIndex] = true;
                challengeText.text = $"C-03 Active Goal:{Methods.NotationMethod(challengeGoal[2], "F2")} Lithium";
                break;
            case 3:
                isActive[challengeIndex] = true;
                challengeText.text = $"C-04 Active Goal:{Methods.NotationMethod(challengeGoal[3], "F2")} Beryllium";
                break;
            case 4:
                isActive[challengeIndex] = true;
                challengeText.text = $"C-05 Active Goal:{Methods.NotationMethod(challengeGoal[4], "F2")} Boron";
                break;
            case 5:
                isActive[challengeIndex] = true;
                challengeText.text = $"C-06 Active Goal:{Methods.NotationMethod(challengeGoal[5], "F2")} Carbon";
                break;
            case 6:
                isActive[challengeIndex] = true;
                challengeText.text = $"C-07 Active Goal:{Methods.NotationMethod(challengeGoal[6], "F2")} Hydrogen";
                break;
            case 7:
                isActive[challengeIndex] = true;
                challengeText.text = $"C-08 Active Goal:{Methods.NotationMethod(challengeGoal[7], "F2")} Carbon";
                break;
        }
    }

    public void TestIfCompleted(int id)
    {
        var data = GameManager.Instance.data;
        switch (id)
        {
            case 0:
                if (data.elementTotals[0] < challengeGoal[0]) return;
                data.challengePoints += challengeReward[0];
                data.challengeCompletions[id]++;
                UpdateNumbers();
                ExitChallenge();
                UpdateCP();
                SelectChallenge(id);
                break;
            case 1:
                if (data.elementTotals[1] < challengeGoal[1]) return;
                data.challengePoints += challengeReward[1];
                data.challengeCompletions[id]++;
                UpdateNumbers();
                ExitChallenge();
                UpdateCP();
                SelectChallenge(id);
                break;
            case 2:
                if (data.elementTotals[2] < challengeGoal[2]) return;
                data.challengePoints += challengeReward[2];
                data.challengeCompletions[id]++;
                UpdateNumbers();
                ExitChallenge();
                UpdateCP();
                SelectChallenge(id);
                break;
            case 3:
                if (data.elementTotals[3] < challengeGoal[3]) return;
                data.challengePoints += challengeReward[3];
                data.challengeCompletions[id]++;
                UpdateNumbers();
                ExitChallenge();
                UpdateCP();
                break;
            case 4:
                if (data.elementTotals[4] < challengeGoal[4]) return;
                data.challengePoints += challengeReward[4];
                data.challengeCompletions[id]++;
                UpdateNumbers();
                ExitChallenge();
                UpdateCP();
                SelectChallenge(id);
                break;
            case 5:
                if (data.elementTotals[5] < challengeGoal[5]) return;
                data.challengePoints += challengeReward[5];
                data.challengeCompletions[id]++;
                UpdateNumbers();
                ExitChallenge();
                UpdateCP();
                break;
            case 6:
                if (data.elementTotals[0] < challengeGoal[6]) return;
                data.challengePoints += challengeReward[6];
                data.challengeCompletions[id]++;
                UpdateNumbers();
                ExitChallenge();
                UpdateCP();
                SelectChallenge(id);
                break;
            case 7:
                if (data.elementTotals[5] < challengeGoal[7]) return;
                data.challengePoints += challengeReward[7];
                data.challengeCompletions[id]++;
                UpdateNumbers();
                ExitChallenge();
                UpdateCP();
                SelectChallenge(id);
                break;

        }
    }

    public void ExitChallenge()
    {
        for(int i = 0; i < 8; i++)
        {
            isActive[i] = false;
        }
        challengeText.text = $"Not in a Challenge";
    }

    public void UpdateNumbers()
    {
        var data = GameManager.Instance.data;
        for (int i = 0; i < 8; i++)
        {
            if (i < 6)
                challengeGoal[i] = 500 * Pow(challengeGoalMult, data.challengeCompletions[i]);
            else
                challengeGoal[i] = 1e3 * Pow(challengeGoalMult, data.challengeCompletions[i]);
            challengeReward[i] = challengeRewardBase[i] * Pow(challengeRewardMult[i], data.challengeCompletions[i]);
        }
    }

    public void UpdateCP()
    {
        var data = GameManager.Instance.data;
        var cpBoost = 1.00 + Sqrt(Sqrt(data.challengePoints));
        cpBoostText.text = $"{Methods.NotationMethod(cpBoost, "F2")}x Boost";
        challengePointsText.text = $"{Methods.NotationMethod(data.challengePoints, "F2")} CP";
    }

    public BigDouble challengeModifier(int id)
    {
        var data = GameManager.Instance.data;
        BigDouble temp = 1;

        switch(id)
        {

            case 0:
                temp += .01 + (.01 * data.challengeCompletions[0]);
                break;
            case 1:
                temp += 2 + (2 * data.challengeCompletions[1]);
                break;
            case 2:
                temp += .1 + (.1 * data.challengeCompletions[2]);
                break;
            case 3:
                temp += 6 + (6 * data.challengeCompletions[3]);
                break;
            case 4:
                temp += .25 + (.25 * data.challengeCompletions[4]);
                break;
        }
        return temp;
    }
}
