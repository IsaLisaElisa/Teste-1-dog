using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLevelManager : MonoBehaviour
{
    void Update()
    {
        void ShowCJPanel() {
        uiComponents.CJPanel.panel.SetActive(true);
    }
        void ShowCreditosPanel() {
        uiComponents.CreditosPanel.panel.SetActive(true);
    }
    }
}
