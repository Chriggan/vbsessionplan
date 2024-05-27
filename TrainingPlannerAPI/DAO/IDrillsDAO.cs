using vbsessionplan.Contracts;
using vbsessionplan.Models;


namespace vbsessionplan.DAO;

public interface IDrillsDAO
{
    public Task<List<Drill>> GetDrills();
    public Task<Drill> GetDrillById(string id);
    public Task PostDrill(PostDrillRequest request);
    public Task PatchDrill(string id, PatchDrillRequest request);
}