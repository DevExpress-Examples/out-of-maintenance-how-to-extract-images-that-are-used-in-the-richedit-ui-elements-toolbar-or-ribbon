using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;

namespace RichEditExtractImages {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            ExtractImages(typeof(DevExpress.XtraRichEdit.DocumentFormat).Assembly);
        }

        private void button2_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                foreach (string fileName in openFileDialog1.FileNames) {
                    ExtractImages(Assembly.LoadFile(fileName));
                }
            }
        }

        private void ExtractImages(Assembly sourceAssmebly) {
            string sourceAssmeblyName = sourceAssmebly.GetName().Name;
            string directory = Path.Combine(Application.StartupPath, sourceAssmeblyName);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string[] resourceNames = sourceAssmebly.GetManifestResourceNames();

            foreach (string resourceName in resourceNames) {
                if (resourceName.EndsWith(".png")) {
                    Image image = Image.FromStream(sourceAssmebly.GetManifestResourceStream(resourceName));
                    image.Save(Path.Combine(directory, resourceName));
                }
            }

            Process.Start(directory);
        }
    }
}