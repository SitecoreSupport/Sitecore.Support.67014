using System.Web.Mvc;
using Sitecore.Forms.Mvc.ViewModels;
using System;

namespace Sitecore.Support.Forms.Mvc.Controllers.ModelBinders
{
    [ModelBinder(typeof(SectionModelBinder))]
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