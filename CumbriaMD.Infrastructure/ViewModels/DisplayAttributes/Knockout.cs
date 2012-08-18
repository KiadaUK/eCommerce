using System;
using System.Collections.Generic;

namespace CumbriaMD.Infrastructure.ViewModels.DisplayAttributes
{
    public class Knockout : Attribute 
    {
        public string DataBind { get; set; }
        public string InputType { get; set; }

        public Knockout(string dataBind, string inputType)
        {
            this.DataBind = dataBind;
            this.InputType = inputType;
        }
        public Dictionary<string, object> OptionalAttributes()
        {
            var options = new Dictionary<string, object>();

            if(!string.IsNullOrWhiteSpace(DataBind))
            {
                options.Add("data-bind", DataBind);
            }

            if (!string.IsNullOrWhiteSpace(InputType))
            {
                options.Add("type", InputType);
            }
            return options;
        }
    }
}