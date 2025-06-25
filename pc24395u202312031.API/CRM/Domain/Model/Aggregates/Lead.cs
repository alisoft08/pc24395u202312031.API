using System;
using System.Linq;
using pc24395u202312031.API.CRM.Domain.Model.Commands;
using pc24395u202312031.API.CRM.Domain.Model.ValueObjects;

namespace pc24395u202312031.API.CRM.Domain.Model.Aggregates;

public partial class Lead
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid ActiveCampaignCustomerId { get; set; }
    public ELeadStatus Status { get; private set; }
    public int AssignedSalesAgentId { get; set; }
    public DateOnly ContactedAt { get; set; }
    public DateOnly ApprovedAt { get; set; }
    public DateTime ReportedAt { get; set; }

    public Lead() {}

    public Lead(CreateLeadCommand command)
    {
        FirstName                 = command.FirstName;
        LastName                  = command.LastName;
        ActiveCampaignCustomerId  = command.ActiveCampaignCustomerId;
        Status                    = Enum.IsDefined<ELeadStatus>(command.Status)
                                      ? command.Status
                                      : ELeadStatus.Open;

        // 1) Si el estado es distinto de Open, necesito agente y fecha de contacto
        EnsureAgentAndContactedStatus();

        // 2) Para estados Qualified o posteriores, necesito fecha de aprobación
        EnsureApprovedStatus();

        // 3) Para estado Unqualified, necesito fecha de reporte
        EnsureReportedStatus();

        AssignedSalesAgentId      = command.AssignedSalesAgentId;
        ContactedAt               = command.ContactedAt;
        ApprovedAt                = command.ApprovedAt;
        ReportedAt                = command.ReportedAt;
    }

    // ——————————————————————————————————————————
    //  Reglas de negocio encapsuladas como métodos privados
    // ——————————————————————————————————————————

    private void EnsureAgentAndContactedStatus()
    {
        var requiresAgent = new[]
        {
            ELeadStatus.Contacted,
            ELeadStatus.MeetingSet,
            ELeadStatus.Qualified,
            ELeadStatus.Customer,
            ELeadStatus.OpportunityLost,
            ELeadStatus.Unqualified,
            ELeadStatus.InactiveCustomer
        };

        if (requiresAgent.Contains(Status) &&
            (AssignedSalesAgentId <= 0 || ContactedAt == default))
        {
            throw new Exception(
                "Para estados distintos de Open se requiere assignedSalesAgentId y contactedAt.");
        }
    }

    private void EnsureApprovedStatus()
    {
        var requiresApproved = new[]
        {
            ELeadStatus.Qualified,
            ELeadStatus.Customer,
            ELeadStatus.OpportunityLost,
            ELeadStatus.Unqualified,
            ELeadStatus.InactiveCustomer
        };

        if (requiresApproved.Contains(Status) &&
            ApprovedAt == default)
        {
            throw new Exception(
                "Para estados Qualified o posteriores se requiere approvedAt.");
        }
    }

    private void EnsureReportedStatus()
    {
        if (Status == ELeadStatus.Unqualified &&
            ReportedAt == default)
        {
            throw new Exception(
                "Para el estado Unqualified se requiere reportedAt.");
        }
    }
}
