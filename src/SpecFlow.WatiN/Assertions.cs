using TechTalk.SpecFlow;
using WatiN.Core;

namespace SpecFlow.WatiN
{
    [Binding]
    public class Assertions : StepsBase
    {
        [Then("I should see \"(.*)\"")]
        public void See(string text)
        {
            Browser.Text.ShouldContain(text);
        }

        [Then("I should not see \"(.*)\"")]
        public void NotSee(string text)
        {
            Browser.Text.ShouldNotContain(text);
        }

        [Then("I should see a link to \"(.*)\"")]
        public void SeeLinkTo(string text)
        {
            Browser.Link(Find.ByText(text)).ShouldNotBeNull();
        }

        [Then("I should see a link to \"(.*)\" with the url (.*)")]
        public void SeeLinkToWithUrlTo(string text, string url)
        {
            Browser.Link(Find.ByUrl(url))
                .ShouldNotBeNull()
                .Text.ShouldEqual(text);
        }

        [Then("I should see a link that contains the text \"(.*)\" and the url (.*)")]
        public void SeeLinkThatContainsAndTheUrl(string text, string url)
        {
            Browser.Link(Find.ByUrl(url))
                .ShouldNotBeNull()
                .Text.ShouldContain(text);
        }

        [Then("I should see a link with the url \"(.*)\"")]
        public void SeeLinkWithUrlTo(string url)
        {
            Browser.Link(Find.ByUrl(url)).ShouldNotBeNull();
        }

        [Then("the browser's title should contain \"([^\"]*)\"")]
        public void BrowsersTitleShouldContain(string text)
        {
            Browser.Title.ShouldContain(text);
        }

        [Then("the browser's title should not contain \"([^\"]*)\"")]
        public void BrowsersTitleShouldNotContain(string text)
        {
            Browser.Title.ShouldNotContain(text);
        }

        [Then("the browser's URL should be (.*)")]
        [Then("I should be at (.*)")]
        public void BrowsersUrlShouldBe(string url)
        {
            Browser.Url.ShouldEqual(url);
        }

        [Then("the browser's URL should not be (.*)")]
        [Then("I should not be at (.*)")]
        public void BrowsersUrlShouldNotBe(string url)
        {
            Browser.Url.ShouldNotEqual(url);
        }

        [Then("the browser's URL should contain \"(.*)\"")]
        public void BrowsersUrlShouldContain(string url)
        {
            Browser.Url.ShouldContain(url);
        }

        [Then("the browser's URL should not contain \"(.*)\"")]
        public void BrowsersUrlShouldNotContain(string url)
        {
            Browser.Url.ShouldNotContain(url);
        }

        [Then("I should see an element with id of \"(.*)\"")]
        public void SeeAnElementWithId(string id)
        {
            Browser.Element(id).ShouldNotBeNull();
        }

        [Then("I should see a form that goes to \"(.*)\"")]
        public void SeeFormThatGoesTo(string url)
        {
            Browser.Form(Find.By("action", url)).ShouldNotBeNull();
        }

        [Then("I should not see an element with id of \"(.*)\"")]
        public void NotSeeAnElementWithId(string id)
        {
            Browser.Element(id).ShouldBeNull();
        }

        [Then("the element with id of \"(.*)\" contains \"(.*)\"")]
        public void ElementWithIdContains(string id, string text)
        {
            Browser.Element(id)
                .ShouldNotBeNull()
                .Text.ShouldContain(text);
        }

        [Then("the element with id of \"(.*)\" does not contain \"(.*)\"")]
        public void ElementWithIdDoesNotContain(string id, string text)
        {
            Browser.Element(id)
                .ShouldNotBeNull()
                .Text.ShouldNotContain(text);
        }

        [Then("the \"(.*)\" checkbox should be checked")]
        public void CheckboxShouldBeChecked(string text)
        {
            FindBy<CheckBox>(text).ShouldBeChecked();
        }

        [Then("the \"(.*)\" checkbox should not be checked")]
        public void CheckboxShouldNotBeChecked(string text)
        {
            FindBy<CheckBox>(text).ShouldNotBeChecked();
        }

        [Then("the \"(.*)\" option should be chosen")]
        public void OptionShouldBeChosen(string text)
        {
            FindBy<RadioButton>(text).ShouldBeChecked();
        }

        [Then("the \"(.*)\" option should not be chosen")]
        public void OptionShouldNotBeChosen(string text)
        {
            FindBy<CheckBox>(text).ShouldNotBeChecked();
        }
    }
}