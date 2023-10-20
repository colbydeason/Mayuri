using System.Windows.Controls;

namespace Mayuri.Views
{
    /// <summary>
    /// Interaction logic for AddSourceView.xaml
    /// </summary>
    public partial class AddSourceView : UserControl
    {
        public AddSourceView()
        {
            InitializeComponent();
        }
    }
    // One time implimentation 
    //<StackPanel HorizontalAlignment="Left">
    //    <TextBlock Height="auto" HorizontalAlignment="Center" Text="One Time"/>
    //    <CheckBox HorizontalAlignment="Center" IsChecked="{Binding SourceOneTime, UpdateSourceTrigger=PropertyChanged}"/>
    //</StackPanel>
}
