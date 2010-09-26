using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using WatiN.Core;
using WatiN.Core.DialogHandlers;
using Button = WatiN.Core.Button;
using CheckBox = WatiN.Core.CheckBox;
using RadioButton = WatiN.Core.RadioButton;

namespace SpecFlow.WatiN
{
    [Binding]
    public class Steps : StepsBase
    {
        [Given("I go to (.*)"), Given("I visit (.*)")]
        [When("I go to (.*)"), When("I visit (.*)")]
        public void GoTo(string url)
        {
            Browser.GoTo(url);
        }

        [Given("I click \"(.*)\"")]
        [When("I click \"(.*)\"")]
        public void Click(string text)
        {
            FindBy<Link>(text).Click();
        }

        [Given("I click \"(.*)\" and confirm the popup")]
        [When("I click \"(.*)\" and confirm the popup")]
        public void ClickAndConfirm(string text)
        {
            var link = FindBy<Link>(text);
            StartClicker(link);
        }

        [Given("I press \"(.*)\" and confirm the popup")]
        [When("I press \"(.*)\" and confirm the popup")]
        public void PressAndConfirm(string value)
        {
            var button = FindBy<Button>(value);
            StartClicker(button);
        }

        void StartClicker(Element element)
        {
            //TODO: Doesn't work. Can't figure out why...
            var dialogHandler = new ConfirmDialogHandler();
            using (new UseDialogOnce(Browser.DialogWatcher, dialogHandler))
            {
                element.ClickNoWait();
                dialogHandler.WaitUntilExists(5);
                dialogHandler.OKButton.Click();
                Browser.WaitForComplete();
            }
        }

        [Given("I press \"(.*)\"")]
        [When("I press \"(.*)\"")]
        public void Press(string value)
        {
            FindBy<Button>(value).Click();
        }

        [Given("I press Enter")]
        [When("I press Enter")]
        public void PressEnter()
        {
            SendKeys.SendWait("{ENTER}");
        }

        [Given("I fill in \"([^\"]*)\" with \"([^\"]*)\"")]
        [When("I fill in \"([^\"]*)\" with \"([^\"]*)\"")]
        public void FillIn(string field, string value)
        {
            FindBy<TextField>(field).TypeText(value);
        }

        [Given("I select \"(.*)\" from \"(.*)\"")]
        [When("I select \"(.*)\" from \"(.*)\"")]
        public void SelectFrom(string text, string name)
        {
            FindBy<SelectList>(name).Select(text);
        }

        [Given("I see \"(.*)\"")]
        [When("I see \"(.*)\"")]
        public void See(string text)
        {
            Browser.Text.ShouldContain(text);
        }

        [Given("I check \"(.*)\"")]
        [When("I check \"(.*)\"")]
        public void Check(string text)
        {
            var checkBox = FindBy<CheckBox>(text);
            if (!checkBox.Checked)
            {
                checkBox.Click();
            }
        }

        [Given("I uncheck \"(.*)\"")]
        [When("I uncheck \"(.*)\"")]
        public void Uncheck(string text)
        {
            var checkBox = FindBy<CheckBox>(text);
            if (checkBox.Checked)
            {
                checkBox.Click();
            }
        }

        [Given("I choose \"(.*)\"")]
        [When("I choose \"(.*)\"")]
        public void Choose(string text)
        {
            FindBy<RadioButton>(text).Click();
        }

        [Given("I wait (\\d+) seconds")]
        [When("I wait (\\d+) seconds")]
        public void Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        //TODO:
        // When I click the "Apply now" image (using alt text)
        // When I do something (press button) and wait 5 seconds
        // Then I should see a div with id "x"
        // Given I Wait until I see something (div with id etc."
        // When I attach the file at "path" to "file field"
        // When I move the mouse over the div containing "more information" (and other JS events)
    }
}