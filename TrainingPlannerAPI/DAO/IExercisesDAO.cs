using vbsessionplan.Contracts;
using vbsessionplan.Models;


namespace vbsessionplan.DAO;

public interface IExercisesDAO
{
    public Task<List<Exercise>> GetExercises();
    public Task<Exercise> GetExerciseById(string id);
    public Task PostExercise(PostExerciseRequest request);
    public Task PatchExercise(string id, PatchExerciseRequest request);
}