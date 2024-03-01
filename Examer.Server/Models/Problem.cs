using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Examer.Server.Models
{
    public class Problem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string token { get; set; }
        public string text { get; set; }
        public string Answer {  get; set; }

        [Column(TypeName = "TEXT")]
        public string AnswerPhoto { get; set; }

    }
}
