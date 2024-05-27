using MongoDB.Bson;
using MongoDB.Driver;
using vbsessionplan.Models;
using vbsessionplan.Contracts;

namespace vbsessionplan.DAO;


public class DrillsDAO : IDrillsDAO
{
    private readonly MongoClient _client;
    private readonly IMongoCollection<Drill> _drillCollection;
    public DrillsDAO(MongoClient client)
    {
        _client = client;
        _drillCollection = _client
            .GetDatabase("SessionPlanner")
            .GetCollection<Drill>("drills");
    }

    public async Task<List<Drill>> GetDrills()
    {
        var filter = Builders<Drill>.Filter.Empty;
        var drills = await _drillCollection
            .Find(filter)
            .ToListAsync();
        return drills;
    }
    public async Task<Drill> GetDrillById(string id)
    {
        ObjectId objectId;
        try { objectId = ObjectId.Parse(id); }
        catch (FormatException ex) { throw new Exception("Object id invalid formatted.", ex); }

        var drill = await _drillCollection
            .Find(Builders<Drill>.Filter.Eq("_id", objectId))
            .FirstOrDefaultAsync();

        Console.WriteLine(drill);
        return drill;
    }

    public async Task PostDrill(PostDrillRequest request)
    {
        Drill drill = new()
        {
            Title = request.Title,
            Instructions = request.Instructions,
            ParticipantsMin = request.ParticipantsMin,
            ParticipantsMax = request.ParticipantsMax,
            MinimumDuration = request.MinimumDuration,
            RecommendedDuration = request.RecommendedDuration,
        };

        await _drillCollection
            .InsertOneAsync(drill);
    }

    public async Task PatchDrill(string id, PatchDrillRequest request)
    {
        ObjectId objectId;
        try { objectId = ObjectId.Parse(id); }
        catch (FormatException ex) { throw new Exception("Object id invalid formatted.", ex); }

        var update = Builders<Drill>.Update.Combine();

        var patchDrillProperties = typeof(PatchDrillRequest).GetProperties();
        foreach (var property in patchDrillProperties)
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

        await _drillCollection
            .UpdateOneAsync(Builders<Drill>.Filter.Eq("_id", objectId), update);
    }

}