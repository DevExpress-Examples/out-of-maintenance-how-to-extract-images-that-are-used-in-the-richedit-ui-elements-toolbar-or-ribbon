Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Reflection
Imports System.Diagnostics
Imports System.Windows.Forms

Namespace RichEditExtractImages
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			ExtractImages(GetType(DevExpress.XtraRichEdit.DocumentFormat).Assembly)
		End Sub

		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				For Each fileName As String In openFileDialog1.FileNames
					ExtractImages(System.Reflection.Assembly.LoadFile(fileName))
				Next fileName
			End If
		End Sub

		Private Sub ExtractImages(ByVal sourceAssmebly As System.Reflection.Assembly)
			Dim sourceAssmeblyName As String = sourceAssmebly.GetName().Name
			Dim _directory As String = Path.Combine(Application.StartupPath, sourceAssmeblyName)

			If (Not Directory.Exists(_directory)) Then
				Directory.CreateDirectory(_directory)
			End If

			Dim resourceNames() As String = sourceAssmebly.GetManifestResourceNames()

			For Each resourceName As String In resourceNames
				If resourceName.EndsWith(".png") Then
					Dim image As Image = Image.FromStream(sourceAssmebly.GetManifestResourceStream(resourceName))
					image.Save(Path.Combine(_directory, resourceName))
				End If
			Next resourceName

			Process.Start(_directory)
		End Sub
	End Class
End Namespace