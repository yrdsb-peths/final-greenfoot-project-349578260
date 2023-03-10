using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/*
 * The parent class for all inherited members to derive from
 * Houses information for card and attack statistics
 */

public class BaseCard : MonoBehaviour
{
    [SerializeField] public ScriptableCard card;

    [SerializeField] public Image cardBorder;

    [SerializeField] public Text nameText;
    [SerializeField] public Text descriptionText;
    [SerializeField] public Text damageText;
    [SerializeField] public Text rangeText;

    [SerializeField] public GameObject shotPrefab;

    // Set scriptable object data to the objects 
    private void Start()
    {
        cardBorder.sprite = card.cardImage;
        nameText.text = card.cardName;
        descriptionText.text = card.description;
        damageText.text = card.damage.ToString();
        rangeText.text = card.range.ToString();
        shotPrefab = card.shotPrefab;
    }

    // Code that runs on selection of any card
    public void SelectedCard()
    { 
        if (GameManager.Instance.State != GameState.PlayerTurn) return;

        if (UnitManager.Instance.SelectedPlayer != null && !CardManager.Instance.hasShot)
        {
            CardManager.Instance.SetSelectedCard(this);
            CardManager.Instance.SetCanShoot(true);
            MenuManager.Instance.ShowSelectedCard(this);
        }
    }

}
