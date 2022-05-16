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
    [TemplatePart(Name = "MarkdownPreview", Type = typeof(MarkdownTextBlock))]
    public sealed class MarkdownTextBox : TextBox
    {
        public MarkdownTextBlock? MarkdownPreview { get; set; }
        public MarkdownTextBox()
        {
            this.DefaultStyleKey = typeof(MarkdownTextBox);


        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            MarkdownPreview = GetTemplateChild("MarkdownPreview") as MarkdownTextBlock;

        }


        public string Text
        {
            get => (String)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }



        DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text),
            typeof(String),
            typeof(MarkdownTextBox),
            new PropertyMetadata(default(String), new PropertyChangedCallback(OnTextChanged)));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MarkdownPreview.Text = e.NewValue as String;
        }

        //public bool HasTextValue { get; set; }
        //private static void OnTextChanged
    }
}
