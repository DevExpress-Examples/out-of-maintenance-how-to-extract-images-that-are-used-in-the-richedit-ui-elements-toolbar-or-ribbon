Imports System
Imports System.IO
Imports System.Drawing
Imports System.Reflection
Imports System.Diagnostics
Imports System.Windows.Forms

Namespace RichEditExtractImages

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ExtractImages(GetType(DevExpress.XtraRichEdit.DocumentFormat).Assembly)
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                For Each fileName As String In openFileDialog1.FileNames
                    ExtractImages(Assembly.LoadFile(fileName))
                Next
            End If
        End Sub

        Private Sub ExtractImages(ByVal sourceAssmebly As Assembly)
            Dim sourceAssmeblyName As String = sourceAssmebly.GetName().Name
            Dim directory As String = Path.Combine(Application.StartupPath, sourceAssmeblyName)
            If Not IO.Directory.Exists(directory) Then IO.Directory.CreateDirectory(directory)
            Dim resourceNames As String() = sourceAssmebly.GetManifestResourceNames()
            For Each resourceName As String In resourceNames
                If resourceName.EndsWith(".png") Then
                    Dim image As Image = Image.FromStream(sourceAssmebly.GetManifestResourceStream(resourceName))
                    image.Save(Path.Combine(directory, resourceName))
                End If
            Next

            Call Process.Start(directory)
        End Sub
    End Class
End Namespace
