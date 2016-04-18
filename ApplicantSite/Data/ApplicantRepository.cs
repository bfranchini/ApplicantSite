using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantSite.Data
{
    public class ApplicantRepository
    {
        readonly CSharpDevDBEntities context;

        public ApplicantRepository(CSharpDevDBEntities c)
        {
            context = c;
        }

        /// <summary>
        /// returns a single applicant given applicant id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Applicant Get(int Id)
        {
            return context.Applicants.Where(s => s.Id == Id).SingleOrDefault();
        }

        /// <summary>
        /// returns list of all applicants in the database
        /// </summary>
        /// <returns></returns>
        public IQueryable<Applicant> All()
        {
            return context.Applicants.Select(s => s);
        }

        public void Add(Applicant applicant)
        {
            context.Applicants.Add(applicant);
        }
    }
}