using pc24395u202312031.API.CRM.Domain.Model.ValueObjects;

namespace pc24395u202312031.API.CRM.Domain.Model.Commands;

public record CreateLeadCommand(
    string FirstName,
    string LastName,
    Guid ActiveCampaignCustomerId,
    ELeadStatus Status,
    int AssignedSalesAgentId,
    DateOnly ContactedAt,
    DateOnly ApprovedAt,
    DateTime ReportedAt
    );