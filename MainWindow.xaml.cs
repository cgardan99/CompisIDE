using System;
using System.Collections.Generic;
using System.IO;
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

namespace IDE2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] files = new DirectoryInfo("C:\\Users\\cgardan\\Downloads\\").GetFiles("*.txt").Select(o => o.Name).ToArray();
        string current_file = null;

        List<String> archivos = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            
            foreach (string i in files)
            {
                archivos.Add(i);
            }
            
            main_editor.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            main_editor.AcceptsReturn = true;
            main_editor.AcceptsTab = true;

            lista_archivos.ItemsSource = archivos;

        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            
        }

        private void lista_archivos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string archivo = lista_archivos.SelectedItem.ToString();
            current_file = archivo;
            string t = System.IO.File.ReadAllText(@"C:\Users\cgardan\Downloads\" + archivo);
            main_editor.Text = t;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = main_editor.Text.ToString();

            if(current_file != null)
            {
                FileStream fParameter = new FileStream(@"C:\Users\cgardan\Downloads\" + current_file, FileMode.Create, FileAccess.Write);
                StreamWriter m_WriterParameter = new StreamWriter(fParameter);
                m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
                m_WriterParameter.Write(texto);
                m_WriterParameter.Flush();
                m_WriterParameter.Close();
            }
        }
    }
}
