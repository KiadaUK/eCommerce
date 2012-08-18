using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CumbriaMD.Infrastructure.ViewModels.DisplayAttributes
{
    public class MetadataProvider : DataAnnotationsModelMetadataProvider 
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes,
                                                         Type containerType,
                                                         Func<object> modelAccessor,
                                                         Type modelType,
                                                         string propertyName)
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            var additionalValues = attributes.OfType<Knockout>()
                .FirstOrDefault();

            if (additionalValues != null)
            {
                metadata.AdditionalValues.Add("Knockout", additionalValues);
            }

            return metadata;
        }
    }
}
