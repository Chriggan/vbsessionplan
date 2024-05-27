namespace vbsessionplan.Contracts;
public record PostExerciseRequest(
    string Title,
    string Instructions,
    int ParticipantsMin,
    int? ParticipantsMax,
    int? MinimumDuration,
    int? RecommendedDuration
);
public record PatchExerciseRequest(
    string? Title,
    string? Instructions,
    int? ParticipantsMin,
    int? ParticipantsMax,
    int? MinimumDuration,
    int? RecommendedDuration
);