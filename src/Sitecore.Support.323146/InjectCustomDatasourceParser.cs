namespace Sitecore.Support.XA.Foundation.Presentation.Pipelines.Initialize
{
  using Sitecore.Mvc.Configuration;
  using Sitecore.Mvc.Presentation;
  using Sitecore.Pipelines;
  using Sitecore.XA.Foundation.Presentation;
  using System;

  public class InjectCustomDatasourceParser
  {
    public virtual void Process(PipelineArgs args)
    {
      MvcSettings.RegisterObject((Func<XmlBasedRenderingParser>)(() => new Sitecore.Support.XA.Foundation.Presentation.CachingOptionsParser()));
    }
  }
}