using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CUT
{
    /// <summary>
    /// IsAllowableSentence() metod from SentenceValidator class verifies 
    /// if a given sentence contains not allowable words. 
    /// In order to do that it calls IsForbidden()method from FileWordValidator class, 
    /// which takes a list of forbidden words from file. 
    /// Remove dependency of these classes using Stub and Fake 
    /// and write a test for IsAllowableSentence() metod.
    /// 
    /// </summary>
    public class FileWordValidator
    {
        // the content of file 
        private List<string> _content;

        // file contains a list of forbidden words
        private string _fileName = "ForbiddenWords.txt";  
        public FileWordValidator()
        {
            this._content = File.ReadLines(this._fileName).ToList();
        }

        public bool IsForbidden(string word)
        {
            // if the word is in this file, this word is forbidden
            return this._content.Any(s => word.ToUpper().Contains(s));
        }
    }
    public class SentenceValidator
    {
        private FileWordValidator _wordValidator;
        public SentenceValidator()
        {
            this._wordValidator = new FileWordValidator();
        }
        public bool IsAllowableSentance(string sentence)
        {
            // separate all words
            string[] wordArray = Regex.Split(sentence, @"\W+"); 

            // try to find forbidden word
            foreach (string word in wordArray)
            {
                if (this._wordValidator.IsForbidden(word))
                {
                    // forbidden word was found - the sentence is not allowable
                    return false;
                }
            }

            // we didn't find forbidden words - the sentence is allowable
            return true;
        }
    }

    // after refactoring
    public interface IWordValidator
    {
        bool IsForbidden(string word);
    }

    public class SentenceValidator_Refactored
    {
        private IWordValidator _wordValidator;
        //public SentenceValidator_Refactored()
        //{
        //    this._wordValidator = new FileWordValidator();
        //}

        public SentenceValidator_Refactored(IWordValidator wordValidator)
        {
            this._wordValidator = wordValidator;
        }
        public bool IsAllowableSentance(string sentence)
        {
            // separate all words
            string[] wordArray = Regex.Split(sentence, @"\W+"); 

            // try to find forbidden word
            foreach (string word in wordArray)
            {
                if (this._wordValidator.IsForbidden(word))
                {
                    // forbidden word was found - the sentence is not allowable
                    return false;
                }
            }

            // we didn't find forbidden words - the sentence is allowable
            return true;
        }
    }

}
