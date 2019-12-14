using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text No1, No2, Sign, Answer, Result;
    int num1, num2, mathSign;
    public UnityEngine.UI.InputField answerText;
    //create transaction result
    int mathResult;

    //create audios
    public AudioSource clap;
    public AudioSource groan;
    public AudioSource click;

    void Start()
    {
        NewQuestion();
    }

    public void AnswerControl()
    {
        if (int.Parse(Answer.text) == mathResult)
        {
            Result.text = "TRUE";
            //change true color
            Result.color = Color.green;
            //play clap audio when true answer
            clap.Play();
        }
        else
        {
            Result.text = "FALSE";
            //change false color
            Result.color = Color.red;
            //play groan audio when false answer
            groan.Play();
        }
    }

    public void NewQuestion()
    {
        //Empty the boxes when new question
        Result.text = "";
        answerText.text = "";
        //play click audio when click new question button
        click.Play();

        //create random numbers
        num1 = Random.Range(1, 10);
        num2 = Random.Range(1, 10);
        mathSign = Random.Range(1, 4);

        //create random colors
        GetComponent<GameController>().No1.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GetComponent<GameController>().No2.color = Random.ColorHSV(0f, 0.6f, 1f, 1f, 0.5f, 1f);
        GetComponent<GameController>().Sign.color = Random.ColorHSV(0f, 1f, 0.4f, 1f, 0.5f, 1f);
        GetComponent<GameController>().Answer.color = Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.5f, 1f);

        switch (mathSign)
        {
            case 1:
                Sign.text = "+";
                mathResult = num1 + num2;
                break;
            case 2:
	            Sign.text = "-";
	            if (num1 > num2)
	            {
	            	mathResult = num1 - num2;
	            }
	            else if(num1 < num2)
	            {
	            	int bigNumber = num1;
	            	num1 = num2;
	            	num2 = bigNumber;
	            	mathResult = num1 - num2;
	            }
	            break;
            case 3:
                Sign.text = "*";
                mathResult = num1 * num2;
                break;
            case 4:
                Sign.text = "/";
                mathResult = num1 / num2;
                break;
        }


        No1.text = num1 + "";
        No2.text = num2 + "";
    }

}
