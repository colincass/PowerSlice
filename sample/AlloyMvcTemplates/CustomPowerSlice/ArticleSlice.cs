using AlloyTemplates.Models.Pages;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ContentQuery;
using PowerSlice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTemplates.MySlice
{
    [ServiceConfiguration(typeof(IContentQuery)), ServiceConfiguration(typeof(IContentSlice))]
    public class ArticleSlice : ContentSliceBase<ArticlePage>
    {
        public override string Name
        {
            get { return "Articles"; }
        }
        public override IEnumerable<CreateOption> CreateOptions
        {
            get
            {
                var contentType = ContentTypeRepository.Load(typeof(ArticlePage));
                yield return new CreateOption(contentType.LocalizedName, ContentReference.StartPage, contentType.ID);
            }
        }
    }
}