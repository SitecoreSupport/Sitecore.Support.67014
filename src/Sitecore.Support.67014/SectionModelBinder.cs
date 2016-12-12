using Sitecore.Forms.Mvc.Data.Wrappers;
using Sitecore.Forms.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Sitecore.Support.Forms.Mvc.Controllers.ModelBinders
{
    public class SectionModelBinder : Sitecore.Forms.Mvc.Controllers.ModelBinders.SectionModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            FormViewModel formViewModel = this.GetFormViewModel(controllerContext);
            if (formViewModel != null)
            {
                int num = int.Parse(bindingContext.ModelName.Substring(bindingContext.ModelName.IndexOf('[') + 1, (bindingContext.ModelName.IndexOf(']') - bindingContext.ModelName.IndexOf('[')) - 1));
                return formViewModel.Sections[num];
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
}
