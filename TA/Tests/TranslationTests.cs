﻿using NUnit.Allure.Attributes;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace TA.Tests
{
   [AllureSuite("Translation tests")]
    public class TranslationTests : BaseTest
    {

        private static IEnumerable<TestCaseData> TestData()
        {
            {
                {
                    yield return new TestCaseData("one", "один");
                    yield return new TestCaseData("two", "два");
                    yield return new TestCaseData("three", "три");
                }
            }
        }
       [Test, TestCaseSource("TestData")]
       [AllureTag("CI")]
       public void TranslationTest(string searchRequest, string result)
        { 
            Pages.Main.Search(searchRequest);
            //Assert.AreEqual(Pages.Main.GetTtanslationText(), result, "Translation faild");
            Assert.IsTrue(Pages.Main.Verification(1), "Pass");
        }

        [Test(Description = "Swap Languages Test")]
        [AllureTag("CI")]
        public void SwapLanguagesTest()
        {
            Pages.Main.Search("декілька");
            Pages.Main.SwapLangueges();
           // Assert.AreEqual(Pages.Main.GetTtanslationText(), "декілька", "Swap Languages button doesn't work appropriate");
            Assert.IsTrue(Pages.Main.Verification(0), "Failed");
        }
    }
}
