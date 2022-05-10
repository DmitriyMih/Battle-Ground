using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelItem : MonoBehaviour
{
    public List<GameObject> panels = new List<GameObject>();
    public int lastPanelID = -1;

    public void OpenPanel(int panelNumber)
    {
        if (panels.Count == 0 || lastPanelID == panelNumber)
            return;

        panelNumber = Mathf.Clamp(panelNumber, 0, panels.Count);

        foreach (var panel in panels)
            panel.SetActive(false);

        panels[panelNumber].SetActive(true);
        lastPanelID = panelNumber;
    }


}
