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
    
    public bool isFusionUnlocked;
    public bool[] isUnlocked = new bool[5];
    public bool[] isAutoUnlocked = new bool[5];
    public BigDouble challengePoints;
    public BigDouble atomicMass;
    public BigDouble[] elementTotals = new BigDouble[6];
    public BigDouble[] challengeCompletions = new BigDouble[8];
    #region Generator Storage
    public BigDouble[] hydrogenLevels = new BigDouble[8];
    public BigDouble[] hydrogenAmounts = new BigDouble[8];

    public BigDouble[] heliumLevels = new BigDouble[8];
    public BigDouble[] heliumAmounts = new BigDouble[8];

    public BigDouble[] lithiumLevels = new BigDouble[8];
    public BigDouble[] lithiumAmounts = new BigDouble[8];

    public BigDouble[] berylliumLevels = new BigDouble[8];
    public BigDouble[] berylliumAmounts = new BigDouble[8];

    public BigDouble[] boronLevels = new BigDouble[8];
    public BigDouble[] boronAmounts = new BigDouble[8];

    public BigDouble[] carbonLevels = new BigDouble[8];
    public BigDouble[] carbonAmounts = new BigDouble[8];
    #endregion

    public PlayerData()
    {
        challengePoints = 0;
        atomicMass = 0;
        isFusionUnlocked = false;
        for (int i = 0; i < 5; i++)
        {
            isUnlocked[i] = false;
            isAutoUnlocked[i] = false;
        }
            
        for (int i = 0; i < elementTotals.Length - 1; i++)
            elementTotals[i + 1] = 0;
        elementTotals[0] = 10;
        #region Generators
        for (int i = 0; i < 8; i++)
        {
            hydrogenLevels[i] = 0;
            hydrogenAmounts[i] = 0;

            heliumLevels[i] = 0;
            heliumAmounts[i] = 0;

            lithiumLevels[i] = 0;
            lithiumAmounts[i] = 0;

            berylliumLevels[i] = 0;
            berylliumAmounts[i] = 0;

            boronLevels[i] = 0;
            boronAmounts[i] = 0;

            carbonLevels[i] = 0;
            carbonAmounts[i] = 0;
        }
        #endregion
    }
}
