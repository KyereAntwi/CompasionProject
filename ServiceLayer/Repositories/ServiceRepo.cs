using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectModels.Models;
using ProjectModels.Models.Academics;
using ProjectModels.Models.SponserActivities;
using ServiceLayer.Data;

namespace ServiceLayer.Repositories
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly ServiceLayerDbContext _dbContext;

        public ServiceRepo(ServiceLayerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Children Activities
        public async Task<ChildChallenge> AddChildChallenge(ChildChallenge challenge)
        {
            if (await _dbContext.Children.FindAsync(challenge.ChildID) == null)
                return null;

            _ = await _dbContext.ChildChallenges.AddAsync(challenge);
            _ = await _dbContext.SaveChangesAsync();
            return challenge;
        }

        public async Task<Child> AddChild(Child child)
        {
            _ = await _dbContext.Children.AddAsync(child);
            _ = await _dbContext.SaveChangesAsync();
            return child;
        }

        public async Task<Talent> AddChildTalent(int childID, Talent talent)
        {
            if (await _dbContext.Children.FindAsync(childID) == null)
                return null;

            _ = await _dbContext.Talents.AddAsync(talent);
            _ = _dbContext.SaveChangesAsync();
            return talent;
        }

        public async Task<ChildNeed> AddNeeds(ChildNeed need)
        {
            if (await _dbContext.Children.FindAsync(need.ChildID) == null)
                return null;

            _ = await _dbContext.ChildNeeds.AddAsync(need);
            _ = await _dbContext.SaveChangesAsync();
            return need;
        }

        public async Task<Child> DeleteChild(int Id)
        {
            Child toDeleted = await _dbContext.Children.FindAsync(Id);

            if (toDeleted != null)
            {
                _ = _dbContext.Children.Remove(toDeleted);
                _ = await _dbContext.SaveChangesAsync();
                return toDeleted;
            }

            return null;
        }

        public async Task<List<Child>> GetAllChildren()
        {
            List<Child> foundChildren = new List<Child>();

            if (!await _dbContext.Children.AnyAsync())
                return foundChildren;

            foundChildren = await _dbContext.Children
                .Include(c => c.Challenges)
                .Include(c => c.Class)
                .Include(c => c.Needs)
                .Include(c => c.Sponsers)
                .Include(c => c.Transcripts)
                .Include(c => c.Talents)
                .ToListAsync();

            return foundChildren.OrderBy(h => h.Surname).ToList();
        }

        public async Task<Child> GetChild(int Id)
        {
            if (await _dbContext.Children.FindAsync(Id) == null)
                return null;

            return await _dbContext
                .Children
                .Include(c => c.Challenges)
                .Include(c => c.Class)
                .Include(c => c.Needs)
                .Include(c => c.Sponsers)
                .Include(c => c.Transcripts)
                .Include(c => c.Talents)
                .Where<Child>(c => c.PersonID == Id)
                .FirstAsync();
        }

        public async Task<bool> RemoveChallenge(int challengeId)
        {
            ChildChallenge foundChildChallenge = await _dbContext.ChildChallenges.FindAsync(challengeId);

            if (foundChildChallenge == null) return false;

            _ = _dbContext.ChildChallenges.Remove(foundChildChallenge);
            _ = await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveChildTalent(int childID, int talentID)
        {
            Talent foundTalent = await _dbContext.Talents.FindAsync(talentID);

            if (childID <= 0 && foundTalent == null)
                return false;

            _ = _dbContext.Talents.Remove(foundTalent);
            _ = await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveNeed(int needId)
        {
            ChildNeed foundNeed = await _dbContext.ChildNeeds.FindAsync(needId);

            if (foundNeed == null) return false;

            _ = _dbContext.ChildNeeds.Remove(foundNeed);
            _ = await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TakeCare> SponcerAChild(TakeCare takeCare)
        {
            if (await _dbContext.Children.FindAsync(takeCare.ChildID) == null)
                return null;

            _ = await _dbContext.TakeCares.AddAsync(takeCare);
            _ = await _dbContext.SaveChangesAsync();
            return takeCare;
        }

        public async Task<bool> StopSponcoringAChild(int sponcerID, int childId)
        {
            if (!await _dbContext.TakeCares.AnyAsync())
                return false;

            TakeCare care = await _dbContext.TakeCares
                .Where<TakeCare>(c => c.ChildID == childId && c.SponserID == sponcerID)
                .FirstAsync();

            if (care != null)
            {
                _ = _dbContext.TakeCares.Remove(care);
                _ = await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Child> UpdateChild(int Id, Child child)
        {
            Child foundChild = await _dbContext.Children.FindAsync(Id);

            if (foundChild == null)
                return null;

            foundChild.ClassID = child.ClassID;
            foundChild.DateAdmitted = child.DateAdmitted;
            foundChild.DateOfBirth = child.DateOfBirth;
            foundChild.FirstName = child.FirstName;
            foundChild.Gender = child.Gender;
            foundChild.ImageUrl = child.ImageUrl;
            foundChild.MiddleNames = child.MiddleNames;
            foundChild.Surname = child.Surname;

            _ =  _dbContext.Update(foundChild);
            _ = await _dbContext.SaveChangesAsync();

            return foundChild;
        }

        public async Task<bool> SubmitAcademicRecordSingle(Transcript record)
        {
            if (await _dbContext.Children.FindAsync(record.ChildID) == null)
                return false;

            _ = await _dbContext.Transcripts.AddAsync(record);
            _ = await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SubmitAcademicRecordMany(List<Transcript> records)
        {
            if (await _dbContext.Children.FindAsync(records.First().ChildID) == null)
                return false;

            await _dbContext.Transcripts.AddRangeAsync(records);
            _ = await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Sponser Activities
        public async Task<Sponser> AddSponser(Sponser sponser)
        {
            _ = await _dbContext.Sponsers.AddAsync(sponser);
            _ = await _dbContext.SaveChangesAsync();
            return sponser;
        }

        public async Task<Sponser> UpdateSponser(int sponserId, Sponser sponser)
        {
            Sponser foundSponcer = await _dbContext.Sponsers.FindAsync(sponserId);

            if (foundSponcer == null)
                return null;

            foundSponcer.DateOfBirth = sponser.DateOfBirth;
            foundSponcer.EducationalLevel = sponser.EducationalLevel;
            foundSponcer.FirstName = sponser.FirstName;
            foundSponcer.Gender = sponser.Gender;
            foundSponcer.ImageUrl = sponser.ImageUrl;
            foundSponcer.MaritalStatus = sponser.MaritalStatus;
            foundSponcer.MiddleNames = sponser.MiddleNames;
            foundSponcer.Nationality = sponser.Nationality;
            foundSponcer.Occupation = sponser.Occupation;
            foundSponcer.PreferedCommunication = sponser.PreferedCommunication;
            foundSponcer.Surname = sponser.Surname;

            _ = _dbContext.Sponsers.Update(foundSponcer);
            _ = await _dbContext.SaveChangesAsync();
            return foundSponcer;
        }

        public async Task<Sponser> DeleteSponser(int sponserId)
        {
            Sponser foundSponser = await _dbContext.Sponsers.FindAsync(sponserId);

            if (foundSponser == null)
                return null;

            _dbContext.Sponsers.Remove(foundSponser);
            _ = await _dbContext.SaveChangesAsync();

            return foundSponser;
        }

        public async Task<Letter> WriteAChild(Letter letter)
        {
            _ = await _dbContext.Letters.AddAsync(letter);
            _ = await _dbContext.SaveChangesAsync();
            return letter;
        }

        public async Task<Visit> BookVisit(Visit visit)
        {
            _ = await _dbContext.Visits.AddAsync(visit);
            _ = await _dbContext.SaveChangesAsync();
            return visit;
        }

        public async Task<Volunteer> Volunteer(Volunteer volunteer)
        {
            _ = await _dbContext.Volunteers.AddAsync(volunteer);
            _ = await _dbContext.SaveChangesAsync();
            return volunteer;
        }

        public async Task<Sponser> GetSponser(int sponserId)
        {
            if (await _dbContext.Sponsers.FindAsync(sponserId) == null)
                return null;

            Sponser foundSponser = await _dbContext.Sponsers
                .Include(s => s.Contacts)
                .Include(s => s.Letters)
                .Include(s => s.Visits)
                .Include(s => s.VolunteeringActivities)
                .Where<Sponser>(s => s.PersonID == sponserId)
                .FirstAsync();

            return foundSponser;
        }

        public async Task<List<Sponser>> GetAllSponser()
        {
            List<Sponser> AllSponcers = new List<Sponser>();

            if (!await _dbContext.Sponsers.AnyAsync())
                return AllSponcers;

            AllSponcers = await _dbContext.Sponsers
                .Include(s => s.Contacts)
                .Include(s => s.Letters)
                .Include(s => s.Visits)
                .Include(s => s.VolunteeringActivities).ToListAsync<Sponser>();

            return AllSponcers.OrderBy(s => s.DateAdded).ToList();
        }
        #endregion
    }
}
