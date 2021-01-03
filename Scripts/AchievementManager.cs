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


public class AchievementManager : MonoBehaviour
{
    public Image[] achievementBG = new Image[8];
    public static AchievementManager Instance;
    public Color lockedColor;
    public Color unlockedColor;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for(int i = 0; i < 8; i++)
        {
            achievementBG[i].color = lockedColor;
        }
    }

    private void Update()
    {
        var data = GameManager.Instance.data;
        Conditions();
        for (int i = 0; i < 8; i++)
        {
            if (data.isAchievementUnlocked[i])
                achievementBG[i].color = unlockedColor;
        }
    }

    private void Conditions()
    {
        var data = GameManager.Instance.data;

        if (data.elementTotals[5] >= 1e20 && !data.isAchievementUnlocked[0])
            data.isAchievementUnlocked[0] = true;
        if (data.elementTotals[11] >= 1e20 && !data.isAchievementUnlocked[1])
            data.isAchievementUnlocked[1] = true;
        if (data.elementTotals[17] >= 1e20 && !data.isAchievementUnlocked[2])
            data.isAchievementUnlocked[2] = true;
        if (data.elementTotals[23] >= 1e20 && !data.isAchievementUnlocked[3])
            data.isAchievementUnlocked[3] = true;
        if (data.elementTotals[25] >= 1e20 && !data.isAchievementUnlocked[4])
            data.isAchievementUnlocked[4] = true;
        //More Soon
    }
}
