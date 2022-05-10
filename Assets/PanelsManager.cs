using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsManager : MonoBehaviour
{
    public static PanelsManager panelsManager;

    public GameObject mainPanel;
    public GameObject closedButton;

    public List<PanelItem> panels = new List<PanelItem>();
    private int lastPanelID = -1;


    public void Awake()
    {
        panelsManager = this;
    }

    public void OpenPanel(int panelNumber)
    {
        if (panels.Count == 0 || lastPanelID == panelNumber)
            return;

        mainPanel.SetActive(true);
        closedButton.SetActive(true);

        panelNumber = Mathf.Clamp(panelNumber, 0, panels.Count - 1);
        Debug.Log("Number " + panelNumber + " | Count " + panels.Count);

        foreach (var panel in panels)
            panel.gameObject.SetActive(false);

        PanelItem currentPanel = panels[panelNumber];
        currentPanel.gameObject.SetActive(true);
        currentPanel.OpenPanel(currentPanel.lastPanelID);

        lastPanelID = panelNumber;
    }

    public void ClosedAllPanels()
    {
        mainPanel.SetActive(false);
        closedButton.SetActive(false);

        foreach (var panel in panels)
        {
            panel.lastPanelID = -1;
            panel.gameObject.SetActive(false);
        }

        lastPanelID = -1;
    }
}
