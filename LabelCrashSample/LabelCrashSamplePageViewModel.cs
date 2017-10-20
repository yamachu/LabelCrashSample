using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Reactive.Bindings;
using Xamarin.Forms;

namespace LabelCrashSample
{
    public class LabelCrashSamplePageViewModel
    {
        private readonly ObservableCollection<ObservableGroupCollection<string, SampleModel>> _contens = new ObservableCollection<ObservableGroupCollection<string, SampleModel>>();
        public ReadOnlyObservableCollection<ObservableGroupCollection<string, SampleModel>> Contents { get; }

        public ReactiveProperty<string> ButtonState { get; } = new ReactiveProperty<string>("A");
        public ICommand Toggle { get; }
        private bool _isToggled = true;

        private List<SampleModel> _setA;
        private List<SampleModel> _setB;

        public LabelCrashSamplePageViewModel()
        {
            _setA = new List<SampleModel>{
                new SampleModel{ Content = "Ant" },
                new SampleModel{ Content = "Apple" },
                new SampleModel{ Content = "Angel" },
                new SampleModel{ Content = "Bug" },
                new SampleModel{ Content = "Bat" },
                new SampleModel{ Content = "Baseball" },
                new SampleModel{ Content = "Chocolate" },
                new SampleModel{ Content = "Cake" },
            };

            _setB = new List<SampleModel>{
                new SampleModel{ Content = "Doragon" },
                new SampleModel{ Content = "Drill" },
                new SampleModel{ Content = "Elephant" },
                new SampleModel{ Content = "Fire" },
                new SampleModel{ Content = "Godzilla" },
                new SampleModel{ Content = "Gorilla" },
                new SampleModel{ Content = "Hole" },
            };

            Contents = new ReadOnlyObservableCollection<ObservableGroupCollection<string, SampleModel>>(_contens);

            Toggle = new Command(() =>
            {
                _isToggled = !_isToggled;

                ButtonState.Value = _isToggled ? "A" : "B";

                _contens.Clear();
                if (_isToggled)
                {
                    foreach (var item in _setA.GroupBy(item => item.GroupKey).Select(g => new ObservableGroupCollection<string, SampleModel>(g)).OrderBy(g => g.Key))
                    {
                        _contens.Add(item);
                    }
                }
                else
                {
                    foreach (var item in _setB.GroupBy(item => item.GroupKey).Select(g => new ObservableGroupCollection<string, SampleModel>(g)).OrderBy(g => g.Key))
                    {
                        _contens.Add(item);
                    }
                }
            });

            foreach (var item in _setA.GroupBy(item => item.GroupKey).Select(g => new ObservableGroupCollection<string, SampleModel>(g)).OrderBy(g => g.Key))
            {
                _contens.Add(item);
            }
        }
    }
}
