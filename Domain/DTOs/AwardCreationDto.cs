using System;

namespace Domain.DTOs
{
    public class AwardCreationDto
    {
        public String Name { get; set; }

        public AwardCreationDto(string name)
        {
            Name = name;
        }
    }
}