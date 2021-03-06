using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemToInventory : MonoBehaviour
{
    public BooksWithStats book;
    [SerializeField]
    private GameObject IntoPanel;
    LevelUpWithBook levelUpWithBook;
    [SerializeField]
    private GameObject BookUpPanel;
    private bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            playerInRange = true;
            IntoPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            playerInRange = false;
            IntoPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (!book.isLoot)
        {
            this.gameObject.SetActive(true);

            if (playerInRange)
            {
                TextVariantLanguageInteractivePanel textVariantLanguage = new TextVariantLanguageInteractivePanel();

                //IntoPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "Loot";
                IntoPanel.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = textVariantLanguage.PanelLoot();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    IntoPanel.SetActive(false);
                    playerInRange = false;
                    levelUpWithBook = new LevelUpWithBook();
                    levelUpWithBook.LevelUp(book);
                    book.isLoot = true;
                    AddIfoToLuttingPanel();
                }
            }
        }
        else
            this.gameObject.SetActive(false);
    }

    void AddIfoToLuttingPanel()
    {
        TextVariantLanguageScriptObject textVariantLanguage = new TextVariantLanguageScriptObject();

        BookUpPanel.SetActive(true);
        Text text = BookUpPanel.transform.GetChild(1).GetComponent<Text>();
        text.text = textVariantLanguage.BookLootLocalization(book);

        BinarySavingSystem.SavePlayerBook(book.name);

        Button button = BookUpPanel.transform.GetChild(2).GetComponent<Button>();
        button.onClick.AddListener(delegate { LottingPanelSetActiveFalse(); });

    }

    void LottingPanelSetActiveFalse()
    {
        BookUpPanel.SetActive(false);
        Destroy(this.gameObject);
    }
}
