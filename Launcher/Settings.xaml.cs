using System;
using System.IO;
using System.Windows;
using System.Text.RegularExpressions;
using Launcher.HelpClasses;

namespace Launcher
{
    /// <summary>
    /// Lógica de interacción para Settings.xaml
    /// </summary>
    public partial class Settings
    {


        public Settings()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.IsAutoLogin = (Autologin.IsChecked == true);
            Properties.Settings.Default.Login = Login.Text;
            Properties.Settings.Default.Password = Password.Password;
            Properties.Settings.Default.ProgressBarType = ProgressType.SelectedIndex;
            Properties.Settings.Default.GameFolder = Folder.Text;
            Properties.Settings.Default.DownloadSpeedLimit =
                (long)(Convert.ToDouble(SpeedValue.Text) * Math.Pow(1024, SpeedType.SelectedIndex + 1));
            Properties.Settings.Default.Save();

            if (Owner is MainWindow m && m.AnyDownloads)
            {
                m.CurrentBytes2 = 0;
                m.CurrentFileBytes2 = 0;

                m.StopWatch.Stop();
                m.StopWatch.Reset();
                m.StopWatch.Start();
            }
            Close();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Login.Text = Properties.Settings.Default.Login;
            Password.Password = Properties.Settings.Default.Password;
            Autologin.IsChecked = Properties.Settings.Default.IsAutoLogin;
            ProgressType.SelectedIndex = Properties.Settings.Default.ProgressBarType;
            Folder.Text = Properties.Settings.Default.GameFolder;

            SpeedValue.Text = Utilities.Updater.DetectSize(Properties.Settings.Default.DownloadSpeedLimit, out var index);
            SpeedType.SelectedIndex = index;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var folder = new System.Windows.Forms.FolderBrowserDialog
            {
                Description = @"Seleccione la carpeta del cliente del juego",
                RootFolder = Environment.SpecialFolder.MyComputer,
                ShowNewFolderButton = false
            };
            var result = folder.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK) return;

            if (File.Exists(Path.Combine(folder.SelectedPath, "Wow.exe")))
            {
                var folderPath = folder.SelectedPath;
                Folder.Text = folderPath;
            }
            else
            { MessageBox.Show("¡Archivo \"Wow.exe\" no encontrado!\nPor favor, seleccione una carpeta válida del juego.", "Error al seleccionar carpeta", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void ResetPath_Click(object sender, RoutedEventArgs e)
        {
            Folder.Text = "No especificado";
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea eliminar todos los archivos descargados del servidor?", "Confirmar eliminación", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (Owner is MainWindow m) m.DPatches();
            }

        }

        private void SpeedValue_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            var regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }
    }
}
