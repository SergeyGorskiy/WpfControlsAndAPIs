using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;

namespace WpfControlsAndAPIs
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            inkRadio.IsChecked = true;
            comboColors.SelectedIndex = 0;
        }
        private void SaveData(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Create))
            {
                MyInkCanvas.Strokes.Save(fs);
                fs.Close();
            }
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Open, FileAccess.Read))
            {
                StrokeCollection strokes = new StrokeCollection(fs);
                MyInkCanvas.Strokes = strokes;
            }
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            MyInkCanvas.Strokes.Clear();
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            string colorToUse = (comboColors.SelectedItem as StackPanel)?.Tag.ToString();
            MyInkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorToUse);
        }
        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton)?.Content.ToString())
            {
                case "Ink Mode!":
                    MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Erase Mode!":
                    MyInkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case "Select Mode!":
                    MyInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
            }
        }
    }
}
