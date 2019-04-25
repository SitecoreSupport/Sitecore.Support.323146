namespace Sitecore.Support.XA.Foundation.Presentation
{
  using Sitecore.Data.Items;
  using Sitecore.Layouts;
  using Sitecore.Mvc.Extensions;
  using Sitecore.Mvc.Presentation;
  using Sitecore.XA.Foundation.Presentation;
  using Sitecore.XA.Foundation.Presentation.Extensions;
  using System.Collections.Generic;

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
        AddRenderingItemProperty(rendering, "DataSource", rendering.DataSource);
        AddRenderingItemProperty(rendering, "Placeholder", rendering.Placeholder);
        AddRenderingItemProperty(rendering, "Parameters", ToQueryString(rendering.Parameters));
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

    private string ToQueryString(RenderingParameters parameters)
    {
      var Values = new Dictionary<string, string>();
      using (var iterator = parameters.GetEnumerator())
      {
        while (iterator.MoveNext())
        {
          var entry = iterator.Current;
          Values.Add(entry.Key, entry.Value);
        }
      }
      return Values.ToQueryString();
    }
  }
}