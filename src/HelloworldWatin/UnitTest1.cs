using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WatiN.Core;

namespace HelloworldWatin {
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1 {
        public UnitTest1() {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [Page(UrlRegex="www.google.*")]
        public class GoogleSearchPage : Page {
            public TextField SearchCriteria {
                get { return Document.TextField(Find.ByName("q")); }
            }

            public Button SearchButton {
                get { return Document.Button(Find.ByName("btnG")); }
            }

            public void SearchFor(string searchCriteria) {
                SearchCriteria.TypeText(searchCriteria);
                SearchButton.Click();
            }
        }

        [TestMethod]
        public void Page_With_An_Action() {
            using (var browser = new IE("http://www.google.com")) {
                browser.Page<GoogleSearchPage>().SearchFor("Robby");

                Assert.IsTrue(browser.ContainsText("Robby"));
            }
        }


        [TestMethod]
        public void SearchForWatiNOnGoogle() {
            using (var browser = new IE("http://www.google.com")) {
                browser.TextField(Find.ByName("q")).TypeText("WatiN");
                browser.Button(Find.ByName("btnG")).Click();

                Assert.IsTrue(browser.ContainsText("WatiN"));
            }
        }
    }
}
