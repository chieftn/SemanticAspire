using System.Text.Json.Serialization;

public class IcmDataModel
{
    [JsonPropertyName("chunk_id")]
    public string ChunkId { get; set; }

    //[JsonPropertyName("parent_id")]
    //public string ParentId { get; set; }

    [JsonPropertyName("chunk")]
    public string Chunk { get; set; }

    //[JsonPropertyName("text_vector")]
    //public List<float> TextVector { get; set; }

    [JsonPropertyName("IncidentId")]
    public long IncidentId { get; set; }

    //[JsonPropertyName("Lens_IngestionTime")]
    //public DateTime LensIngestionTime { get; set; }

    //[JsonPropertyName("SourceId")]
    //public string SourceId { get; set; }

    //[JsonPropertyName("SourceName")]
    //public string SourceName { get; set; }

    //[JsonPropertyName("SourceType")]
    //public string SourceType { get; set; }

    //[JsonPropertyName("SourceIncidentId")]
    //public string SourceIncidentId { get; set; }

    //[JsonPropertyName("SourceCreateDate")]
    //public DateTime SourceCreateDate { get; set; }

    //[JsonPropertyName("SourceOrigin")]
    //public string SourceOrigin { get; set; }

    //[JsonPropertyName("SourceCreatedBy")]
    //public string SourceCreatedBy { get; set; }

    //[JsonPropertyName("SourceModifiedDate")]
    //public DateTime SourceModifiedDate { get; set; }

    //[JsonPropertyName("CreateDate")]
    //public DateTime CreateDate { get; set; }

    //[JsonPropertyName("ModifiedDate")]
    //public DateTime ModifiedDate { get; set; }

    //[JsonPropertyName("RoutingId")]
    //public string RoutingId { get; set; }

    //[JsonPropertyName("CorrelationId")]
    //public string CorrelationId { get; set; }

    //[JsonPropertyName("OccurringEnvironment")]
    //public string OccurringEnvironment { get; set; }

    //[JsonPropertyName("OccurringDatacenter")]
    //public string OccurringDatacenter { get; set; }

    //[JsonPropertyName("OccurringDeviceGroup")]
    //public string OccurringDeviceGroup { get; set; }

    //[JsonPropertyName("OccurringDeviceName")]
    //public string OccurringDeviceName { get; set; }

    //[JsonPropertyName("OccurringServiceInstanceId")]
    //public string OccurringServiceInstanceId { get; set; }

    //[JsonPropertyName("RaisingEnvironment")]
    //public string RaisingEnvironment { get; set; }

    //[JsonPropertyName("RaisingDatacenter")]
    //public string RaisingDatacenter { get; set; }

    //[JsonPropertyName("RaisingDeviceGroup")]
    //public string RaisingDeviceGroup { get; set; }

    //[JsonPropertyName("RaisingDeviceName")]
    //public string RaisingDeviceName { get; set; }

    //[JsonPropertyName("RaisingServiceInstanceId")]
    //public string RaisingServiceInstanceId { get; set; }

    //[JsonPropertyName("OwningTenantName")]
    //public string OwningTenantName { get; set; }

    //[JsonPropertyName("OwningTenantId")]
    //public long OwningTenantId { get; set; }

    //[JsonPropertyName("OwningTenantPublicId")]
    //public string OwningTenantPublicId { get; set; }

    //[JsonPropertyName("OwningTeamName")]
    //public string OwningTeamName { get; set; }

    //[JsonPropertyName("OwningTeamId")]
    //public long OwningTeamId { get; set; }

    //[JsonPropertyName("OwningContactId")]
    //public string OwningContactId { get; set; }

    //[JsonPropertyName("OwningContactAlias")]
    //public string OwningContactAlias { get; set; }

    //[JsonPropertyName("Severity")]
    //public long Severity { get; set; }

    //[JsonPropertyName("Status")]
    //public string Status { get; set; }

    //[JsonPropertyName("IsNoise")]
    //public bool IsNoise { get; set; }

    //[JsonPropertyName("IsSecurityRisk")]
    //public bool IsSecurityRisk { get; set; }

    //[JsonPropertyName("IsCustomerImpacting")]
    //public bool IsCustomerImpacting { get; set; }

    //[JsonPropertyName("Component")]
    //public string Component { get; set; }

    //[JsonPropertyName("TsgId")]
    //public string TsgId { get; set; }

