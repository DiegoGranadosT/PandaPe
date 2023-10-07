using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Models.EntityBases
{
    public class CandidateBase : EntityBase<int>
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
    }
}
