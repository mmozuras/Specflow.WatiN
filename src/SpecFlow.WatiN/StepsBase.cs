using System;
using WatiN.Core;
using WatiN.Core.Constraints;

namespace SpecFlow.WatiN
{
    public class StepsBase
    {
        protected readonly Browser Browser;

        protected StepsBase()
        {
            Browser = WebBrowser.Current;
        }

        protected T UnsafeFindBy<T>(string value) where T : Element
        {
            return FindBy<T>(Find.ById(value)) ??
                   FindBy<T>(Find.ByName(value)) ??
                   FindBy<T>(Find.ByValue(value)) ??
                   FindBy<T>(Find.ByText(value)) ??
                   FindBy<T>(Find.ByLabelText(value));
        }
        
        protected T FindBy<T>(string value) where T : Element
        {
            var element = UnsafeFindBy<T>(value);
            if (element == null)
            {
                //TODO: Should probably be of a different exception type.
                throw new ApplicationException(string.Format("Could not find {0} \"{1}\"", typeof (T).Name, value));
            }
            return element;
        }

        T FindBy<T>(Constraint constraint) where T : Element
        {
            var element = Browser.ElementOfType<T>(constraint);
            return element.Exists ? element : null;
        }
    }
}