﻿using System.ComponentModel.DataAnnotations;

namespace AssessmentMangement.Entites
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get;set;}

    }
}
