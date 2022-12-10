using Api.DevEnvolve.Data;
using Api.DevEnvolve.Model;

namespace Api.DevEnvolve.Repository
{
    public class SkillsRepository
    {
        public static List<Skills> GetSkills()
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    return dbContext.Skills.AsQueryable().ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Skills> GetSkillsFreelancers(int idFreelancer)
        {
            try
            {
                using (var dbContext = new DataContext())
                {
                    var idskillsFreelancer = dbContext.SkillFreelancer.AsQueryable().Where(x => x.idFreelancer == idFreelancer).ToList();
                    List<Skills> skillDescricao = new List<Skills>();
                    foreach (var id in idskillsFreelancer)
                    {
                        var skill = dbContext.Skills.AsQueryable().Where(x => x.idSkill == id.idSkill).FirstOrDefault();
                        skillDescricao.Add(skill);
                    }

                    return skillDescricao;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void PostSkillsFreelancer(List<int> idSkill, int idFreelancer)
        {
            try
            {
                foreach (var skil in idSkill)
                {
                    Skill skill = new Skill
                    {
                        idSkill = skil,
                        idFreelancer = idFreelancer
                    };

                    using (var dbContext = new DataContext())
                    {
                        dbContext.SkillFreelancer.Add(skill);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}