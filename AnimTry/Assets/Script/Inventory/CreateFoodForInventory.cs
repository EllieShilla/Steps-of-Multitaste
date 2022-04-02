using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateFoodForInventory : MonoBehaviour
{
    public List<GameObject> DisplayBox;
    public GameObject PassBox;
    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;
    public string[] abc = new string[4] {"W","A","D","S" };
    bool isPass=true;
    int CurrentCountofButton;


    private void Start()
    {
        CurrentCountofButton = Random.Range(1, 7);
    }
    private void Update()
    {
        Result();

        if (CurrentCountofButton>0 && isPass)
        {
            if (WaitingForKey == 0)
            {
                QTEGen = Random.Range(0, 4);
                CountingDown = 1;
                StartCoroutine(CountDown());

                WaitingForKey = 1;
                OutLetter(QTEGen);
            }

            PressAnalyisis(QTEGen);
        }
    }

    void OutLetter(int numLetter)
    {
        switch (QTEGen)
        {
            case 0:
                DisplayBox[0].GetComponent<Text>().text = "[" + abc[QTEGen] + "]";
                break;
            case 1:
                DisplayBox[1].GetComponent<Text>().text = "[" + abc[QTEGen] + "]";
                break;
            case 2:
                DisplayBox[2].GetComponent<Text>().text = "[" + abc[QTEGen] + "]";
                        break;
            case 3:
                DisplayBox[3].GetComponent<Text>().text = "[" + abc[QTEGen] + "]";
                break;
        }
    }

    void Result()
    {
        if (CurrentCountofButton == 0)
        {
            PassBox.GetComponent<Text>().text = "�� ����������� �������� �����";

        }
        if (!isPass)
        {
            PassBox.GetComponent<Text>().text = "����� �� �������!";

        }
    }

    void PressAnalyisis(int numLetter)
    {
        switch (numLetter)
        {
            case 0:
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.W))
                        CorrectKey = 1;
                    else
                        CorrectKey = 2;

                    StartCoroutine(KeyPressing());
                }
                break;
            case 1:
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.A))
                        CorrectKey = 1;
                    else
                        CorrectKey = 2;

                    StartCoroutine(KeyPressing());
                }
                break;
            case 2:
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.D))
                        CorrectKey = 1;
                    else
                        CorrectKey = 2;

                    StartCoroutine(KeyPressing());
                }
                break;
            case 3:
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.S))
                        CorrectKey = 1;
                    else
                        CorrectKey = 2;

                    StartCoroutine(KeyPressing());
                }
                break;
        }
    }

    IEnumerator KeyPressing()
    {
        QTEGen = 4;

        switch (CorrectKey)
        {
            case 1:
                CountingDown = 2;
                PassBox.GetComponent<Text>().text = "PASS!";
                CurrentCountofButton-=1;
                yield return new WaitForSeconds(1.5f);
                CorrectKey = 0;
                PassBox.GetComponent<Text>().text = "";

                DisplayNull();

                yield return new WaitForSeconds(1.5f);
                WaitingForKey = 0;
                CountingDown = 1;
                break;
            case 2:
                CountingDown = 2;
                PassBox.GetComponent<Text>().text = "FAIL!";
                isPass = false;
                yield return new WaitForSeconds(1.5f);
                CorrectKey = 0;
                PassBox.GetComponent<Text>().text = "";

                DisplayNull();

                yield return new WaitForSeconds(1.5f);
                WaitingForKey = 0;
                CountingDown = 1;
                break;
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1f);
        if (CountingDown == 1)
        {
            QTEGen = 4;
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "FAIL!";
            isPass = false;
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";

            DisplayNull();

            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

    void DisplayNull()
    {
        foreach(var disp in DisplayBox)
        disp.GetComponent<Text>().text = "";
    }
}
