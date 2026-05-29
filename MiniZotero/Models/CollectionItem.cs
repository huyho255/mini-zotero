using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MiniZotero.Models
{
    public sealed partial class CollectionItem : ObservableObject
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        [ObservableProperty]
        private string _name = "New Collection";

        [ObservableProperty]
        [property: JsonIgnore]
        private bool _isEditingName;

        public List<string> DocumentIds { get; set; } = [];

        [JsonIgnore]
        public int DocumentCount => DocumentIds.Count;

        public void NotifyDocumentCountChanged()
        {
            OnPropertyChanged(nameof(DocumentCount));
        }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
    }
}
