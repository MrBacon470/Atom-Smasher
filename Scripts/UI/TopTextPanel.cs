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

public class TopTextPanel : MonoBehaviour
{
    public Text currentElementText;
    public Text progressText;

    public static TopTextPanel Instance;

    public void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        currentElement();
    }


    public void currentElement()
    {
        var data = GameManager.Instance.data;
        var hydrogen = data.elementTotals[0];
        var helium = data.elementTotals[1];
        var lithium = data.elementTotals[2];
        var beryllium = data.elementTotals[3];
        var boron = data.elementTotals[4];
        var carbon = data.elementTotals[5];
        if (GameManager.Instance.isSelected[0])
        {
            currentElementText.text = $"{Methods.NotationMethod(hydrogen, "F2")} Hydrogen";
            progressText.text = (hydrogen / 1e10) * 100 >= 100 ? "Helium Avalible" : $"{Methods.NotationMethod((hydrogen / 1e10) * 100, "F2")}% to Helium";
        }
        else if (GameManager.Instance.isSelected[1])
        {
            currentElementText.text = $"{Methods.NotationMethod(helium, "F2")} Helium";
            progressText.text = (helium / 1e12) * 100 >= 100 ? "Lithium Avalible" : $"{Methods.NotationMethod((helium / 1e12) * 100, "F2")}% to Lithium";
        }
        else if (GameManager.Instance.isSelected[2])
        {
            currentElementText.text = $"{Methods.NotationMethod(lithium, "F2")} Lithium";
            progressText.text = (lithium / 1e14) * 100 >= 100 ? "Beryllium Avalible" : $"{Methods.NotationMethod((lithium / 1e14) * 100, "F2")}% to Beryllium";
        }
        else if (GameManager.Instance.isSelected[3])
        {
            currentElementText.text = $"{Methods.NotationMethod(beryllium, "F2")} Beryllium";
            progressText.text = (beryllium / 1e16) * 100 >= 100 ? "Boron Avalible" : $"{Methods.NotationMethod((beryllium / 1e16) * 100, "F2")}% to Boron";
        }
        else if (GameManager.Instance.isSelected[4])
        {
            currentElementText.text = $"{Methods.NotationMethod(boron, "F2")} Boron";
            progressText.text = (boron / 1e18) * 100 >= 100 ? "Carbon Avalible" : $"{Methods.NotationMethod((boron / 1e18) * 100, "F2")}% to Carbon";
        }
        else if (GameManager.Instance.isSelected[5])
        {
            currentElementText.text = $"{Methods.NotationMethod(carbon, "F2")} Carbon";
            progressText.text = $"?????";
        }
    }
}
