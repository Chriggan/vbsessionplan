using MongoDB.Bson;
using MongoDB.Driver;
using vbsessionplan.Models;
using vbsessionplan.Contracts;

namespace vbsessionplan.DAO;


public class ExercisesDAO : IExercisesDAO
{
    private readonly MongoClient _client;
    private readonly IMongoCollection<Exercise> _exerciseCollection;
    public ExercisesDAO(MongoClient client)
    {
        _client = client;
        _exerciseCollection = _client
            .GetDatabase("ExerciseData")
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
    public async Task<Exercise> GetExerciseById(string id)
    {
        var exercise = await _exerciseCollection
            .Find(Builders<Exercise>.Filter.Eq("_id", id))
            .FirstOrDefaultAsync();

        return exercise;
    }

    public async Task PostExercise(PostExerciseRequest request)
    {
        Exercise exercise = new()
        {
            Title = request.Title,
            Instructions = request.Instructions,
            ParticipantsMin = request.ParticipantsMin,
            ParticipantsMax = request.ParticipantsMax,
            MinimumDuration = request.MinimumDuration,
            RecommendedDuration = request.RecommendedDuration,
        };

        await _exerciseCollection
            .InsertOneAsync(exercise);
    }

    public async Task PatchExercise(string id, PatchExerciseRequest request)
    {
        ObjectId objectId;
        try { objectId = ObjectId.Parse(id); }
        catch (FormatException ex) { throw new Exception("Object id invalid formatted.", ex); }

        var update = Builders<Exercise>.Update.Combine();

        var patchExerciseProperties = typeof(PatchExerciseRequest).GetProperties();
        foreach (var property in patchExerciseProperties)
        {
            object? value = property.GetValue(request, null);
            if (value is null)
            {
                Console.WriteLine($"{property.Name}: {value}");
            }
            else
            {
                Console.WriteLine(value is null);
            }
        }

        // if (title != null)
        //     update = update.Set("title", title);

        await _exerciseCollection
            .UpdateOneAsync(Builders<Exercise>.Filter.Eq("_id", objectId), update);
    }

}