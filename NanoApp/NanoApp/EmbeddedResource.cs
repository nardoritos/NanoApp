using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NanoApp
{
    public class EmbeddedResource : IMarkupExtension
    {
        public string ResourceID { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrWhiteSpace(ResourceID))
                return null;
            return ImageSource.FromResource(ResourceID);
        }
    }
}
