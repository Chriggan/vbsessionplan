using MongoDB.Driver;
using vbsessionplan.Models;

namespace vbsessionplan.DAO;


public class ExercisesDAO : IExercisesDAO
{
    private readonly MongoClient _client;
    private readonly IMongoCollection<Exercise> _exerciseCollection;
    public ExercisesDAO(MongoClient client)
    {
        _client = client;
        _exerciseCollection = _client
            .GetDatabase("vbsessionplan")
            .GetCollection<Exercise>("Exercises");
    }

    public async Task<List<Exercise>> GetExercises()
    {
        var filter = Builders<Exercise>.Filter.Empty;
        var exercises = await _exerciseCollection
            .Find(filter)
            .ToListAsync();
        return exercises;
    }
    public async Task<Exercise> GetExerciseById(Guid id)
    {
        var exercise = new Exercise();

        return exercise;
    }

}