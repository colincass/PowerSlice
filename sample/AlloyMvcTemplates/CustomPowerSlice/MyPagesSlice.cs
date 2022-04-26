using AlloyTemplates.Models.Pages;
using EPiServer.Cms.Shell.UI.Rest.ContentQuery;
using EPiServer.Core;
using EPiServer.Find;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ContentQuery;
using Microsoft.AspNetCore.Http;
using PowerSlice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyTemplates.MySlice
{
    [ServiceConfiguration(typeof(IContentQuery)), ServiceConfiguration(typeof(IContentSlice))]
    public class MyPagesSlice : ContentSliceBase<SitePageData>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MyPagesSlice(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public override string Name
        {
            get { return "My Pages"; }
        }
        protected override ITypeSearch<SitePageData> Filter(ITypeSearch<SitePageData> searchRequest, ContentQueryParameters parameters)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            return searchRequest.Filter(x => x.MatchTypeHierarchy(typeof(IChangeTrackable)) & ((IChangeTrackable)x).CreatedBy.Match(userName));
        }
    }
}