using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace hw_classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string text = "Дано текст (взяти любий з інтернету). Визначити 3 символи, що найчастіше (зустрічаються) в ньому. Пробіли слід ігнорувати (не враховувати при підрахунку). Для результатів обчислень потрібно написати функцію.";

            CountSumbStr count = new CountSumbStr(text);
            count.CounterSumbolInString();
            CaseChange caseChange = new CaseChange(text);
            Console.WriteLine(caseChange.CaseChangeResult());
            CutClarification cutCl = new CutClarification(text);
            Console.WriteLine(cutCl.CutClarificationResult());

            string one = "Привет мир";
            string two = "Прим";
            Check ch = new Check(one, two);
            Console.WriteLine(ch.CheckOccurrence());

            Console.ReadLine();
            
        }
    }
    #region Класс подсчета количества символов
    public class CountSumbStr
    {
        private string _text;
        public CountSumbStr(string text) 
        { 
            this._text = text;
        }
        public string Text
        {
            get
            {
                return _text;
            }
        }
        public void CounterSumbolInString()
        {
            string newMyStr = Text.Replace(" ", "");
            int temp = 0;
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
            foreach (var item in newMyStr)
            {
                if (!keyValuePairs.ContainsKey(item))
                    keyValuePairs.Add(item, 1);
                else keyValuePairs[item]++;
            }
            var sortedDict = keyValuePairs.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            //Как вывести первые 3 элемента не зная ключи так и не разобрался
            foreach (var kvp in sortedDict.Reverse())
                Console.WriteLine($"Key = {kvp.Key}, Value = {kvp.Value}");
        }
    }
    #endregion
    #region Класс смены регистров
     class CaseChange
    {
        private string _text;
        public CaseChange(string text) 
        { 
            this._text= text;
        }
        public string Text
        {
            get { return _text; }
        }
        public string CaseChangeResult()
        {
            string[] words = Text.Split();
            string newWord = char.ToLower(words[0][0]) + words[0].Substring(1, words[0].Length - 1) + " ";
            for (int i = 1; i < words.Length; i++)
            {
                if (i % 2 == 1)
                {
                    newWord += char.ToUpper(words[i][0]) + words[i].Substring(1, words[i].Length - 1) + " ";
                }
                else
                {
                    newWord += char.ToLower(words[i][0]) + words[i].Substring(1, words[i].Length - 1) + " ";
                }
            }
            return newWord;
        }
    }
    #endregion
    #region Класс выреза текста в скобках
    class CutClarification
    {
        private string _text;
        public CutClarification(string text)
        {
            this._text = text;
        }
        public string Text
        {
            get { return _text; }
        }

        public string CutClarificationResult()
        {
            string resultString = string.Empty;
            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] == '(')
                {
                    int a = Text.IndexOf("(", i);
                    int b = Text.IndexOf(")", a) - i + 1;
                    resultString += Text.Substring(a, b);

                }

            }
            return resultString;
        }
    }
    #endregion
    #region Класс проверки вхождения слова в строку
    class Check
    {
        public Check(string text, string word)
        {
            this.Text = text;
            this.Word = word;
        }
        public string Text { get;}
        public string Word { get;}
        public bool CheckOccurrence()
        {
            string temp = Text.Replace(" ", "");
            char[] mas = new char[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                mas[i] = temp[i];
            }
            HashSet<char> hs = new HashSet<char>();
            foreach (var item in mas)
                hs.Add(item);
            string t = "";
            foreach (var item in hs)
            {
                t += item;
            }
            char[] resMas = new char[t.Length];
            for (int i = 0; i < t.Length; i++)
            {
                resMas[i] = t[i];
            }
            bool result = false;
            string tempResult = string.Empty;
            for (int i = 0; i < Word.Length; i++)
            {
                for (int j = 0; j < resMas.Length; j++)
                {
                    if (Word[i] == resMas[j])
                        tempResult += Word[i];
                    if (tempResult.Length == Word.Length)
                        result = true;
                }
            }
            return result;
        }
    }
    #endregion
}

