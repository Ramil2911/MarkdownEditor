using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using text_editor.Internationalization.Attributes;
using text_editor.Views.Topbars;

namespace text_editor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public List<ButtonData> Topbars { get; set; } = new List<ButtonData>();

        [Reactive] public TopbarPanelBase ActivePanel { get; set; }

        public MainWindowViewModel()
        {

            var types = Helpers.Helpers.GetChildren<TopbarPanelBase>();
            foreach (var type in types)
            {
                var attr = Attribute.GetCustomAttribute(type, typeof(LocalizableTopbarName));
                if(attr is not null) Topbars.Add(new ButtonData() {NameAttr = attr as LocalizableTopbarName, ButtonType = type, WindowViewModel = this});
            }

            Topbars = Topbars.OrderByDescending(x => x.NameAttr.Order).Reverse()
                .ToList();

            
            Topbars[0].Color = "#484848";
            Topbars[0].SetActivePanel.Execute();
        }
    }

    public class ButtonData : ReactiveObject
    {
        public LocalizableTopbarName NameAttr { get; init; }
        public Type ButtonType { get; init; }
        [Reactive] public string Color { get; set; } = "#444444";
        
        public MainWindowViewModel WindowViewModel { get; init; }
        
        public ReactiveCommand<Unit, Unit> SetActivePanel { get; set; }

        public ButtonData()
        {
            SetActivePanel = ReactiveCommand.Create<Unit>(x =>
            {
                foreach (var t in WindowViewModel.Topbars)
                {
                    t.Color = "#444444";
                }

                Color = "#484848";

                WindowViewModel.ActivePanel = Activator.CreateInstance(ButtonType) as TopbarPanelBase;
            });
        }
    }
}