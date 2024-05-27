namespace vbsessionplan.Contracts;
public record PostDrillRequest(
    string Title,
    string Instructions,
    int ParticipantsMin,
    int? ParticipantsMax,
    int? MinimumDuration,
    int? RecommendedDuration
);
public record PatchDrillRequest(
    string? Title,
    string? Instructions,
    int? ParticipantsMin,
    int? ParticipantsMax,
    int? MinimumDuration,
    int? RecommendedDuration
);