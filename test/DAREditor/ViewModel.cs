// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DAREditor
{
    internal class ViewModel : NotifyPropertyChangedImpl
    {
        string _statusText;
        FlowDocument _expectedDocument;

        public ViewModel()
        {
            _statusText = "TODO";
            _expectedDocument = new FlowDocument();
            var run = new Run("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            var paragraph = new Paragraph(run);
            _expectedDocument.Blocks.Add(paragraph);
        }

        public string StatusText
        {
            get => _statusText;
            set => SetProperty(nameof(StatusText), ref _statusText, value);
        }

        public string ExpectedDocument { get; }
    }
}
