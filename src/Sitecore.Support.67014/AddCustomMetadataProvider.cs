using Sitecore;
using Sitecore.Abstractions;
using Sitecore.Diagnostics;
using Sitecore.Forms.Mvc;
using Sitecore.Forms.Mvc.Controllers.ModelBinders;
using Sitecore.Forms.Mvc.Metadata;
using Sitecore.Forms.Mvc.ViewModels;
using Sitecore.Pipelines;
using Sitecore.WFFM.Abstractions.Shared;
using System;
using System.Web.Mvc;

namespace Sitecore.Support.Forms.Mvc.Pipelines.Initialize
{
    public class AddCustomMetadataProvider
    {
        private readonly ICorePipeline corePipeline;
        private readonly IPerRequestStorage perRequestStorage;

        public AddCustomMetadataProvider(IPerRequestStorage perRequestStorage, ICorePipeline corePipeline)
        {
            Assert.IsNotNull(perRequestStorage, "perRequestStorage");
            Assert.IsNotNull(corePipeline, "corePipeline");
            this.perRequestStorage = perRequestStorage;
            this.corePipeline = corePipeline;
        }

        [UsedImplicitly]
        public virtual void Process(PipelineArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            ModelMetadataProviders.Current = new PipelineBasedDataAnnotationsModelMetadataProvider(this.perRequestStorage, this.corePipeline);
            ModelBinders.Binders.Add(typeof(SectionViewModel), new Sitecore.Support.Forms.Mvc.Controllers.ModelBinders.SectionModelBinder());
            ModelBinders.Binders.Add(typeof(FieldViewModel), new FieldModelBinder());
        }
    }
}
