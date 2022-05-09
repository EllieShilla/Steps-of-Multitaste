using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleResultShow : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool GoodEnd = false;
    public static bool EndBattle = false;

    void Start()
    {
        if (GoodEnd)
        {
            this.transform.GetChild(0).GetComponent<Text>().text = "MONEY: " + GroupCoin.coin;

            AddInventoryToObj inventorySctiptObj = GameObject.Find("InventoryGameObject").GetComponent<AddInventoryToObj>();
            inventorySctiptObj.inventoryObj.money += GroupCoin.coin;
            EndBattle = false;
        }
        else
        {
            this.transform.GetChild(0).GetComponent<Text>().text = "You couldn't handle the hungry customers.";
            EndBattle = false;
        }

    }

    public void CloseScene()
    {
        SaveScriptBeforeFight ReturnFromFightScene = GameObject.Find("ReturnFromFightScene").GetComponent<SaveScriptBeforeFight>();
        ReturnFromFightScene.SceneLoad();
        SceneManager.UnloadSceneAsync("FightScene");
    }

}