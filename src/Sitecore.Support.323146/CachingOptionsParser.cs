namespace Sitecore.Support.XA.Foundation.Presentation
{
  using Sitecore.Data.Items;
  using Sitecore.Layouts;
  using Sitecore.Mvc.Presentation;
  using Sitecore.XA.Foundation.Presentation;
  using Sitecore.XA.Foundation.Presentation.Extensions;

  public class CachingOptionsParser : TokenDatasourceParser
  {
    protected override void AddRenderingItemProperties(Rendering rendering)
    {
      RenderingItem renderingItem = rendering.RenderingItem;
      if (renderingItem != null)
      {
        if (!string.IsNullOrEmpty(rendering.DataSource))
        {
          ResolveDatasource(rendering);
        }
        AddCachingProperties(rendering, renderingItem);
        AddRenderingItemProperty(rendering, "DataSource", renderingItem.DataSource);
        AddRenderingItemProperty(rendering, "Placeholder", renderingItem.Placeholder);
        AddRenderingItemProperty(rendering, "Parameters", renderingItem.Parameters);
      }
    }

    protected virtual void AddCachingProperties(Rendering rendering, RenderingItem renderingItem)
    {
      bool flag = false;
      string text = rendering.Parameters["Reset Caching Options"];
      if (!string.IsNullOrEmpty(text))
      {
        flag = text.Equals("1");
      }
      if (!(rendering.Caching.Cacheable | flag))
      {
        RenderingCaching caching = renderingItem.Caching;
        rendering.SetCachingOptions(caching);
      }
    }
  }
}