﻿using Application.Features.ProgrammingLanguages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Models
{
    public class ProgrammingLanguageListModel:BasePageableModel
    {
        public List<ProgrammingLanguageListDto> Items { get; set; }
    }
}