    //[JsonPropertyName("Title")]
    //public string Title { get; set; }

    //[JsonPropertyName("ReproSteps")]
    //public string ReproSteps { get; set; }

    //[JsonPropertyName("CustomerName")]
    //public string CustomerName { get; set; }

    //[JsonPropertyName("ResolveDate")]
    //public DateTime ResolveDate { get; set; }

    //[JsonPropertyName("ResolvedBy")]
    //public string ResolvedBy { get; set; }

    [JsonPropertyName("Mitigation")]
    public string Mitigation { get; set; }

    //[JsonPropertyName("ImpactedScenarios")]
    //public string ImpactedScenarios { get; set; }

    //[JsonPropertyName("HitCount")]
    //public long HitCount { get; set; }

    //[JsonPropertyName("Keywords")]
    //public string Keywords { get; set; }

    //[JsonPropertyName("MitigateDate")]
    //public DateTime MitigateDate { get; set; }

    //[JsonPropertyName("ImpactStartDate")]
    //public DateTime ImpactStartDate { get; set; }

    //[JsonPropertyName("MitigatedBy")]
    //public string MitigatedBy { get; set; }

    //[JsonPropertyName("CommsMgrEngagementMode")]
    //public string CommsMgrEngagementMode { get; set; }

    //[JsonPropertyName("CommsMgrEngagementAdditionalDetails")]
    //public string CommsMgrEngagementAdditionalDetails { get; set; }

    [JsonPropertyName("IncidentType")]
    public string IncidentType { get; set; }

    //[JsonPropertyName("ChildCount")]
    //public long ChildCount { get; set; }

    //[JsonPropertyName("RelatedLinksCount")]
    //public long RelatedLinksCount { get; set; }

    //[JsonPropertyName("ExternalLinksCount")]
    //public long ExternalLinksCount { get; set; }

    [JsonPropertyName("HowFixed")]
    public string HowFixed { get; set; }

    //[JsonPropertyName("IncidentSubType")]
    //public string IncidentSubType { get; set; }

    //[JsonPropertyName("TsgOutput")]
    //public string TsgOutput { get; set; }

    //[JsonPropertyName("MonitorId")]
    //public string MonitorId { get; set; }

    //[JsonPropertyName("ResponsibleTenantName")]
    //public string ResponsibleTenantName { get; set; }

    //[JsonPropertyName("ResponsibleTenantId")]
    //public long ResponsibleTenantId { get; set; }

    //[JsonPropertyName("ResponsibleTenantPublicId")]
    //public string ResponsibleTenantPublicId { get; set; }

    //[JsonPropertyName("SupportTicketId")]
    //public string SupportTicketId { get; set; }

    //[JsonPropertyName("SubscriptionId")]
    //public string SubscriptionId { get; set; }

    //[JsonPropertyName("OriginatingTenantName")]
    //public string OriginatingTenantName { get; set; }

    //[JsonPropertyName("OriginatingTenantId")]
    //public long OriginatingTenantId { get; set; }

    //[JsonPropertyName("OriginatingTenantPublicId")]
    //public string OriginatingTenantPublicId { get; set; }

    //[JsonPropertyName("SiloId")]
    //public long SiloId { get; set; }

    //[JsonPropertyName("Lens_Originator")]
    //public string LensOriginator { get; set; }

    //[JsonPropertyName("Lens_OriginatorData")]
    //public string LensOriginatorData { get; set; }

    //[JsonPropertyName("Lens_SessionId")]
    //public string LensSessionId { get; set; }

    //[JsonPropertyName("Lens_BatchId")]
    //public string LensBatchId { get; set; }

    //[JsonPropertyName("ResponsibleTeamName")]
    //public string ResponsibleTeamName { get; set; }

    //[JsonPropertyName("IncidentManagerContactId")]
    //public string IncidentManagerContactId { get; set; }

    //[JsonPropertyName("CommunicationsManagerContactId")]
    //public string CommunicationsManagerContactId { get; set; }

    //[JsonPropertyName("OutageImpactLevel")]
    //public string OutageImpactLevel { get; set; }

    //[JsonPropertyName("ExecutiveIncidentManagerContactId")]
    //public string ExecutiveIncidentManagerContactId { get; set; }

    //[JsonPropertyName("Tags")]
    //public string Tags { get; set; }
}
