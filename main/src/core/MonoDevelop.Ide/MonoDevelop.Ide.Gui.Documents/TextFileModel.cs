﻿//
// FileDocumentModel.cs
//
// Author:
//       Lluis Sanchez <llsan@microsoft.com>
//
// Copyright (c) 2019 Microsoft
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System.IO;
using System.Threading.Tasks;

namespace MonoDevelop.Ide.Gui.Documents
{
	public abstract class TextFileModel : FileDocumentModel
	{
		public void SetText (string text)
		{
			GetRepresentation ();
		}

		public abstract Task<string> GetText ();

		public Task Read (TextReader reader)
		{
			return OnRead (reader);
		}

		protected abstract Task OnRead (TextReader reader);

		protected override Task CopyFromLinkedModel (DocumentModel model)
		{
			if (model is TextFileModel textFileModel) {
				SetText (textFileModel.GetText ());
				return Task.CompletedTask;
			}
			return base.CopyFromLinkedModel (model);
		}

		protected abstract class TextFileModelRepresentation : ModelRepresentation
		{
			public abstract void SetText (string text);

			public abstract Task<string> GetText ();
		}
	}
}
