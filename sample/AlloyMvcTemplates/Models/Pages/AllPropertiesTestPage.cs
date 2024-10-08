using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AlloyTemplates.Models.Blocks;
using EPiServer;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.Serialization;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace AlloyTemplates.Models.Pages
{
    [ContentType(
        GUID = "A7D46007-43E5-4401-9204-127040E79E09",
        GroupName = Global.GroupNames.Specialized)]
    [AvailableContentTypes(
        Availability.Specific,
        IncludeOn = new[] { typeof(StartPage) })
    ]
    public class AllPropertiesTestPage : PageData
    {
        [Display(Name = "Content Area", GroupName = SystemTabNames.Content, Order = 10)]
        public virtual ContentArea ContentArea1 { get; set; }

        [Display(Name = "Content Area [Readonly]", GroupName = SystemTabNames.Content, Order = 20)]
        [ReadOnly(true)]
        public virtual ContentArea ContentAreaReadonly1 { get; set; }

        [Display(Name = "Content Reference", GroupName = SystemTabNames.Content, Order = 30)]
        public virtual ContentReference ContentReference1 { get; set; }

        [Display(Name = "Page Reference (AllowedTypes)", GroupName = SystemTabNames.Content, Order = 31)]
        [AllowedTypes(typeof(PageData))]
        public virtual ContentReference PageReference1 { get; set; }

        [Display(Name = "Page Reference (Model type)", GroupName = SystemTabNames.Content, Order = 32)]
        public virtual PageReference PageReference2 { get; set; }

        [Display(Name = "Content Reference (AllowedTypes `MediaData`)", GroupName = SystemTabNames.Content, Order = 33)]
        [AllowedTypes(typeof(MediaData))]
        public virtual ContentReference MediaReference1 { get; set; }

        [Display(Name = "Content Reference (AllowedTypes `ImageData`)", GroupName = SystemTabNames.Content, Order = 34)]
        [AllowedTypes(typeof(ImageData))]
        public virtual ContentReference MediaReference2 { get; set; }

        [Display(Name = "Content Reference (UIHint `Media`)", GroupName = SystemTabNames.Content, Order = 35)]
        [UIHint(UIHint.MediaFile)]
        public virtual ContentReference MediaReference3 { get; set; }

        [Display(Name = "Content Reference (UIHint `Video`)", GroupName = SystemTabNames.Content, Order = 36)]
        [UIHint(UIHint.Video)]
        public virtual ContentReference MediaReference4 { get; set; }

        [Display(Name = "Content Reference (UIHint `Folder`)", GroupName = SystemTabNames.Content, Order = 36)]
        [UIHint(UIHint.AssetsFolder)]
        public virtual ContentReference FolderReference { get; set; }

        [Display(Name = "Content Reference (UIHint `Image`)", GroupName = SystemTabNames.Content, Order = 37)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference MediaReference5 { get; set; }

        [Display(Name = "Content Reference (AllowedTypes `ImageData & VideoData`)", GroupName = SystemTabNames.Content, Order = 38)]
        [AllowedTypes(typeof(ImageData), typeof(VideoData))]
        public virtual ContentReference MediaReference6 { get; set; }

        [Display(Name = "Block Reference (AllowedTypes)", GroupName = SystemTabNames.Content, Order = 40)]
        [AllowedTypes(AllowedTypes = new[] { typeof(BlockData) }, RestrictedTypes = new[] { typeof(ButtonBlock), typeof(EditorialBlock) })]
        public virtual ContentReference BlockReference1 { get; set; }

        [Display(Name = "Block Reference (UIHint `Block`)", GroupName = SystemTabNames.Content, Order = 41)]
        [UIHint(UIHint.Block)]
        public virtual ContentReference BlockReference2 { get; set; }

        [Display(Name = "Block Reference (AllowedTypes - 3 block types)", GroupName = SystemTabNames.Content, Order = 42)]
        [AllowedTypes(typeof(EditorialBlock), typeof(TeaserBlock), typeof(JumbotronBlock))]
        public virtual ContentReference BlockReference3 { get; set; }

        [Display(Name = "Content Reference [Readonly]", GroupName = SystemTabNames.Content, Order = 45)]
        [ReadOnly(true)]
        public virtual ContentReference ContentReferenceReadonly1 { get; set; }

        [Display(Name = "Content Reference List", GroupName = SystemTabNames.Content, Order = 50)]
        public virtual IEnumerable<ContentReference> ContentReferenceList1 { get; set; }

        [Display(Name = "Content Reference List (Allowed Types)", GroupName = SystemTabNames.Content, Order = 50)]
        [AllowedTypes(typeof(EditorialBlock), typeof(TeaserBlock), typeof(JumbotronBlock))]
        public virtual IEnumerable<ContentReference> ContentReferenceListAllowedTypes { get; set; }

        [Display(Name = "Content Reference List [Readonly]", GroupName = SystemTabNames.Content, Order = 60)]
        [ReadOnly(true)]
        public virtual IEnumerable<ContentReference> ContentReferenceListReadonly1 { get; set; }

        [Display(Name = "Link item collection", GroupName = SystemTabNames.Content, Order = 70)]
        public virtual LinkItemCollection LinkItemCollection1 { get; set; }

        [Display(Name = "Link item collection [Readonly]", GroupName = SystemTabNames.Content, Order = 80)]
        [ReadOnly(true)]
        public virtual LinkItemCollection LinkItemCollectionReadonly1 { get; set; }

        [Display(Name = "Url", GroupName = SystemTabNames.Content, Order = 81)]
        public virtual Url Url { get; set; }

        [Display(Name = "Url [Readonly]", GroupName = SystemTabNames.Content, Order = 82)]
        [ReadOnly(true)]
        public virtual Url UrlReadonly { get; set; }

        [UIHint(UIHint.Image)]
        [Display(Name = "Url to image", GroupName = SystemTabNames.Content, Order = 82)]
        public virtual Url UrlToImage { get; set; }

        [Display(Name = "Text", GroupName = SystemTabNames.Content, Order = 90)]
        public virtual string Text1 { get; set; }

        [Display(Name = "Text [Readonly]", GroupName = SystemTabNames.Content, Order = 100)]
        [ReadOnly(true)]
        public virtual string TextReadonly1 { get; set; }

        [Display(Name = "TextArea", GroupName = SystemTabNames.Content, Order = 110)]
        [UIHint(UIHint.Textarea)]
        public virtual string TextArea1 { get; set; }

        [Display(Name = "TextArea [Readonly]", GroupName = SystemTabNames.Content, Order = 120)]
        [UIHint(UIHint.Textarea)]
        [ReadOnly(true)]
        public virtual string TextAreaReadonly1 { get; set; }

        [Display(Name = "Previewable text", GroupName = SystemTabNames.Content, Order = 130)]
        [UIHint(UIHint.PreviewableText)]
        public virtual string PreviewableText1 { get; set; }

        [Display(Name = "Previewable text [Readonly]", GroupName = SystemTabNames.Content, Order = 140)]
        [UIHint(UIHint.PreviewableText)]
        [ReadOnly(true)]
        public virtual string PreviewableTextReadonly1 { get; set; }

        [Display(Name = "Date", GroupName = SystemTabNames.Content, Order = 150)]
        public virtual DateTime Date1 { get; set; }

        [Display(Name = "Date [Readonly]", GroupName = SystemTabNames.Content, Order = 160)]
        [ReadOnly(true)]
        public virtual DateTime DateReadonly1 { get; set; }

        [Display(Name = "Integer", GroupName = SystemTabNames.Content, Order = 170)]
        public virtual int Integer1 { get; set; }

        [Display(Name = "Integer [Readonly]", GroupName = SystemTabNames.Content, Order = 180)]
        [ReadOnly(true)]
        public virtual int IntegerReadonly1 { get; set; }

        [Display(Name = "Integer - range (0-10)", GroupName = SystemTabNames.Content, Order = 190)]
        [Range(0, 10)]
        public virtual int IntegerRange1 { get; set; }

        [Display(Name = "Boolean", GroupName = SystemTabNames.Content, Order = 200)]
        public virtual bool Bool1 { get; set; }

        [Display(Name = "Boolean [Readonly]", GroupName = SystemTabNames.Content, Order = 210)]
        [ReadOnly(true)]
        public virtual bool BoolReadonly1 { get; set; }

        [Display(Name = "Integer List", GroupName = SystemTabNames.Content, Order = 220)]
        public virtual IEnumerable<int> IntegerList1 { get; set; }

        [Display(Name = "Integer List [Readonly]", GroupName = SystemTabNames.Content, Order = 230)]
        [ReadOnly(true)]
        public virtual IEnumerable<int> IntegerListReadonly1 { get; set; }

        [Display(Name = "Image", GroupName = SystemTabNames.Content, Order = 230)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image1 { get; set; }

        [Display(Name = "Image [Readonly]", GroupName = SystemTabNames.Content, Order = 240)]
        [UIHint(UIHint.Image)]
        [ReadOnly(true)]
        public virtual ContentReference ImageReadonly1 { get; set; }

        [Display(Name = "Single select", GroupName = SystemTabNames.Content, Order = 250)]
        [SelectOne(SelectionFactoryType = typeof(TestSelectionFactory))]
        public virtual string SingleSelect1 { get; set; }

        [Display(Name = "Single select [Readonly]", GroupName = SystemTabNames.Content, Order = 260)]
        [SelectOne(SelectionFactoryType = typeof(TestSelectionFactory))]
        [ReadOnly(true)]
        public virtual string SingleSelectReadonly1 { get; set; }

        [Display(Name = "Multi select", GroupName = SystemTabNames.Content, Order = 270)]
        [SelectMany(SelectionFactoryType = typeof(TestSelectionFactory))]
        public virtual string MultiSelect1 { get; set; }

        [Display(Name = "Multi select [Readonly]", GroupName = SystemTabNames.Content, Order = 280)]
        [SelectMany(SelectionFactoryType = typeof(TestSelectionFactory))]
        [ReadOnly(true)]
        public virtual string MultiSelectReadonly1 { get; set; }

        [Display(Name = "List property", GroupName = SystemTabNames.Content, Order = 290)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<Person>))]
        public virtual IList<Person> Persons { get; set; }

        [Display(Name = "List property [Readonly]", GroupName = SystemTabNames.Content, Order = 300)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<Person>))]
        [ReadOnly(true)]
        public virtual IList<Person> PersonsReadonly { get; set; }

        [AutoSuggestSelection(typeof(TestSelectionQuery))]
        [Display(Name = "Auto suggest selection editor", GroupName = SystemTabNames.Content, Order = 310)]
        public virtual string SelectionEditor1 { get; set; }

        [AutoSuggestSelection(typeof(TestSelectionQuery))]
        [Display(Name = "Auto suggest selection editor [Readonly]", GroupName = SystemTabNames.Content, Order = 330)]
        [ReadOnly(true)]
        public virtual string SelectionEditorReadonly1 { get; set; }

        [AutoSuggestSelection(typeof(TestSelectionQuery), AllowCustomValues = true)]
        [Display(Name = "Auto suggest selection editor with custom values", GroupName = SystemTabNames.Content, Order = 320)]
        public virtual string SelectionEditor2 { get; set; }
    }

    public class TestSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new[]
            {
                new SelectItem
                {
                    Text = "aaaaaa",
                    Value = "1"
                },
                new SelectItem
                {
                    Text = "bbbbb",
                    Value = "2"
                },
                new SelectItem
                {
                    Text = "ccccc",
                    Value = "3"
                },
                new SelectItem
                {
                    Text = "ddddd",
                    Value = "4"
                },
                new SelectItem
                {
                    Text = "eeeee",
                    Value = "5"
                },
            };
        }
    }

    public class Person
    {
        [DisplayName("/admin/secedit/firstname")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        public int Age { get; set; }

        [ClientEditor(ClientEditingClass = "epi-cms/form/EmailValidationTextBox")]
        public string Email { get; set; }
    }

    [PropertyDefinitionTypePlugIn]
    public class PersonListProperty : PropertyList<Person>
    {
        public PersonListProperty()
        {
            _objectSerializer = _objectSerializerFactory.Service.GetSerializer(KnownContentTypes.Json);
        }

        private Injected<IObjectSerializerFactory> _objectSerializerFactory;

        private IObjectSerializer _objectSerializer;

        protected override Person ParseItem(string value)
        {
            return _objectSerializer.Deserialize<Person>(value);
        }
    }

    // Sample SelectionQuery for auto-suggestion editor
    // https://world.episerver.com/documentation/developer-guides/CMS/Content/Properties/built-in-property-types/Built-in-auto-suggestion-editor/
    [ServiceConfiguration(typeof(ISelectionQuery))]
    public class TestSelectionQuery : ISelectionQuery
    {
        readonly SelectItem[] _items;
        public TestSelectionQuery()
        {
            _items = new[] {
                new SelectItem() { Text = string.Empty, Value = string.Empty },
                new SelectItem() { Text = "Alternative1", Value = "1" },
                new SelectItem() { Text = "Alternative 2", Value = "2" } };
        }
        //Will be called when the editor types something in the selection editor.
        public IEnumerable<ISelectItem> GetItems(string query)
        {
            return _items.Where(i => i.Text.StartsWith(query, StringComparison.OrdinalIgnoreCase));
        }
        //Will be called when initializing an editor with an existing value to get the corresponding text representation.
        public ISelectItem GetItemByValue(string value)
        {
            return _items.FirstOrDefault(i => i.Value.Equals(value));
        }
    }
}
