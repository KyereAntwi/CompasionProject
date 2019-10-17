using ProjectModels.Models;
using ProjectModels.Models.Academics;
using ProjectModels.Models.SponserActivities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Repositories
{
    public interface IServiceRepo
    {
        #region Children activities
        Task<Child> GetChild(int Id);
        Task<List<Child>> GetAllChildren();
        Task<Child> AddChild(Child child);
        Task<Child> UpdateChild(int Id, Child child);
        Task<Child> DeleteChild(int Id);

        Task<bool> SubmitAcademicRecordSingle(Transcript record);
        Task<bool> SubmitAcademicRecordMany(List<Transcript> records);

        Task<Talent> AddChildTalent(int childID, Talent talent);
        Task<bool> RemoveChildTalent(int childID, int talentID);

        Task<TakeCare> SponcerAChild(TakeCare takeCare);
        Task<bool> StopSponcoringAChild(int sponcerID, int childId);

        Task<ChildChallenge> AddChildChallenge(ChildChallenge challenge);
        Task<bool> RemoveChallenge(int challengeId);

        Task<ChildNeed> AddNeeds(ChildNeed need);
        Task<bool> RemoveNeed(int needId);
        #endregion

        #region Sponcer Activities
        Task<Sponser> GetSponser(int sponserId);
        Task<List<Sponser>> GetAllSponser();

        Task<Sponser> AddSponser(Sponser sponser);
        Task<Sponser> UpdateSponser(int sponserId, Sponser sponser);
        Task<Sponser> DeleteSponser(int sponserId);

        Task<Letter> WriteAChild(Letter letter);
        Task<Visit> BookVisit(Visit visit);
        Task<Volunteer> Volunteer(Volunteer volunteer);
        #endregion
    }
}
