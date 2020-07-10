using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OpenLyricsConverter_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members
        ITreeBuilder tree;
        ComboBoxValues _cbValues = new ComboBoxValues();
        OpenLyricsEntityViewModel _openlyricsentity;
        string LastSavePath;
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        string _Title = string.Empty;
        DisplayLanguage _Language;
        string __ImportFromDirectory;
        #endregion

        #region Constructor
        public MainWindow()
        {
            //generate components
            InitializeComponent();

            //initialise savefiledialog
            InitialiseSaveFileDialog();

            //set view models
            _openlyricsentity = FindResource("OpenLyricsEntity") as OpenLyricsEntityViewModel;
            _Language = FindResource("displayLanguage") as DisplayLanguage;

            //set combobox values
            SongbookEntry.ItemsSource = _cbValues.ComboBoxValueArray;
        }

        private void InitialiseSaveFileDialog()
        {
            saveFileDialog.Filter = "OpenLyrics(.xml)|*.xml";
            saveFileDialog.Title = "Ének mentése";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        #endregion

        #region Events
        private void SaveXml_Click(object sender, RoutedEventArgs e)
        {
            //create xml structure
            tree = new TreeBuilder(_openlyricsentity);

            //set filename to song title
            saveFileDialog.FileName = _Title;

            //propt user about location
            var result = saveFileDialog.ShowDialog();

            //Save
            if (result == true)
            {
                //store last save path
                LastSavePath = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);

                //save xml file
                tree.Save(saveFileDialog.FileName);

                //Notify user about transaction
                MessageBox.Show("Fájl sikeresen elmentve", "Mentés eredménye", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ImportFromDirectory_Click(object sender, RoutedEventArgs e)
        {
            using (var dir = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dir.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(dir.SelectedPath))
                {
                    __ImportFromDirectory = dir.SelectedPath;
                }
            }
        }
        private void SongbookEntry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _openlyricsentity.Entry = (int)SongbookEntry.SelectedItem;
        }
        
        private void LanguageChanger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _Language.CurrentLanguage = LanguageChanger.SelectedItem.ToString();
        }

        #endregion
    }
}
