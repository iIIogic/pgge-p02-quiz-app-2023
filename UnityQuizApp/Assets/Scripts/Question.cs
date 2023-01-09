using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public string id;
    public string question;
    public List<string> choices = new List<string>();
    public int correctAnswerid;
    public string catergory;

    //The below function is for testing. We are hardcoding a set 5 question.

    static public List<Question> CreateQuestions()
    {
        List<Question> questions = new List<Question>();

        Question q1 = new Question();
        q1.id = "1";
        q1.question = "What is the capital of Malaysia";
        q1.choices.Add("Bangkok");
        q1.choices.Add("Singapore");
        q1.choices.Add("Kuala Lumpur");
        q1.choices.Add("Hanoi");
        q1.catergory = "Geography";
        q1.correctAnswerid = 2;

        Question q2 = new Question();
        q2.id = "2";
        q2.question = "How many islands are there in Singapore";
        q2.choices.Add("4");
        q2.choices.Add("16");
        q2.choices.Add("19985");
        q2.choices.Add("64");
        q2.catergory = "Trivia";
        q2.correctAnswerid = 3;

        Question q3 = new Question();
        q3.id = "3";
        q3.question = "What is square root of 144";
        q3.choices.Add("12");
        q3.choices.Add("13");
        q3.choices.Add("14");
        q3.choices.Add("11");
        q3.catergory = "Math";
        q3.correctAnswerid = 0;

        Question q4 = new Question();
        q4.id = "4";
        q4.question = "Whose nose grow longer when they lied?";
        q4.choices.Add("Peanutchio");
        q4.choices.Add("Pinnochio");
        q4.choices.Add("Harry Porter");
        q4.choices.Add("Cinderella");
        q4.catergory = "Trivia";
        q4.correctAnswerid = 1;

        Question q5 = new Question();
        q5.id = "4";
        q5.question = "Who is the authoer of Pride and Prejudice";
        q5.choices.Add("J K Rowling");
        q5.choices.Add("JRR Tolkein");
        q5.choices.Add("Barrack Obama");
        q5.choices.Add("Jane Austen");
        q5.catergory = "Trivia";
        q5.correctAnswerid = 3;

        return questions;

    }
}
