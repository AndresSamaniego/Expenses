using PersonalExpenses.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalExpenses.View.MarkupExtensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo cultureInfo = null;

        public string ResourceName { get; set; }

        static readonly Lazy<ResourceManager> resourceManager = 
            new Lazy<ResourceManager>(() => new ResourceManager("PersonalExpenses.Resources.AppResources", 
                IntrospectionExtensions.GetTypeInfo(typeof(TranslateExtension)).Assembly));

        public TranslateExtension()
        {
            cultureInfo = AppResources.Culture;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(ResourceName))
                return string.Empty;

            string value = resourceManager.Value.GetString(ResourceName, cultureInfo);

            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            return value;
        }
    }
}
