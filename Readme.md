<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->
# How to extract images that are used in the RichEdit UI elements (toolbar or Ribbon items)


<p><strong>Problem:</strong></p><p>I have created a custom item on the RichEdit toolbar (see <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument5807"><u>How to: Create a Simple Word Processor with Bar Menu</u></a>). I would like to use the built-in icons for this item. I cannot find a corresponding glyph. Is there an assembly or resource file that contains these images so that I can access them?</p><p><strong>Solution:</strong></p><p>Yes, all images and other resources (e.g. cursors, css styles of web control) of our components are embedded into corresponding assemblies. You can easily extract any resource by using the <a href="http://msdn.microsoft.com/en-us/library/xc4235zt.aspx"><u>Assembly.GetManifestResourceStream Method</u></a> and converting a resulting stream to a string or other appropriate type (image in this example). To obtain identifiers of all available resources, use the <a href="http://msdn.microsoft.com/en-us/library/system.reflection.assembly.getmanifestresourcenames.aspx"><u>Assembly.GetManifestResourceNames Method</u></a>. This example illustrates how to use these methods to extract and save to disk all *.png images from the DevExpress.RichEdit.vXY.Z.Core.dll assembly (we obtain a reference to this assembly by using "typeof(DevExpress.XtraRichEdit.DocumentFormat)" expression) or any other assembly that can be specified at runtime via the <a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.openfiledialog.aspx"><u>OpenFileDialog Class</u></a>.</p><p><strong>Note:</strong><br />
If you purchased our components with the full source code included option, you can easily find images in the "Images" subdirectory of the corresponding product's source code directory. For instance, refer to the C:\Program Files (x86)\DevExpress 2010.1\Components\Sources\DevExpress.XtraRichEdit\DevExpress.RichEdit.Core\Images directory in the case of the XtraRichEdit Suite.</p>

<br/>


