// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DAREditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ViewModel m_viewModel = new ViewModel();

        public MainWindow()
        {
            this.DataContext = m_viewModel;
            InitializeComponent();

            ActualRichTextBox.TextChanged += ActualRichTextBox_TextChanged;

            var run = new Run(ExampleActualText);
            var paragraph = new Paragraph(run);
            BlockCollection actualBlocks = ActualRichTextBox.Document.Blocks;
            actualBlocks.Clear();
            actualBlocks.Add(paragraph);

            // NOTE: This is supposed to add highlighting
            //TextRange textRange = new TextRange(...);
            //textRange.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Yellow);
        }

        private void ActualRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string content = GetContent(ActualRichTextBox);
            Debug.WriteLine("Change sent. New content:", content);
        }

        private string GetContent(RichTextBox richTextBox)
        {
            StringBuilder textBuilder = new StringBuilder();

            void ProcessInlines(InlineCollection inlines)
            {
                foreach (var inline in inlines)
                {
                    if (inline is LineBreak)
                        textBuilder.Append(Environment.NewLine);
                    else if (inline is Run run)
                        textBuilder.Append(run.Text);
                    else if (inline is Span span)
                        ProcessInlines(span.Inlines);
                    else
                    {
                        Debug.Fail("ERROR: Unknown Inline type, add an error");
                    }
                }
            }

            foreach (var block in richTextBox.Document.Blocks)
            {
                if (block is Paragraph paragraph)
                {
                    if (textBuilder.Length != 0)
                        textBuilder.Append(Environment.NewLine);
                    ProcessInlines(paragraph.Inlines);

                }
                else
                {
                    Debug.Fail("ERROR: block is not a paragraph, add an error");
                }
            }

            return textBuilder.ToString();
        }

        const string ExampleActualText = @"{
  ""actual"": [
    {
      ""success"": true,
      ""message"": null,
      ""request_seq"": 5,
      ""command"": ""stackTrace"",
      ""body"": {
        ""stackFrames"": [
          {
            ""id"": 1000,
            ""name"": ""[External Code]"",
            ""line"": 0,
            ""column"": 0,
            ""presentationHint"": ""subtle""
          },
          {
            ""id"": 1001,
            ""name"": ""[Exception] Exceptions4Debuggee.exe!AsyncTest.C(string messageFormat) Line 51"",
            ""source"": {
              ""name"": ""debuggee.cs"",
              ""path"": ""C:\\dd\\Concord\\src\\vsdbg\\VsDbg-UITests\\Debuggees\\Exceptions4Debuggee\\debuggee.cs"",
              ""sourceReference"": 0,
              ""checksums"": [
                {
                  ""algorithm"": ""SHA256"",
                  ""checksum"": ""b2ef5210e5727249981edef3380f6f4d34a1cb776683ec762cc21096f6d81a4a""
                }
              ]
            },
            ""line"": 51,
            ""column"": 9,
            ""endLine"": 51,
            ""endColumn"": 87,
            ""instructionPointerReference"": ""0x00007FFE0AA619D4"",
            ""moduleId"": 1001
          },
          {
            ""id"": 1002,
            ""name"": ""[Exception] Exceptions4Debuggee.exe!AsyncTest.B(string messageFormat) Line 43"",
            ""source"": {
              ""name"": ""debuggee.cs"",
              ""path"": ""C:\\dd\\Concord\\src\\vsdbg\\VsDbg-UITests\\Debuggees\\Exceptions4Debuggee\\debuggee.cs"",
              ""sourceReference"": 0,
              ""checksums"": [
                {
                  ""algorithm"": ""SHA256"",
                  ""checksum"": ""b2ef5210e5727249981edef3380f6f4d34a1cb776683ec762cc21096f6d81a4a""
                }
              ]
            },
            ""line"": 43,
            ""column"": 9,
            ""endLine"": 43,
            ""endColumn"": 32,
            ""instructionPointerReference"": ""0x00007FFE0AA615CE"",
            ""moduleId"": 1001
          },
          {
            ""id"": 1003,
            ""name"": ""[Exception] Exceptions4Debuggee.exe!AsyncTest.A(string messageFormat) Line 36"",
            ""source"": {
              ""name"": ""debuggee.cs"",
              ""path"": ""C:\\dd\\Concord\\src\\vsdbg\\VsDbg-UITests\\Debuggees\\Exceptions4Debuggee\\debuggee.cs"",
              ""sourceReference"": 0,
              ""checksums"": [
                {
                  ""algorithm"": ""SHA256"",
                  ""checksum"": ""b2ef5210e5727249981edef3380f6f4d34a1cb776683ec762cc21096f6d81a4a""
                }
              ]
            },
            ""line"": 36,
            ""column"": 9,
            ""endLine"": 36,
            ""endColumn"": 32,
            ""instructionPointerReference"": ""0x00007FFE0AA6122E"",
            ""moduleId"": 1001
          },
          {
            ""id"": 1004,
            ""name"": ""[External Code]"",
            ""line"": 0,
            ""column"": 0,
            ""presentationHint"": ""subtle""
          },
          {
            ""id"": 1005,
            ""name"": ""Exceptions4Debuggee.exe!AsyncTest.Run(System.Func<string> messageFormatFactory) Line 25"",
            ""source"": {
              ""name"": ""debuggee.cs"",
              ""path"": ""C:\\dd\\Concord\\src\\vsdbg\\VsDbg-UITests\\Debuggees\\Exceptions4Debuggee\\debuggee.cs"",
              ""sourceReference"": 0,
              ""checksums"": [
                {
                  ""algorithm"": ""SHA256"",
                  ""checksum"": ""b2ef5210e5727249981edef3380f6f4d34a1cb776683ec762cc21096f6d81a4a""
                }
              ]
            },
            ""line"": 25,
            ""column"": 13,
            ""endLine"": 25,
            ""endColumn"": 45,
            ""instructionPointerReference"": ""0x00007FFE0AA60DF4"",
            ""moduleId"": 1001
          },
          {
            ""id"": 1006,
            ""name"": ""[External Code]"",
            ""line"": 0,
            ""column"": 0,
            ""presentationHint"": ""subtle""
          }
        ],
        ""totalFrames"": 7
      },
      ""running"": false,
      ""refs"": null,
      ""seq"": 24,
      ""type"": ""response""
    }
  ]
}
";
    }
}
