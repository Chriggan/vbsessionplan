using vbsessionplan.Models;


namespace vbsessionplan.DAO;

public interface IExercisesDAO
{
    public Task<List<Exercise>> GetExercises();
    public Task<Exercise> GetExerciseById(Guid id);
}