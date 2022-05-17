using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using CommunityToolkit.WinUI.UI.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MarkdownTextBox
{
    //[TemplatePart(Name = nameof(MarkdownTextBox.InputTextBox), Type = typeof(TextBox))]
    //[TemplatePart(Name = nameof(PreviewMarkdownBlock), Type = typeof(MarkdownTextBlock))]
    //[TemplatePart(Name = nameof(MTBGrid), Type = typeof(Grid))]
    [TemplatePart(Name = "InputTextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PreviewMarkdownBlock", Type = typeof(MarkdownTextBlock))]
    [TemplatePart(Name = "MTBGrid", Type = typeof(Grid))]
    public sealed class MarkdownTextBox : Control
    {



        private TextBox _inputTextBox;
        private MarkdownTextBlock _previewMarkdownBlock;
        private Grid _MTBGrid;

        public MarkdownTextBox()
        {
            this.DefaultStyleKey = typeof(MarkdownTextBox);

            // WinUI3 workaround for https://github.com/microsoft/microsoft-ui-xaml/issues/3502
            this.DefaultStyleResourceUri = new Uri("ms-appx:///MarkdownTextBox/Themes/Generic.xaml");

        }






        protected override void OnApplyTemplate()
        {
            //this.InputTextBox = this.GetTemplateChild<TextBox>(nameof(InputTextBox));

            //this.PreviewMarkdownBlock = this.GetTemplateChild<MarkdownTextBlock>(nameof(PreviewMarkdownBlock));
            //this.MTBGrid = this.GetTemplateChild<Grid>(nameof(MTBGrid));

            _MTBGrid = GetTemplateChild("MTBGrid") as Grid;
            _previewMarkdownBlock = GetTemplateChild("PreviewMarkdownBlock") as MarkdownTextBlock;
            _inputTextBox = GetTemplateChild("InputTextBox") as TextBox;
            _previewMarkdownBlock.Text = _inputTextBox.Text;



            base.OnApplyTemplate();

        }

        private static void UpdateMarkdownBlock(MarkdownTextBox markdownTBControl, MarkdownTextBlock markdownPreview, String newValue)
        {
            if (markdownPreview != null)
            {
                markdownPreview.Text = newValue;
            }
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)

        {

            //  String textBoxText = (d as TextBox).Text;
            //  if (textBoxText != null)
            //MarkdownPreview.Text = textBoxText; 
            //e.NewValue as String;
        }

        public string Text
        {
            get => (String)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }


        /// <summary>
        /// Retrieves the named element in the instantiated ControlTemplate visual tree.
        /// </summary>
        /// <param name="childName">The name of the element to find.</param>
        /// <param name="isRequired">Whether the element is required and will throw an exception if missing.</param>
        /// <returns>The template child matching the given name and type.</returns>
        private T GetTemplateChild<T>(string childName, bool isRequired = false)
            where T : DependencyObject
        {
            T child = this.GetTemplateChild(childName) as T;
            if ((child == null) && isRequired)
            {
                ThrowArgumentNullException();
            }

            return child;

            static void ThrowArgumentNullException() => throw new ArgumentNullException(nameof(childName));
        }


        DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text),
            typeof(String),
            typeof(MarkdownTextBox),
            new PropertyMetadata(default(String), new PropertyChangedCallback(OnTextChanged)));



        //public bool HasTextValue { get; set; }
        //private static void OnTextChanged
    }
}
