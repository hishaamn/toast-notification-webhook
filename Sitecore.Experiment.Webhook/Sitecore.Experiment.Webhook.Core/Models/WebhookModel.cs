using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Experiment.Webhook.Core.Models
{
    public class Changes
    {
        [JsonProperty("FieldChanges")]
        public List<FieldChange> FieldChanges { get; set; }

        [JsonProperty("PropertyChanges")]
        public List<string> PropertyChanges { get; set; }

        [JsonProperty("IsUnversionedFieldChanged")]
        public bool IsUnversionedFieldChanged { get; set; }

        [JsonProperty("IsSharedFieldChanged")]
        public bool IsSharedFieldChanged { get; set; }
    }

    public class FieldChange
    {
        [JsonProperty("FieldId")]
        public string FieldId { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("OriginalValue")]
        public string OriginalValue { get; set; }
    }

    public class WebhookItem
    {
        [JsonProperty("Language")]
        public string Language { get; set; }

        [JsonProperty("Version")]
        public int Version { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ParentId")]
        public string ParentId { get; set; }

        [JsonProperty("TemplateId")]
        public string TemplateId { get; set; }

        [JsonProperty("MasterId")]
        public string MasterId { get; set; }

        [JsonProperty("SharedFields")]
        public List<SharedField> SharedFields { get; set; }

        [JsonProperty("UnversionedFields")]
        public List<UnversionedField> UnversionedFields { get; set; }

        [JsonProperty("VersionedFields")]
        public List<VersionedField> VersionedFields { get; set; }
    }

    public class WebhookModel
    {
        [JsonProperty("EventName")]
        public string EventName { get; set; }

        [JsonProperty("Item")]
        public WebhookItem Item { get; set; }

        [JsonProperty("Changes")]
        public Changes Changes { get; set; }

        [JsonProperty("WebhookItemId")]
        public string WebhookItemId { get; set; }

        [JsonProperty("WebhookItemName")]
        public string WebhookItemName { get; set; }
    }

    public class Root
    {
        
    }

    public class SharedField
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }

    public class UnversionedField
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("Language")]
        public string Language { get; set; }
    }

    public class VersionedField
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("Version")]
        public int Version { get; set; }

        [JsonProperty("Language")]
        public string Language { get; set; }
    }


}
