using AlloyTemplates.Models.Pages;
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
    public class PagesSlice : ContentSliceBase<StandardPage>
    {
        public override string Name
        {
            get { return "Pages"; }
        }
    }
}