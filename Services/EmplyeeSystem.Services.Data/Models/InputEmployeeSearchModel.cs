namespace EmplyeeSystem.Services.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EmplyeeSystem.Data.Models;
    using EmplyeeSystem.Services.Mapping;

    public class InputEmployeeSearchModel : IMapTo<Employee>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string JobTitle { get; set; }

        public string Department { get; set; }

        public DateTime? JoinedOn { get; set; }
    }
}
