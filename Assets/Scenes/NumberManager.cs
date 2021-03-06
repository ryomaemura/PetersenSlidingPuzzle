using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText1;
    [SerializeField] TextMeshProUGUI buttonText2;
    [SerializeField] TextMeshProUGUI buttonText3;
    [SerializeField] TextMeshProUGUI buttonText4;
    [SerializeField] TextMeshProUGUI buttonText5;
    [SerializeField] TextMeshProUGUI buttonText6;
    [SerializeField] TextMeshProUGUI buttonText7;
    [SerializeField] TextMeshProUGUI buttonText8;
    [SerializeField] TextMeshProUGUI buttonText9;
    [SerializeField] TextMeshProUGUI buttonText10;
    [SerializeField] TextMeshProUGUI scoreLabel;
    TextMeshProUGUI[] buttonTexts;
    int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
    int[, ] relasionshipNumbers = {
    //   1  2  3  4  5  6  7  8  9  10
        {0, 1, 1, 1, 0, 0, 0, 0, 0, 0},
        {1, 0, 0, 0, 0, 0, 1, 1, 0, 0},
        {1, 0, 0, 0, 1, 0, 0, 0, 1, 0},
        {1, 0, 0, 0, 0, 1, 0, 0, 0, 1},
        {0, 0, 1, 0, 0, 1, 0, 1, 0, 0},

        {0, 0, 0, 1, 1, 0, 1, 0, 0, 0},
        {0, 1, 0, 0, 0, 1, 0, 0, 1, 0},
        {0, 1, 0, 0, 1, 0, 0, 0, 0, 1},
        {0, 0, 1, 0, 0, 0, 1, 0, 0, 1},
        {0, 0, 0, 1, 0, 0, 0, 1, 1, 0},
    };
    int temp = 0;
    int randomNumber = 0;
    int scoreNumber = 0;

    // Start is called before the first frame update
    void Start() {
        buttonTexts = new TextMeshProUGUI[] {buttonText1, buttonText2, buttonText3, buttonText4, buttonText5, buttonText6, buttonText7, buttonText8, buttonText9, buttonText10};

        resetNumbers();
        scoreReload();
    }

    // Update is called once per frame
    void Update() {
    }

    public void clickButton(int number) {
        for (int i = 0; i < numbers.Length; i++) {
            if (relasionshipNumbers[number - 1, i] == 1 && numbers[i] == 0) {
                temp = numbers[number - 1];
                numbers[number - 1] = numbers[i];
                numbers[i] = temp;

                buttonTexts[number - 1].text = "";
                buttonTexts[i].text = numbers[i].ToString();

                scoreNumber = scoreNumber + 1;
                scoreReload();
            }
        }
    }

    public void scoreReload() {
        scoreLabel.text = "Move:" + scoreNumber.ToString();
    }

    public void resetNumbers() {
        for (int i = 1; i < 100; i++) {
            // random 1 ~ 10
            randomNumber = UnityEngine.Random.Range(1, 11);
            clickButton(randomNumber);
        }

        for (int i = 0; i < numbers.Length; i++) {
            if (numbers[i] != 0) {
                buttonTexts[i].text = numbers[i].ToString();
            } else {
                buttonTexts[i].text = "";
            }
        }

        scoreNumber = 0;
        scoreReload();
    }
}
