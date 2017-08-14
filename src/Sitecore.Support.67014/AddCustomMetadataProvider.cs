namespace Sitecore.Support.Forms.Mvc.Pipelines.Initialize
{
  using Sitecore.Diagnostics;
  using Sitecore.Forms.Mvc;
  using Sitecore.Forms.Mvc.Controllers.ModelBinders;
  using Sitecore.Forms.Mvc.ViewModels;
  using Sitecore.Pipelines;
  using System.Web.Mvc;
  public class AddCustomMetadataProvider
    {
        [UsedImplicitly]
        public virtual void Process(PipelineArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            ModelMetadataProviders.Current = new PipelineBasedDataAnnotationsModelMetadataProvider();
            ModelBinders.Binders.Add(typeof(SectionViewModel), new Sitecore.Support.Forms.Mvc.Controllers.ModelBinders.SectionModelBinder());
            ModelBinders.Binders.Add(typeof(FieldViewModel), new FieldModelBinder());
        }
    }
}
