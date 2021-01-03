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

using BreakInfinity;
using static BreakInfinity.BigDouble;
using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    #region Tier Stuff
    public BigDouble[] elementTotals = new BigDouble[26];
    public BigDouble[] generatorLevel = new BigDouble[6];
    public BigDouble[] generatorAmount = new BigDouble[6];
    #endregion
    #region Achievements
    public bool[] isAchievementUnlocked = new bool[8];
    #endregion

    public PlayerData()
    {
        elementTotals[0] = 10;
        for(int i = 0; i < elementTotals.Length - 1; i++)
        {
            elementTotals[i + 1] = 0;
        }
        for(int i = 0; i < 6; i++)
        {
            generatorLevel[i] = 0;
            generatorAmount[i] = 0;
        }
        for(int i = 0; i < 8; i++)
        {
            isAchievementUnlocked[i] = false;
        }
    }
}
