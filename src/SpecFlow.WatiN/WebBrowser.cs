using TechTalk.SpecFlow;
using WatiN.Core;

namespace SpecFlow.WatiN
{
    [Binding]
    public static class WebBrowser
    {
        const string key = "browser";

        public static Browser Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey(key))
                {
                    ScenarioContext.Current[key] = new IE();
                }
                return (Browser)ScenarioContext.Current[key];
            }
        }

        [AfterScenario]
        public static void Close()
        {
            if (ScenarioContext.Current.ContainsKey(key))
            {
                Current.Close();
            }
        }
    }
}