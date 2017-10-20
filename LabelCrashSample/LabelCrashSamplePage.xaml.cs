using Xamarin.Forms;

namespace LabelCrashSample
{
    public partial class LabelCrashSamplePage : ContentPage
    {
        public LabelCrashSamplePage()
        {
            InitializeComponent();

            BindingContext = new LabelCrashSamplePageViewModel();
        }
    }
}
