﻿using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommand : IRequest<UpdatedProgrammingTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       

        public class UpdateProgrammingTechnologyCommandHandler : IRequestHandler<UpdateProgrammingTechnologyCommand, UpdatedProgrammingTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public UpdateProgrammingTechnologyCommandHandler(IMapper mapper, IProgrammingTechnologyRepository programmingTechnologyRepository, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _mapper = mapper;
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<UpdatedProgrammingTechnologyDto> Handle(UpdateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                //await _programmingTechnologyBusinessRules.CheckIfProgrammingTechologyAlreadyExistsOnTable(request.Name);
                ProgrammingTechnology mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);



                ProgrammingTechnology updatedProgrammingTechnology = await _programmingTechnologyRepository.UpdateAsync(mappedProgrammingTechnology);

                UpdatedProgrammingTechnologyDto updatedProgrammingTechnologyDto = _mapper.Map<UpdatedProgrammingTechnologyDto>(updatedProgrammingTechnology);
                return updatedProgrammingTechnologyDto;
            }
        }

    }
}
