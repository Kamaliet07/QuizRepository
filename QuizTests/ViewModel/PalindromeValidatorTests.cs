using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.ViewModel.Tests
{
    [TestClass()]
    public class PalindromeValidatorTests
    {
        [TestMethod()]
        public void PalindromeDeterminerTest1()
        {
            // Created test data and store it into string
            string strPalindrom = "Able was I ere I saw Elba";
            
            // check status whether strinng (value) is pelindrome.
            bool isPalindrome = PalindromeValidator.PalindromeDeterminer(strPalindrom);
            Assert.AreEqual(isPalindrome, true);
        }

        [TestMethod()]
        public void PalindromeDeterminerTest2()
        {
            // Created test data and store it into string
            string strPalindrom = "This is Palindrome String";
           
            // check status whether strinng (value) is pelindrome.
            bool isPalindrome = PalindromeValidator.PalindromeDeterminer(strPalindrom);
            Assert.AreEqual(isPalindrome, false);
        }

        [TestMethod()]
        public void PalindromeDeterminerTest3()
        {
            // Created test data and store it into string array
            string[] array =
            {
            "Ford",
            "Airlines",
            "dewed",
            "Hannah",
            "kayak",            
            };

            // Foreach string method will check whether it is Pelindrome or not.
            foreach (string value in array)
            {
                // check status whether strinng (value) is pelindrome.
                bool isPalindrome = PalindromeValidator.PalindromeDeterminer(value);
                Console.WriteLine("{0} = {1}", value, isPalindrome);
            }
        }

        [TestMethod()]
        public void PalindromeDeterminerTest4()
        {
            // Created test data and store it into string array
            string[] array =
            {            
            "Honda",
            "level",
            "madam",
            "racecar",
            "radar",
            "civic",            
            };

            // Foreach string method will check whether it is Pelindrome or not.
            foreach (string value in array)
            {
                // check status whether strinng (value) is pelindrome.
                bool isPalindrome = PalindromeValidator.PalindromeDeterminer(value);
                Console.WriteLine("{0} = {1}", value, isPalindrome);
            }
        }

        [TestMethod()]
        public void PalindromeDeterminerTest5()
        {
            // Created test data and store it into string array
            string[] array =
            {            
            "string",
            "redder",
            "refer",
            "repaper",
            "reviver",
            "rotator",
            "array",            
            };

            // Foreach string method will check whether it is Pelindrome or not.
            foreach (string value in array)
            {
                // check status whether strinng (value) is pelindrome.
                bool isPalindrome = PalindromeValidator.PalindromeDeterminer(value);
                Console.WriteLine("{0} = {1}", value, isPalindrome);
            }
        }

        [TestMethod()]
        public void PalindromeDeterminerTest6()
        {
            // Created test data and store it into string array
            string[] array =
            {           
            "rotor",
            "sagas",
            "deleveled",
            "solos",
            "sexes",
            "devoved",
            "stats",
            "tenet",
            "Perls",
            "A",
            "Palindrome",
            };

            // Foreach string method will check whether it is Pelindrome or not.
            foreach (string value in array)
            {
                // check status whether strinng (value) is pelindrome.
                bool isPalindrome = PalindromeValidator.PalindromeDeterminer(value);
                Console.WriteLine("{0} = {1}", value, isPalindrome);
            }
        }

        [TestMethod()]
        public void AMethodTest()
        {
            bool firstInput = true;
            bool secondInput = true;
            bool thirdInput = false;
            // Create object of the class
            MethodSimplification objSimMeth = new MethodSimplification();
            // Excuting method to get return type
            string returnout = objSimMeth.AMethod(firstInput, secondInput, thirdInput);
            Assert.AreEqual(returnout, "Option2");
        }

        [TestMethod()]
        public void AMethodTest2()
        {
            bool firstInput = false;
            bool secondInput = true;
            bool thirdInput = false;
            // Create object of the class
            MethodSimplification objSimMeth = new MethodSimplification();
            // Excuting method to get return type
            string returnout = objSimMeth.AMethod(firstInput, secondInput, thirdInput);
            Assert.AreEqual(returnout, "Option2");
        }
    }
}