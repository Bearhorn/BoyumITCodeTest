using Boyum_IT_code_challenge.Models;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Boyum_IT_code_challenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPickFile_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            var result = fileDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    var file = fileDialog.FileName;
                    txtInput.Text = file;
                    txtInput.ToolTip = file;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    txtInput.Text = null;
                    txtInput.ToolTip = null;
                    break;
            }
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            var serializer = new XmlSerializer(typeof(WebOrder));
            WebOrder result;
            using (var fileStream = File.Open(txtInput.Text, FileMode.Open))
            {
                result = (WebOrder)serializer.Deserialize(fileStream);
            }

            lblOutputId.Content = result.Id;
            lblOutputCustomer.Content = result.Customer;
            lblOutputDate.Content = result.Date.ToString("dd. MMMM. yyyy");
            lblOutputAvgPrice.Content = result.AvgPrice.ToString("N3", new CultureInfo("da-DK"));
            lblOutputTotal.Content = result.Total.ToString("N3", new CultureInfo("da-DK"));
            /*I only specify the format provider because the assignment specifically says to use dot as the thousand seperator
                and comma as the decimal seperator, and if I don't specify the format provider then it'll change based on the
                setup of the machine running the code. */
        }
    }
}
