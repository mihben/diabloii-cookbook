using DiabloII_Cookbook.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DiabloII_Cookbook.Client.Services
{
    public class LoadingScreenService : ILoadingScreenService, INotifyPropertyChanged
    {
        private readonly IDictionary<string, string> _data = new Dictionary<string, string>
        {
            ["Andariel"] = "Andariel was the only female Evil. She aided the Lesser Evils for many years, but eventually she lost faith in their plots. Two decades ago, she chose to help Diablo during his resurgence and seized the Citadel of the Sightless Eye. Ultimately, she perished at the hands of brave heroes.",
            ["Duriel"] = "Duriel is the twin of Andariel. I believe that they conspired together to assist Diablo in releasing Mephisto and Baal, though they had both supported the Lesser Evils in the past. The Lord of Pain was found guarding Baal's prison — the tomb of Tal Rasha — when he was slain by heroes",
            ["Mephisto"] = "The evil of Mephisto, Lord of Hatred, was so pervasive that even after he had been defeated and entombed in a soulstone, his demonic essence oozed upwards into Travincal and corrupted the Zakarum priests. Though he fell to the same heroes who killed his brothers, I fear for us should he ever return.",
            ["Diablo"] = "Remember... Diablo's greatest weapon against you is Terror. Don't give in to your fears. Resist his power and put an end to him for good!",
            ["Baal"] = "Baal was the most brash and reckless of the Prime Evils. After the Dark Exile, he was contained in the Horadrim Tal Rasha and entombed. Centuries later, Diablo freed Baal, who then corrupted the Worldstone to devastating effect for the barbarians who lived near Mount Arreat. The heroes killed Baal shortly afterward."
        };

        public LoadingScreenData Data => DrawLoadingScreenData();

        private bool _isLoading = true;
        public bool IsLoading { get { return _isLoading; } set { _isLoading = value; InvokePropertyChanged(nameof(IsLoading)); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private LoadingScreenData DrawLoadingScreenData()
        {
            var index = new Random().Next(0, _data.Count - 1);
            var drawnData = _data.ElementAt(index);
            return new LoadingScreenData(drawnData.Key, drawnData.Value);
        }

        private void InvokePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
